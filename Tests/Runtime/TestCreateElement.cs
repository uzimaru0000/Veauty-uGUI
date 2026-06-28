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
        var canvas = this.root.AddComponent<Canvas>();
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
    public IEnumerator TestLayoutElementAttributeAddsLayoutElement()
    {
        yield return UITest(_ => new Button(new IAttribute<UnityGameObject>[] {
            new LayoutElement.PreferredHeight(88f)
        }), typeof(UI.Button));

        var layoutElement = UnityObject.FindAnyObjectByType<UI.Button>().GetComponent<UI.LayoutElement>();
        Assert.IsNotNull(layoutElement);
        Assert.AreEqual(88f, layoutElement.preferredHeight);
    }

    private static IAttribute<UnityGameObject>[] NoAttrs()
    {
        return new IAttribute<UnityGameObject>[] {};
    }

    private struct CounterState
    {
        public int Count;
    }
}
