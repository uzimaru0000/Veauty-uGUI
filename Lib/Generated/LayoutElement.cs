
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class LayoutElementAttribute<T> : GuiAttributeBase<UnityEngine.UI.LayoutElement, T>
    {
        protected LayoutElementAttribute(string key, T value) : base(key, value) { }
    }

    public class LayoutElement : GUIBase<UnityEngine.UI.LayoutElement>
    {
        public LayoutElement(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class IgnoreLayout : LayoutElementAttribute<System.Boolean>
        {
            public IgnoreLayout(System.Boolean value): base("ignoreLayout", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.ignoreLayout = this.GetValue();
            }
        }

        public class MinWidth : LayoutElementAttribute<System.Single>
        {
            public MinWidth(System.Single value): base("minWidth", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.minWidth = this.GetValue();
            }
        }

        public class MinHeight : LayoutElementAttribute<System.Single>
        {
            public MinHeight(System.Single value): base("minHeight", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.minHeight = this.GetValue();
            }
        }

        public class PreferredWidth : LayoutElementAttribute<System.Single>
        {
            public PreferredWidth(System.Single value): base("preferredWidth", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.preferredWidth = this.GetValue();
            }
        }

        public class PreferredHeight : LayoutElementAttribute<System.Single>
        {
            public PreferredHeight(System.Single value): base("preferredHeight", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.preferredHeight = this.GetValue();
            }
        }

        public class FlexibleWidth : LayoutElementAttribute<System.Single>
        {
            public FlexibleWidth(System.Single value): base("flexibleWidth", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.flexibleWidth = this.GetValue();
            }
        }

        public class FlexibleHeight : LayoutElementAttribute<System.Single>
        {
            public FlexibleHeight(System.Single value): base("flexibleHeight", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.flexibleHeight = this.GetValue();
            }
        }

        public class LayoutPriority : LayoutElementAttribute<System.Int32>
        {
            public LayoutPriority(System.Int32 value): base("layoutPriority", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.layoutPriority = this.GetValue();
            }
        }

    }
}