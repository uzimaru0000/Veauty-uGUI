
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class ScrollRectAttribute<T> : GuiAttributeBase<UnityEngine.UI.ScrollRect, T>
    {
        protected ScrollRectAttribute(string key, T value) : base(key, value) { }
    }

    public class ScrollRect : GUIBase<UnityEngine.UI.ScrollRect>
    {
        public ScrollRect(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Content : ScrollRectAttribute<UnityEngine.RectTransform>
        {
            public Content(UnityEngine.RectTransform value): base("content", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.content = this.GetValue();
            }
        }

        public class Horizontal : ScrollRectAttribute<System.Boolean>
        {
            public Horizontal(System.Boolean value): base("horizontal", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.horizontal = this.GetValue();
            }
        }

        public class Vertical : ScrollRectAttribute<System.Boolean>
        {
            public Vertical(System.Boolean value): base("vertical", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.vertical = this.GetValue();
            }
        }

        public class MovementType : ScrollRectAttribute<UnityEngine.UI.ScrollRect.MovementType>
        {
            public MovementType(UnityEngine.UI.ScrollRect.MovementType value): base("movementType", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.movementType = this.GetValue();
            }
        }

        public class Elasticity : ScrollRectAttribute<System.Single>
        {
            public Elasticity(System.Single value): base("elasticity", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.elasticity = this.GetValue();
            }
        }

        public class Inertia : ScrollRectAttribute<System.Boolean>
        {
            public Inertia(System.Boolean value): base("inertia", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.inertia = this.GetValue();
            }
        }

        public class DecelerationRate : ScrollRectAttribute<System.Single>
        {
            public DecelerationRate(System.Single value): base("decelerationRate", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.decelerationRate = this.GetValue();
            }
        }

        public class ScrollSensitivity : ScrollRectAttribute<System.Single>
        {
            public ScrollSensitivity(System.Single value): base("scrollSensitivity", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.scrollSensitivity = this.GetValue();
            }
        }

        public class Viewport : ScrollRectAttribute<UnityEngine.RectTransform>
        {
            public Viewport(UnityEngine.RectTransform value): base("viewport", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.viewport = this.GetValue();
            }
        }

        public class HorizontalScrollbar : ScrollRectAttribute<UnityEngine.UI.Scrollbar>
        {
            public HorizontalScrollbar(UnityEngine.UI.Scrollbar value): base("horizontalScrollbar", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.horizontalScrollbar = this.GetValue();
            }
        }

        public class VerticalScrollbar : ScrollRectAttribute<UnityEngine.UI.Scrollbar>
        {
            public VerticalScrollbar(UnityEngine.UI.Scrollbar value): base("verticalScrollbar", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.verticalScrollbar = this.GetValue();
            }
        }

        public class HorizontalScrollbarVisibility : ScrollRectAttribute<UnityEngine.UI.ScrollRect.ScrollbarVisibility>
        {
            public HorizontalScrollbarVisibility(UnityEngine.UI.ScrollRect.ScrollbarVisibility value): base("horizontalScrollbarVisibility", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.horizontalScrollbarVisibility = this.GetValue();
            }
        }

        public class VerticalScrollbarVisibility : ScrollRectAttribute<UnityEngine.UI.ScrollRect.ScrollbarVisibility>
        {
            public VerticalScrollbarVisibility(UnityEngine.UI.ScrollRect.ScrollbarVisibility value): base("verticalScrollbarVisibility", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.verticalScrollbarVisibility = this.GetValue();
            }
        }

        public class HorizontalScrollbarSpacing : ScrollRectAttribute<System.Single>
        {
            public HorizontalScrollbarSpacing(System.Single value): base("horizontalScrollbarSpacing", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.horizontalScrollbarSpacing = this.GetValue();
            }
        }

        public class VerticalScrollbarSpacing : ScrollRectAttribute<System.Single>
        {
            public VerticalScrollbarSpacing(System.Single value): base("verticalScrollbarSpacing", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.verticalScrollbarSpacing = this.GetValue();
            }
        }

        public class OnValueChanged : ScrollRectAttribute<UnityEngine.UI.ScrollRect.ScrollRectEvent>
        {
            public OnValueChanged(UnityEngine.UI.ScrollRect.ScrollRectEvent value): base("onValueChanged", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.onValueChanged = this.GetValue();
            }
        }

        public class Velocity : ScrollRectAttribute<UnityEngine.Vector2>
        {
            public Velocity(UnityEngine.Vector2 value): base("velocity", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.velocity = this.GetValue();
            }
        }

        public class NormalizedPosition : ScrollRectAttribute<UnityEngine.Vector2>
        {
            public NormalizedPosition(UnityEngine.Vector2 value): base("normalizedPosition", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.normalizedPosition = this.GetValue();
            }
        }

        public class HorizontalNormalizedPosition : ScrollRectAttribute<System.Single>
        {
            public HorizontalNormalizedPosition(System.Single value): base("horizontalNormalizedPosition", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.horizontalNormalizedPosition = this.GetValue();
            }
        }

        public class VerticalNormalizedPosition : ScrollRectAttribute<System.Single>
        {
            public VerticalNormalizedPosition(System.Single value): base("verticalNormalizedPosition", value) {}
            protected override void Apply(UnityEngine.UI.ScrollRect component)
            {
                component.verticalNormalizedPosition = this.GetValue();
            }
        }

    }
}