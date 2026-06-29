using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UI = UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;
using Veauty;
using Veauty.GameObject;
using Veauty.GameObject.Attributes;
using Veauty.uGUI;
using Veauty.VTree;
using GameObjectRenderer = Veauty.GameObject.Renderer;
using UnityGameObject = UnityEngine.GameObject;
using UnityObject = UnityEngine.Object;

struct Unit {}

public class TestCreateElement
{
    private UnityGameObject root;
    private UnityGameObject eventSystem;

    [SetUp]
    public void SetUp()
    {
        this.root = new UnityGameObject("uGUI test root");
        var canvas = this.root.AddComponent<UnityEngine.Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.targetDisplay = 0;

        var scaler = this.root.AddComponent<UI.CanvasScaler>();
        scaler.uiScaleMode = UI.CanvasScaler.ScaleMode.ConstantPixelSize;
        scaler.scaleFactor = 1;
        scaler.referencePixelsPerUnit = 100;
        this.root.AddComponent<UI.GraphicRaycaster>();

        this.eventSystem = new UnityGameObject("EventSystem");
        this.eventSystem.AddComponent<EventSystem>();
    }

    [TearDown]
    public void TearDown()
    {
        if (this.root != null)
        {
            UnityObject.DestroyImmediate(this.root);
            this.root = null;
        }

        if (this.eventSystem != null)
        {
            UnityObject.DestroyImmediate(this.eventSystem);
            this.eventSystem = null;
        }
    }

    private VeautyObject<Unit> CreateVeauty(System.Func<Unit, IVTree> func)
    {
        return new VeautyObject<Unit>(this.root, func);
    }

    private IEnumerator UITest(System.Func<Unit, IVTree> func, params System.Type[] uiComponentTypes)
    {
        _ = CreateVeauty(func);
        yield return null;

        uiComponentTypes.ToList().ForEach(x => {
            var comp = UnityObject.FindAnyObjectByType(x);
            Assert.IsNotNull(comp);
        });
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestCreateButtonElement()
    {
        var clicked = false;

        yield return UITest(_ => new Button(new IAttribute<UnityGameObject>[] {
            new Button.OnClick(() => clicked = true)
        }), typeof(UI.Button));

        ExecuteEvents.Execute(
            target: UnityObject.FindAnyObjectByType<UI.Button>().gameObject,
            eventData: new PointerEventData(EventSystem.current),
            functor: ExecuteEvents.pointerClickHandler
        );
        yield return null;

        Assert.True(clicked);

        var button = UnityObject.FindAnyObjectByType<UI.Button>();
        Assert.IsNotNull(button.targetGraphic);
        Assert.IsNotNull(button.GetComponent<UI.Image>());
    }

    [UnityTest]
    public IEnumerator TestCreateTextElement()
    {
        yield return UITest(_ => new Text(new IAttribute<UnityGameObject>[] {
            new Text.Value("Hello")
        }), typeof(UI.Text));

        var text = UnityObject.FindAnyObjectByType<UI.Text>();
        Assert.AreEqual("Hello", text.text);
        Assert.IsNotNull(text.font);
    }

    [UnityTest]
    public IEnumerator TestCreateImageElement()
    {
        yield return UITest(_ => new Image(new IAttribute<UnityGameObject>[] {
            new Image.PreserveAspect(true),
            new Graphic.Color(Color.red)
        }), typeof(UI.Image));

        var image = UnityObject.FindAnyObjectByType<UI.Image>();
        Assert.IsTrue(image.preserveAspect);
        Assert.AreEqual(Color.red, image.color);
    }

    [UnityTest]
    public IEnumerator TestCreateRaycastReceiverElement()
    {
        yield return UITest(_ => new RaycastReceiver(new IAttribute<UnityGameObject>[] {
            new RaycastReceiver.Color(Color.green)
        }), typeof(UI.RaycastReceiver));

        var receiver = UnityObject.FindAnyObjectByType<UI.RaycastReceiver>();
        Assert.AreEqual(Color.green, receiver.color);
    }

    [UnityTest]
    public IEnumerator TestCreateInputFieldElement()
    {
        var changedValue = "";
        var onValueChanged = new UI.InputField.OnChangeEvent();
        onValueChanged.AddListener(value => changedValue = value);

        yield return UITest(_ => new InputField(new IAttribute<UnityGameObject>[] {
            new InputField.Text("initial"),
            new InputField.OnValueChanged(onValueChanged)
        }), typeof(UI.InputField));

        var input = UnityObject.FindAnyObjectByType<UI.InputField>();
        Assert.AreEqual("initial", input.text);

        input.onValueChanged.Invoke("edited");
        Assert.AreEqual("edited", changedValue);
    }

    [UnityTest]
    public IEnumerator TestVeautyObjectUpdatesTextElement()
    {
        System.Action<CounterState> setState = null;

        _ = new VeautyObject<CounterState>(
            this.root,
            (state, set) => {
                setState = set;
                return new Text(new IAttribute<UnityGameObject>[] {
                    new Text.Value("Count " + state.Count)
                });
            },
            new CounterState { Count = 1 }
        );

        yield return null;
        Assert.AreEqual("Count 1", UnityObject.FindAnyObjectByType<UI.Text>().text);

        setState(new CounterState { Count = 2 });
        yield return null;

        Assert.AreEqual("Count 2", UnityObject.FindAnyObjectByType<UI.Text>().text);
    }

    [UnityTest]
    public IEnumerator TestRefCapturesRenderedGameObject()
    {
        var textRef = new Veauty.uGUI.Ref<UnityGameObject>();

        yield return UITest(_ => new Text(new IAttribute<UnityGameObject>[] {
            textRef,
            new Text.Value("ref")
        }), typeof(UI.Text));

        Assert.IsNotNull(textRef.current);
        Assert.AreSame(UnityObject.FindAnyObjectByType<UI.Text>().gameObject, textRef.current);
    }

    [UnityTest]
    public IEnumerator TestKeyedChildrenReorderKeepsComponents()
    {
        var oldTree = new KeyedNode<UnityGameObject>(
            "root",
            NoAttrs(),
            ("a", new Text(new IAttribute<UnityGameObject>[] { new Text.Value("A") })),
            ("b", new Text(new IAttribute<UnityGameObject>[] { new Text.Value("B") })),
            ("c", new Text(new IAttribute<UnityGameObject>[] { new Text.Value("C") }))
        );
        var newTree = new KeyedNode<UnityGameObject>(
            "root",
            NoAttrs(),
            ("b", new Text(new IAttribute<UnityGameObject>[] { new Text.Value("B2") })),
            ("c", new Text(new IAttribute<UnityGameObject>[] { new Text.Value("C") })),
            ("a", new Text(new IAttribute<UnityGameObject>[] { new Text.Value("A") }))
        );
        var rendered = GameObjectRenderer.Render(oldTree, true);
        rendered.transform.SetParent(this.root.transform, false);
        var oldB = rendered.transform.GetChild(1).gameObject;

        rendered = Patch.Apply(rendered, oldTree, Diff<UnityGameObject>.Calc(oldTree, newTree), true);
        yield return null;

        Assert.AreSame(oldB, rendered.transform.GetChild(0).gameObject);
        Assert.AreEqual("B2", rendered.transform.GetChild(0).GetComponent<UI.Text>().text);
        Assert.AreEqual("A", rendered.transform.GetChild(2).GetComponent<UI.Text>().text);
    }

    [UnityTest]
    public IEnumerator TestTypedKeyedLayoutGroupRendersComponent()
    {
        var tree = new KeyedNode<UnityGameObject, UI.HorizontalLayoutGroup>(
            "rows",
            new IAttribute<UnityGameObject>[] {
                new HorizontalOrVerticalLayoutGroup.Spacing(8f)
            },
            ("a", new Text(new IAttribute<UnityGameObject>[] { new Text.Value("A") }))
        );

        var rendered = GameObjectRenderer.Render(tree, true);
        rendered.transform.SetParent(this.root.transform, false);
        yield return null;

        var layout = rendered.GetComponent<UI.HorizontalLayoutGroup>();
        Assert.IsNotNull(layout);
        Assert.AreEqual(8f, layout.spacing);
    }

    [UnityTest]
    public IEnumerator TestRectTransformAttributesApplyToUGUINode()
    {
        var tree = new Text(new IAttribute<UnityGameObject>[] {
            new Text.Value("rect"),
            new Veauty.uGUI.RectTransform.AnchorMin(new Vector2(0.25f, 0.5f)),
            new Veauty.uGUI.RectTransform.AnchorMax(new Vector2(0.25f, 0.5f)),
            new Veauty.uGUI.RectTransform.Pivot(new Vector2(0.1f, 0.9f)),
            new Veauty.uGUI.RectTransform.SizeDelta(new Vector2(120f, 32f)),
            new Veauty.uGUI.RectTransform.AnchoredPosition(new Vector2(10f, 20f)),
            new Veauty.uGUI.RectTransform.SendChildDimensionsChange(false)
        });

        var rendered = GameObjectRenderer.Render(tree, true);
        rendered.transform.SetParent(this.root.transform, false);
        yield return null;

        var rectTransform = rendered.GetComponent<UnityEngine.RectTransform>();
        Assert.AreEqual(new Vector2(0.25f, 0.5f), rectTransform.anchorMin);
        Assert.AreEqual(new Vector2(0.25f, 0.5f), rectTransform.anchorMax);
        Assert.AreEqual(new Vector2(0.1f, 0.9f), rectTransform.pivot);
        Assert.AreEqual(new Vector2(120f, 32f), rectTransform.sizeDelta);
        Assert.AreEqual(new Vector2(10f, 20f), rectTransform.anchoredPosition);
        Assert.IsFalse(rectTransform.sendChildDimensionsChange);
    }

    [UnityTest]
    public IEnumerator TestConcreteLayoutGroupAliasesApplyInheritedProperties()
    {
        yield return UITest(_ => new VerticalLayoutGroup(new IAttribute<UnityGameObject>[] {
            new VerticalLayoutGroup.Padding(new RectOffset(1, 2, 3, 4)),
            new VerticalLayoutGroup.ChildAlignment(TextAnchor.MiddleRight),
            new VerticalLayoutGroup.Spacing(12f),
            new VerticalLayoutGroup.ChildControlWidth(false),
            new VerticalLayoutGroup.ChildForceExpandHeight(false),
            new VerticalLayoutGroup.ReverseArrangement(true)
        }), typeof(UI.VerticalLayoutGroup));

        var layout = UnityObject.FindAnyObjectByType<UI.VerticalLayoutGroup>();
        Assert.AreEqual(1, layout.padding.left);
        Assert.AreEqual(2, layout.padding.right);
        Assert.AreEqual(3, layout.padding.top);
        Assert.AreEqual(4, layout.padding.bottom);
        Assert.AreEqual(TextAnchor.MiddleRight, layout.childAlignment);
        Assert.AreEqual(12f, layout.spacing);
        Assert.IsFalse(layout.childControlWidth);
        Assert.IsFalse(layout.childForceExpandHeight);
        Assert.IsTrue(layout.reverseArrangement);
    }

    [UnityTest]
    public IEnumerator TestGridLayoutGroupAliasesApplyInheritedProperties()
    {
        yield return UITest(_ => new GridLayoutGroup(new IAttribute<UnityGameObject>[] {
            new GridLayoutGroup.Padding(new RectOffset(5, 6, 7, 8)),
            new GridLayoutGroup.ChildAlignment(TextAnchor.LowerCenter),
            new GridLayoutGroup.CellSize(new Vector2(40f, 50f)),
            new GridLayoutGroup.Spacing(new Vector2(3f, 4f))
        }), typeof(UI.GridLayoutGroup));

        var layout = UnityObject.FindAnyObjectByType<UI.GridLayoutGroup>();
        Assert.AreEqual(5, layout.padding.left);
        Assert.AreEqual(6, layout.padding.right);
        Assert.AreEqual(7, layout.padding.top);
        Assert.AreEqual(8, layout.padding.bottom);
        Assert.AreEqual(TextAnchor.LowerCenter, layout.childAlignment);
        Assert.AreEqual(new Vector2(40f, 50f), layout.cellSize);
        Assert.AreEqual(new Vector2(3f, 4f), layout.spacing);
    }

    [UnityTest]
    public IEnumerator TestLayoutElementAttributeAddsLayoutElement()
    {
        yield return UITest(_ => new Button(new IAttribute<UnityGameObject>[] {
            new LayoutElement.PreferredHeight(88f)
        }), typeof(UI.Button));

        var layoutElement = UnityObject.FindAnyObjectByType<UI.Button>().GetComponent<UI.LayoutElement>();
        Assert.IsNotNull(layoutElement);
        Assert.AreEqual(88f, layoutElement.preferredHeight);
    }

    [UnityTest]
    public IEnumerator TestLayoutFitterAttributesAddComponents()
    {
        yield return UITest(_ => new Image(new IAttribute<UnityGameObject>[] {
            new ContentSizeFitter.HorizontalFit(UI.ContentSizeFitter.FitMode.PreferredSize),
            new AspectRatioFitter.AspectMode(UI.AspectRatioFitter.AspectMode.WidthControlsHeight),
            new AspectRatioFitter.AspectRatio(1.5f)
        }), typeof(UI.Image));

        var image = UnityObject.FindAnyObjectByType<UI.Image>();
        var contentSizeFitter = image.GetComponent<UI.ContentSizeFitter>();
        var aspectRatioFitter = image.GetComponent<UI.AspectRatioFitter>();
        Assert.IsNotNull(contentSizeFitter);
        Assert.AreEqual(UI.ContentSizeFitter.FitMode.PreferredSize, contentSizeFitter.horizontalFit);
        Assert.IsNotNull(aspectRatioFitter);
        Assert.AreEqual(UI.AspectRatioFitter.AspectMode.WidthControlsHeight, aspectRatioFitter.aspectMode);
        Assert.AreEqual(1.5f, aspectRatioFitter.aspectRatio);
    }

    [UnityTest]
    public IEnumerator TestCanvasGroupAttributeAddsCanvasGroup()
    {
        yield return UITest(_ => new Button(new IAttribute<UnityGameObject>[] {
            new Veauty.uGUI.CanvasGroup.Alpha(0.5f),
            new Veauty.uGUI.CanvasGroup.Interactable(false),
            new Veauty.uGUI.CanvasGroup.BlocksRaycasts(false),
            new Veauty.uGUI.CanvasGroup.IgnoreParentGroups(true)
        }), typeof(UI.Button));

        var canvasGroup = UnityObject.FindAnyObjectByType<UI.Button>().GetComponent<UnityEngine.CanvasGroup>();
        Assert.IsNotNull(canvasGroup);
        Assert.AreEqual(0.5f, canvasGroup.alpha);
        Assert.IsFalse(canvasGroup.interactable);
        Assert.IsFalse(canvasGroup.blocksRaycasts);
        Assert.IsTrue(canvasGroup.ignoreParentGroups);
    }

    [UnityTest]
    public IEnumerator TestCanvasElementAppliesCanvasProperties()
    {
        var rendered = GameObjectRenderer.Render(new Veauty.uGUI.Canvas(new IAttribute<UnityGameObject>[] {
            new Veauty.uGUI.Canvas.RenderMode(UnityEngine.RenderMode.WorldSpace),
            new Veauty.uGUI.Canvas.PlaneDistance(5f),
            new Veauty.uGUI.Canvas.PixelPerfect(true),
            new Veauty.uGUI.Canvas.SortingOrder(42),
            new Veauty.uGUI.Canvas.UpdateRectTransformForStandalone(UnityEngine.StandaloneRenderResize.Enabled)
        }), true);
        var canvas = rendered.GetComponent<UnityEngine.Canvas>();
        Assert.AreEqual(UnityEngine.RenderMode.WorldSpace, canvas.renderMode);
        Assert.AreEqual(5f, canvas.planeDistance);
        Assert.IsTrue(canvas.pixelPerfect);
        Assert.AreEqual(42, canvas.sortingOrder);
        Assert.AreEqual(UnityEngine.StandaloneRenderResize.Enabled, canvas.updateRectTransformForStandalone);

        rendered.transform.SetParent(this.root.transform, false);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestCompositeUIBuildsTodoList()
    {
        System.Action<TodoState> setState = null;

        _ = new VeautyObject<TodoState>(
            this.root,
            (state, set) =>
            {
                setState = set;

                var headerRow = new HorizontalLayoutGroup(
                    new IAttribute<UnityGameObject>[] {
                        new HorizontalLayoutGroup.Spacing(8f),
                        new HorizontalLayoutGroup.ChildControlWidth(true),
                        new HorizontalLayoutGroup.ChildForceExpandWidth(true),
                        new LayoutElement.PreferredHeight(48f)
                    },
                    new Text(new IAttribute<UnityGameObject>[] {
                        new Text.Value("TODO"),
                        new Text.FontSize(24),
                        new Graphic.Color(Color.white)
                    }),
                    new Button(new IAttribute<UnityGameObject>[] {
                        new Button.OnClick(() => set(new TodoState {
                            Items = state.Items,
                            SelectedIndex = -1
                        }))
                    },
                        new Text(new IAttribute<UnityGameObject>[] {
                            new Text.Value("Clear Selection")
                        })
                    )
                );

                var items = new IVTree[state.Items.Length];
                for (int i = 0; i < state.Items.Length; i++)
                {
                    var idx = i;
                    var isSelected = state.SelectedIndex == i;
                    items[i] = new Button(
                        new IAttribute<UnityGameObject>[] {
                            new Button.OnClick(() => set(new TodoState {
                                Items = state.Items,
                                SelectedIndex = idx
                            })),
                            new LayoutElement.PreferredHeight(36f)
                        },
                        new Image(new IAttribute<UnityGameObject>[] {
                            new Graphic.Color(isSelected ? new Color(0.2f, 0.6f, 1f) : Color.gray)
                        }),
                        new Text(new IAttribute<UnityGameObject>[] {
                            new Text.Value(state.Items[i]),
                            new Text.FontSize(18),
                            new Graphic.Color(Color.black)
                        })
                    );
                }

                var listBody = new VerticalLayoutGroup(
                    new IAttribute<UnityGameObject>[] {
                        new VerticalLayoutGroup.Padding(new RectOffset(8, 8, 4, 4)),
                        new VerticalLayoutGroup.Spacing(4f),
                        new VerticalLayoutGroup.ChildControlWidth(true),
                        new VerticalLayoutGroup.ChildForceExpandHeight(false)
                    },
                    items
                );

                return new VerticalLayoutGroup(
                    new IAttribute<UnityGameObject>[] {
                        new VerticalLayoutGroup.Spacing(0f),
                        new VerticalLayoutGroup.ChildControlWidth(true),
                        new VerticalLayoutGroup.ChildForceExpandHeight(false),
                        new Veauty.uGUI.RectTransform.AnchorMin(Vector2.zero),
                        new Veauty.uGUI.RectTransform.AnchorMax(Vector2.one),
                        new Veauty.uGUI.RectTransform.OffsetMin(Vector2.zero),
                        new Veauty.uGUI.RectTransform.OffsetMax(Vector2.zero)
                    },
                    headerRow,
                    listBody
                );
            },
            new TodoState {
                Items = new[] { "Buy milk", "Write tests", "Ship feature" },
                SelectedIndex = -1
            }
        );

        yield return null;

        var texts = UnityObject.FindObjectsByType<UI.Text>(FindObjectsSortMode.None);
        Assert.IsTrue(texts.Any(t => t.text == "TODO"));
        Assert.IsTrue(texts.Any(t => t.text == "Buy milk"));
        Assert.IsTrue(texts.Any(t => t.text == "Write tests"));
        Assert.IsTrue(texts.Any(t => t.text == "Ship feature"));
        Assert.IsTrue(texts.Any(t => t.text == "Clear Selection"));

        var layouts = UnityObject.FindObjectsByType<UI.VerticalLayoutGroup>(FindObjectsSortMode.None);
        Assert.IsTrue(layouts.Length >= 2);

        var headerLayout = UnityObject.FindAnyObjectByType<UI.HorizontalLayoutGroup>();
        Assert.IsNotNull(headerLayout);
        Assert.AreEqual(8f, headerLayout.spacing);

        setState(new TodoState {
            Items = new[] { "Buy milk", "Write tests", "Ship feature" },
            SelectedIndex = 1
        });
        yield return null;

        var images = UnityObject.FindObjectsByType<UI.Image>(FindObjectsSortMode.None);
        var selectedImage = images.FirstOrDefault(img =>
            img.color == new Color(0.2f, 0.6f, 1f));
        Assert.IsNotNull(selectedImage, "Selected item should have highlight color");

        var grayImages = images.Where(img => img.color == Color.gray).ToArray();
        Assert.AreEqual(2, grayImages.Length, "Non-selected items should be gray");
    }

    private static IAttribute<UnityGameObject>[] NoAttrs()
    {
        return new IAttribute<UnityGameObject>[] {};
    }

    private struct CounterState
    {
        public int Count;
    }

    private struct TodoState
    {
        public string[] Items;
        public int SelectedIndex;
    }
}
