
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

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