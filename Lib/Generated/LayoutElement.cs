
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class LayoutElementAttribute<T> : GuiAttributeBase<UnityEngine.UI.LayoutElement, T>
    {
        protected LayoutElementAttribute(string key, T value) : base(key, value) { }
    }

    public partial class LayoutElement : GUIBase<UnityEngine.UI.LayoutElement>
    {
        public LayoutElement(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class IgnoreLayout : LayoutElementAttribute<System.Boolean>
        {
            public IgnoreLayout(System.Boolean value): base("ignoreLayout", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.ignoreLayout = this.GetValue();
            }
        }

        public partial class MinWidth : LayoutElementAttribute<System.Single>
        {
            public MinWidth(System.Single value): base("minWidth", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.minWidth = this.GetValue();
            }
        }

        public partial class MinHeight : LayoutElementAttribute<System.Single>
        {
            public MinHeight(System.Single value): base("minHeight", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.minHeight = this.GetValue();
            }
        }

        public partial class PreferredWidth : LayoutElementAttribute<System.Single>
        {
            public PreferredWidth(System.Single value): base("preferredWidth", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.preferredWidth = this.GetValue();
            }
        }

        public partial class PreferredHeight : LayoutElementAttribute<System.Single>
        {
            public PreferredHeight(System.Single value): base("preferredHeight", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.preferredHeight = this.GetValue();
            }
        }

        public partial class FlexibleWidth : LayoutElementAttribute<System.Single>
        {
            public FlexibleWidth(System.Single value): base("flexibleWidth", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.flexibleWidth = this.GetValue();
            }
        }

        public partial class FlexibleHeight : LayoutElementAttribute<System.Single>
        {
            public FlexibleHeight(System.Single value): base("flexibleHeight", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.flexibleHeight = this.GetValue();
            }
        }

        public partial class LayoutPriority : LayoutElementAttribute<System.Int32>
        {
            public LayoutPriority(System.Int32 value): base("layoutPriority", value) {}
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.layoutPriority = this.GetValue();
            }
        }
    }
}