
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class SliderAttribute<T> : GuiAttributeBase<UnityEngine.UI.Slider, T>
    {
        protected SliderAttribute(string key, T value) : base(key, value) { }
    }

    public partial class Slider : GUIBase<UnityEngine.UI.Slider>
    {
        public Slider(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class FillRect : SliderAttribute<UnityEngine.RectTransform>
        {
            public FillRect(UnityEngine.RectTransform value): base("fillRect", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.fillRect = this.GetValue();
            }
        }

        public partial class HandleRect : SliderAttribute<UnityEngine.RectTransform>
        {
            public HandleRect(UnityEngine.RectTransform value): base("handleRect", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.handleRect = this.GetValue();
            }
        }

        public partial class Direction : SliderAttribute<UnityEngine.UI.Slider.Direction>
        {
            public Direction(UnityEngine.UI.Slider.Direction value): base("direction", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.direction = this.GetValue();
            }
        }

        public partial class MinValue : SliderAttribute<System.Single>
        {
            public MinValue(System.Single value): base("minValue", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.minValue = this.GetValue();
            }
        }

        public partial class MaxValue : SliderAttribute<System.Single>
        {
            public MaxValue(System.Single value): base("maxValue", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.maxValue = this.GetValue();
            }
        }

        public partial class WholeNumbers : SliderAttribute<System.Boolean>
        {
            public WholeNumbers(System.Boolean value): base("wholeNumbers", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.wholeNumbers = this.GetValue();
            }
        }

        public partial class Value : SliderAttribute<System.Single>
        {
            public Value(System.Single value): base("value", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.value = this.GetValue();
            }
        }

        public partial class NormalizedValue : SliderAttribute<System.Single>
        {
            public NormalizedValue(System.Single value): base("normalizedValue", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.normalizedValue = this.GetValue();
            }
        }

        public partial class OnValueChanged : SliderAttribute<UnityEngine.UI.Slider.SliderEvent>
        {
            public OnValueChanged(UnityEngine.UI.Slider.SliderEvent value): base("onValueChanged", value) {}
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.onValueChanged = this.GetValue();
            }
        }
    }
}