
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Scrollbar"/> attributes, targeting <see cref="UnityEngine.UI.Scrollbar"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class ScrollbarAttribute<T> : GuiAttributeBase<UnityEngine.UI.Scrollbar, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected ScrollbarAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Scrollbar"/>.</summary>
    public partial class Scrollbar : GUIBase<UnityEngine.UI.Scrollbar>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Scrollbar(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.Scrollbar.handleRect"/>.</summary>
        public class HandleRect : ScrollbarAttribute<UnityEngine.RectTransform>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>handleRect</c>.</param>
            public HandleRect(UnityEngine.RectTransform value): base("handleRect", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.handleRect = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Scrollbar.direction"/>.</summary>
        public class Direction : ScrollbarAttribute<UnityEngine.UI.Scrollbar.Direction>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>direction</c>.</param>
            public Direction(UnityEngine.UI.Scrollbar.Direction value): base("direction", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.direction = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Scrollbar.value"/>.</summary>
        public class Value : ScrollbarAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>value</c>.</param>
            public Value(System.Single value): base("value", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.value = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Scrollbar.size"/>.</summary>
        public class Size : ScrollbarAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>size</c>.</param>
            public Size(System.Single value): base("size", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.size = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Scrollbar.numberOfSteps"/>.</summary>
        public class NumberOfSteps : ScrollbarAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>numberOfSteps</c>.</param>
            public NumberOfSteps(System.Int32 value): base("numberOfSteps", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.numberOfSteps = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Scrollbar.onValueChanged"/>.</summary>
        public class OnValueChanged : ScrollbarAttribute<UnityEngine.UI.Scrollbar.ScrollEvent>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>onValueChanged</c>.</param>
            public OnValueChanged(UnityEngine.UI.Scrollbar.ScrollEvent value): base("onValueChanged", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.onValueChanged = this.GetValue();
            }
        }
    }
}