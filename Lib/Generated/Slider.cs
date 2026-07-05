
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Slider"/> attributes, targeting <see cref="UnityEngine.UI.Slider"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class SliderAttribute<T> : GuiAttributeBase<UnityEngine.UI.Slider, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected SliderAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Slider"/>.</summary>
    public partial class Slider : GUIBase<UnityEngine.UI.Slider>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Slider(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.Slider.fillRect"/>.</summary>
        public class FillRect : SliderAttribute<UnityEngine.RectTransform>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>fillRect</c>.</param>
            public FillRect(UnityEngine.RectTransform value): base("fillRect", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.fillRect = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Slider.handleRect"/>.</summary>
        public class HandleRect : SliderAttribute<UnityEngine.RectTransform>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>handleRect</c>.</param>
            public HandleRect(UnityEngine.RectTransform value): base("handleRect", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.handleRect = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Slider.direction"/>.</summary>
        public class Direction : SliderAttribute<UnityEngine.UI.Slider.Direction>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>direction</c>.</param>
            public Direction(UnityEngine.UI.Slider.Direction value): base("direction", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.direction = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Slider.minValue"/>.</summary>
        public class MinValue : SliderAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>minValue</c>.</param>
            public MinValue(System.Single value): base("minValue", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.minValue = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Slider.maxValue"/>.</summary>
        public class MaxValue : SliderAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>maxValue</c>.</param>
            public MaxValue(System.Single value): base("maxValue", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.maxValue = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Slider.wholeNumbers"/>.</summary>
        public class WholeNumbers : SliderAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>wholeNumbers</c>.</param>
            public WholeNumbers(System.Boolean value): base("wholeNumbers", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.wholeNumbers = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Slider.value"/>.</summary>
        public class Value : SliderAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>value</c>.</param>
            public Value(System.Single value): base("value", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.value = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Slider.normalizedValue"/>.</summary>
        public class NormalizedValue : SliderAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>normalizedValue</c>.</param>
            public NormalizedValue(System.Single value): base("normalizedValue", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.normalizedValue = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Slider.onValueChanged"/>.</summary>
        public class OnValueChanged : SliderAttribute<UnityEngine.UI.Slider.SliderEvent>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>onValueChanged</c>.</param>
            public OnValueChanged(UnityEngine.UI.Slider.SliderEvent value): base("onValueChanged", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Slider component)
            {
                component.onValueChanged = this.GetValue();
            }
        }
    }
}