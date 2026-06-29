
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class SliderAttribute<T> : GuiAttributeBase<UnityEngine.UI.Slider, T>
    {
        protected SliderAttribute(string key, T value) : base(key, value) { }
    }

    public class Slider : GUIBase<UnityEngine.UI.Slider>
    {
        public Slider(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var slider = go.GetComponent<UnityEngine.UI.Slider>();
            var bg = CreateChild(go, "Background");
            bg.AddComponent<UnityEngine.CanvasRenderer>();
            var bgImage = bg.AddComponent<UnityEngine.UI.Image>();
            bgImage.color = new UnityEngine.Color(0.30f, 0.32f, 0.38f);
            Stretch(bg.GetComponent<UnityEngine.RectTransform>());
            var fillArea = CreateChild(go, "Fill Area");
            var fillAreaRect = fillArea.GetComponent<UnityEngine.RectTransform>();
            fillAreaRect.anchorMin = new UnityEngine.Vector2(0f, 0.25f);
            fillAreaRect.anchorMax = new UnityEngine.Vector2(1f, 0.75f);
            fillAreaRect.offsetMin = new UnityEngine.Vector2(5f, 0f);
            fillAreaRect.offsetMax = new UnityEngine.Vector2(-5f, 0f);
            var fill = CreateChild(fillArea, "Fill");
            fill.AddComponent<UnityEngine.CanvasRenderer>();
            var fillImage = fill.AddComponent<UnityEngine.UI.Image>();
            fillImage.color = new UnityEngine.Color(0.22f, 0.55f, 0.95f);
            fill.GetComponent<UnityEngine.RectTransform>().sizeDelta = UnityEngine.Vector2.zero;
            slider.fillRect = fill.GetComponent<UnityEngine.RectTransform>();
            var handleArea = CreateChild(go, "Handle Slide Area");
            var handleAreaRect = handleArea.GetComponent<UnityEngine.RectTransform>();
            handleAreaRect.anchorMin = UnityEngine.Vector2.zero;
            handleAreaRect.anchorMax = UnityEngine.Vector2.one;
            handleAreaRect.offsetMin = new UnityEngine.Vector2(10f, 0f);
            handleAreaRect.offsetMax = new UnityEngine.Vector2(-10f, 0f);
            var handle = CreateChild(handleArea, "Handle");
            handle.AddComponent<UnityEngine.CanvasRenderer>();
            var handleImage = handle.AddComponent<UnityEngine.UI.Image>();
            handleImage.color = UnityEngine.Color.white;
            handle.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2(20f, 0f);
            slider.handleRect = handle.GetComponent<UnityEngine.RectTransform>();
            slider.targetGraphic = handleImage;
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }


        public class FillRect : SliderAttribute<UnityEngine.RectTransform>
        {
            public FillRect(UnityEngine.RectTransform value): base("fillRect", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.fillRect = this.GetValue();
            }
        }

        public class HandleRect : SliderAttribute<UnityEngine.RectTransform>
        {
            public HandleRect(UnityEngine.RectTransform value): base("handleRect", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.handleRect = this.GetValue();
            }
        }

        public class Direction : SliderAttribute<UnityEngine.UI.Slider.Direction>
        {
            public Direction(UnityEngine.UI.Slider.Direction value): base("direction", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.direction = this.GetValue();
            }
        }

        public class MinValue : SliderAttribute<System.Single>
        {
            public MinValue(System.Single value): base("minValue", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.minValue = this.GetValue();
            }
        }

        public class MaxValue : SliderAttribute<System.Single>
        {
            public MaxValue(System.Single value): base("maxValue", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.maxValue = this.GetValue();
            }
        }

        public class WholeNumbers : SliderAttribute<System.Boolean>
        {
            public WholeNumbers(System.Boolean value): base("wholeNumbers", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.wholeNumbers = this.GetValue();
            }
        }

        public class Value : SliderAttribute<System.Single>
        {
            public Value(System.Single value): base("value", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.value = this.GetValue();
            }
        }

        public class NormalizedValue : SliderAttribute<System.Single>
        {
            public NormalizedValue(System.Single value): base("normalizedValue", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.normalizedValue = this.GetValue();
            }
        }

        public class OnValueChanged : SliderAttribute<UnityEngine.UI.Slider.SliderEvent>
        {
            public OnValueChanged(UnityEngine.UI.Slider.SliderEvent value): base("onValueChanged", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.onValueChanged = this.GetValue();
            }
        }
    }
}