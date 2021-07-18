
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class LayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.LayoutGroup, T>
    {
        protected LayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    public class LayoutGroup : GUIBase<UnityEngine.UI.LayoutGroup>
    {
        public LayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Padding : LayoutGroupAttribute<UnityEngine.RectOffset>
        {
            public Padding(UnityEngine.RectOffset value): base("padding", value) {}
            protected override void Apply(UnityEngine.UI.LayoutGroup component)
            {
                component.padding = this.GetValue();
            }
        }

        public class ChildAlignment : LayoutGroupAttribute<UnityEngine.TextAnchor>
        {
            public ChildAlignment(UnityEngine.TextAnchor value): base("childAlignment", value) {}
            protected override void Apply(UnityEngine.UI.LayoutGroup component)
            {
                component.childAlignment = this.GetValue();
            }
        }

    }
}