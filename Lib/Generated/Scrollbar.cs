
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class ScrollbarAttribute<T> : GuiAttributeBase<UnityEngine.UI.Scrollbar, T>
    {
        protected ScrollbarAttribute(string key, T value) : base(key, value) { }
    }

    public class Scrollbar : GUIBase<UnityEngine.UI.Scrollbar>
    {
        public Scrollbar(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var scrollbar = go.GetComponent<UnityEngine.UI.Scrollbar>();
            var bgImage = go.GetComponent<UnityEngine.UI.Image>();
            if (bgImage == null) { go.AddComponent<UnityEngine.CanvasRenderer>(); bgImage = go.AddComponent<UnityEngine.UI.Image>(); }
            bgImage.color = new UnityEngine.Color(0.22f, 0.24f, 0.28f);
            var slideArea = CreateChild(go, "Sliding Area");
            Stretch(slideArea.GetComponent<UnityEngine.RectTransform>());
            var handle = CreateChild(slideArea, "Handle");
            handle.AddComponent<UnityEngine.CanvasRenderer>();
            var handleImage = handle.AddComponent<UnityEngine.UI.Image>();
            handleImage.color = new UnityEngine.Color(0.5f, 0.5f, 0.5f);
            handle.GetComponent<UnityEngine.RectTransform>().sizeDelta = UnityEngine.Vector2.zero;
            scrollbar.handleRect = handle.GetComponent<UnityEngine.RectTransform>();
            scrollbar.targetGraphic = handleImage;
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }


        public class HandleRect : ScrollbarAttribute<UnityEngine.RectTransform>
        {
            public HandleRect(UnityEngine.RectTransform value): base("handleRect", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.handleRect = this.GetValue();
            }
        }

        public class Direction : ScrollbarAttribute<UnityEngine.UI.Scrollbar.Direction>
        {
            public Direction(UnityEngine.UI.Scrollbar.Direction value): base("direction", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.direction = this.GetValue();
            }
        }

        public class Value : ScrollbarAttribute<System.Single>
        {
            public Value(System.Single value): base("value", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.value = this.GetValue();
            }
        }

        public class Size : ScrollbarAttribute<System.Single>
        {
            public Size(System.Single value): base("size", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.size = this.GetValue();
            }
        }

        public class NumberOfSteps : ScrollbarAttribute<System.Int32>
        {
            public NumberOfSteps(System.Int32 value): base("numberOfSteps", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.numberOfSteps = this.GetValue();
            }
        }

        public class OnValueChanged : ScrollbarAttribute<UnityEngine.UI.Scrollbar.ScrollEvent>
        {
            public OnValueChanged(UnityEngine.UI.Scrollbar.ScrollEvent value): base("onValueChanged", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.onValueChanged = this.GetValue();
            }
        }
    }
}