
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class ScrollbarAttribute<T> : GuiAttributeBase<UnityEngine.UI.Scrollbar, T>
    {
        protected ScrollbarAttribute(string key, T value) : base(key, value) { }
    }

    public partial class Scrollbar : GUIBase<UnityEngine.UI.Scrollbar>
    {
        public Scrollbar(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class HandleRect : ScrollbarAttribute<UnityEngine.RectTransform>
        {
            public HandleRect(UnityEngine.RectTransform value): base("handleRect", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.handleRect = this.GetValue();
            }
        }

        public partial class Direction : ScrollbarAttribute<UnityEngine.UI.Scrollbar.Direction>
        {
            public Direction(UnityEngine.UI.Scrollbar.Direction value): base("direction", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.direction = this.GetValue();
            }
        }

        public partial class Value : ScrollbarAttribute<System.Single>
        {
            public Value(System.Single value): base("value", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.value = this.GetValue();
            }
        }

        public partial class Size : ScrollbarAttribute<System.Single>
        {
            public Size(System.Single value): base("size", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.size = this.GetValue();
            }
        }

        public partial class NumberOfSteps : ScrollbarAttribute<System.Int32>
        {
            public NumberOfSteps(System.Int32 value): base("numberOfSteps", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.numberOfSteps = this.GetValue();
            }
        }

        public partial class OnValueChanged : ScrollbarAttribute<UnityEngine.UI.Scrollbar.ScrollEvent>
        {
            public OnValueChanged(UnityEngine.UI.Scrollbar.ScrollEvent value): base("onValueChanged", value) {}
            protected override void Apply(UnityEngine.UI.Scrollbar component)
            {
                component.onValueChanged = this.GetValue();
            }
        }
    }
}