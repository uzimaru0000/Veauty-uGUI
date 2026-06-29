
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class LayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.LayoutGroup, T>
    {
        protected LayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    public partial class LayoutGroup : GUIBase<UnityEngine.UI.LayoutGroup>
    {
        public LayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class Padding : LayoutGroupAttribute<UnityEngine.RectOffset>
        {
            public Padding(UnityEngine.RectOffset value): base("padding", value) {}
            protected override void Apply(UnityEngine.UI.LayoutGroup component)
            {
                component.padding = this.GetValue();
            }
        }

        public partial class ChildAlignment : LayoutGroupAttribute<UnityEngine.TextAnchor>
        {
            public ChildAlignment(UnityEngine.TextAnchor value): base("childAlignment", value) {}
            protected override void Apply(UnityEngine.UI.LayoutGroup component)
            {
                component.childAlignment = this.GetValue();
            }
        }
    }
}