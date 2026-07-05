
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="ScrollRect"/> attributes, targeting <see cref="UnityEngine.UI.ScrollRect"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class ScrollRectAttribute<T> : GuiAttributeBase<UnityEngine.UI.ScrollRect, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected ScrollRectAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.ScrollRect"/>.</summary>
    public partial class ScrollRect : GUIBase<UnityEngine.UI.ScrollRect>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public ScrollRect(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.content"/>.</summary>
        public class Content : ScrollRectAttribute<UnityEngine.RectTransform>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>content</c>.</param>
            public Content(UnityEngine.RectTransform value): base("content", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.content = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.horizontal"/>.</summary>
        public class Horizontal : ScrollRectAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>horizontal</c>.</param>
            public Horizontal(System.Boolean value): base("horizontal", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.horizontal = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.vertical"/>.</summary>
        public class Vertical : ScrollRectAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>vertical</c>.</param>
            public Vertical(System.Boolean value): base("vertical", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.vertical = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.movementType"/>.</summary>
        public class MovementType : ScrollRectAttribute<UnityEngine.UI.ScrollRect.MovementType>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>movementType</c>.</param>
            public MovementType(UnityEngine.UI.ScrollRect.MovementType value): base("movementType", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.movementType = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.elasticity"/>.</summary>
        public class Elasticity : ScrollRectAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>elasticity</c>.</param>
            public Elasticity(System.Single value): base("elasticity", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.elasticity = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.inertia"/>.</summary>
        public class Inertia : ScrollRectAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>inertia</c>.</param>
            public Inertia(System.Boolean value): base("inertia", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.inertia = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.decelerationRate"/>.</summary>
        public class DecelerationRate : ScrollRectAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>decelerationRate</c>.</param>
            public DecelerationRate(System.Single value): base("decelerationRate", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.decelerationRate = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.scrollSensitivity"/>.</summary>
        public class ScrollSensitivity : ScrollRectAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>scrollSensitivity</c>.</param>
            public ScrollSensitivity(System.Single value): base("scrollSensitivity", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.scrollSensitivity = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.viewport"/>.</summary>
        public class Viewport : ScrollRectAttribute<UnityEngine.RectTransform>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>viewport</c>.</param>
            public Viewport(UnityEngine.RectTransform value): base("viewport", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.viewport = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.horizontalScrollbar"/>.</summary>
        public class HorizontalScrollbar : ScrollRectAttribute<UnityEngine.UI.Scrollbar>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>horizontalScrollbar</c>.</param>
            public HorizontalScrollbar(UnityEngine.UI.Scrollbar value): base("horizontalScrollbar", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.horizontalScrollbar = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.verticalScrollbar"/>.</summary>
        public class VerticalScrollbar : ScrollRectAttribute<UnityEngine.UI.Scrollbar>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>verticalScrollbar</c>.</param>
            public VerticalScrollbar(UnityEngine.UI.Scrollbar value): base("verticalScrollbar", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.verticalScrollbar = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.horizontalScrollbarVisibility"/>.</summary>
        public class HorizontalScrollbarVisibility : ScrollRectAttribute<UnityEngine.UI.ScrollRect.ScrollbarVisibility>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>horizontalScrollbarVisibility</c>.</param>
            public HorizontalScrollbarVisibility(UnityEngine.UI.ScrollRect.ScrollbarVisibility value): base("horizontalScrollbarVisibility", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.horizontalScrollbarVisibility = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.verticalScrollbarVisibility"/>.</summary>
        public class VerticalScrollbarVisibility : ScrollRectAttribute<UnityEngine.UI.ScrollRect.ScrollbarVisibility>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>verticalScrollbarVisibility</c>.</param>
            public VerticalScrollbarVisibility(UnityEngine.UI.ScrollRect.ScrollbarVisibility value): base("verticalScrollbarVisibility", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.verticalScrollbarVisibility = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.horizontalScrollbarSpacing"/>.</summary>
        public class HorizontalScrollbarSpacing : ScrollRectAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>horizontalScrollbarSpacing</c>.</param>
            public HorizontalScrollbarSpacing(System.Single value): base("horizontalScrollbarSpacing", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.horizontalScrollbarSpacing = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.verticalScrollbarSpacing"/>.</summary>
        public class VerticalScrollbarSpacing : ScrollRectAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>verticalScrollbarSpacing</c>.</param>
            public VerticalScrollbarSpacing(System.Single value): base("verticalScrollbarSpacing", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.verticalScrollbarSpacing = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.onValueChanged"/>.</summary>
        public class OnValueChanged : ScrollRectAttribute<UnityEngine.UI.ScrollRect.ScrollRectEvent>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>onValueChanged</c>.</param>
            public OnValueChanged(UnityEngine.UI.ScrollRect.ScrollRectEvent value): base("onValueChanged", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.onValueChanged = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.velocity"/>.</summary>
        public class Velocity : ScrollRectAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>velocity</c>.</param>
            public Velocity(UnityEngine.Vector2 value): base("velocity", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.velocity = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.normalizedPosition"/>.</summary>
        public class NormalizedPosition : ScrollRectAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>normalizedPosition</c>.</param>
            public NormalizedPosition(UnityEngine.Vector2 value): base("normalizedPosition", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.normalizedPosition = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.horizontalNormalizedPosition"/>.</summary>
        public class HorizontalNormalizedPosition : ScrollRectAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>horizontalNormalizedPosition</c>.</param>
            public HorizontalNormalizedPosition(System.Single value): base("horizontalNormalizedPosition", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.horizontalNormalizedPosition = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ScrollRect.verticalNormalizedPosition"/>.</summary>
        public class VerticalNormalizedPosition : ScrollRectAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>verticalNormalizedPosition</c>.</param>
            public VerticalNormalizedPosition(System.Single value): base("verticalNormalizedPosition", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.verticalNormalizedPosition = this.GetValue();
            }
        }
    }
}