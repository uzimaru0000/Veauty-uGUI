using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UI = UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;
using Veauty;
using Veauty.GameObject;
using Veauty.uGUI;

struct Unit {}

public class TestCreateElement
{
    GameObject root;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var cam = new GameObject();
        cam.AddComponent<Camera>();

        root = new GameObject("root");
        var canv = root.AddComponent<Canvas>();
        canv.renderMode = RenderMode.ScreenSpaceOverlay;
        canv.targetDisplay = 0;
        var scaler = root.AddComponent<UI.CanvasScaler>();
        scaler.uiScaleMode = UI.CanvasScaler.ScaleMode.ConstantPixelSize;
        scaler.scaleFactor = 1;
        scaler.referencePixelsPerUnit = 100;
        root.AddComponent<UI.GraphicRaycaster>();

        var eventSystem = new GameObject("EventSystem");
        eventSystem.AddComponent<EventSystem>();
    }

    VeautyObject<Unit> CreateVeauty(System.Func<Unit, Veauty.IVTree> func)
    {
        return new VeautyObject<Unit>(root, func);
    }

    IEnumerator UITest(System.Func<Unit, Veauty.IVTree> func, params System.Type[] uiComponentTypes)
    {
        var veauty = CreateVeauty(func);
        yield return null;

        uiComponentTypes.ToList().ForEach(x => {
            var comp = GameObject.FindObjectOfType(x);
            Assert.IsNotNull(comp);
        });
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestCreateButtonElement()
    {
        var state = false;

        yield return UITest(_ => new Button(new IAttribute<GameObject>[] {
            new Button.OnClick(() => state = true)
        }), typeof(UI.Button));

        ExecuteEvents.Execute(
            target: GameObject.FindObjectOfType<UI.Button>().gameObject, 
            eventData: new PointerEventData(EventSystem.current),
            functor: ExecuteEvents.pointerClickHandler
        );
        yield return null;

        Assert.True(state);
    }

    [UnityTest]
    public IEnumerator TestCreateTextElement()
    {
        yield return UITest(_ => new Text(new IAttribute<GameObject>[] {
            new Text.Value("Hello")
        }), typeof(UI.Text));

        var text = GameObject.FindObjectOfType<UI.Text>();
        Assert.AreEqual(text.text, "Hello");
    }
}
