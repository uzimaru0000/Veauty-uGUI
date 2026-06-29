
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class ToggleAttribute<T> : GuiAttributeBase<UnityEngine.UI.Toggle, T>
    {
        protected ToggleAttribute(string key, T value) : base(key, value) { }
    }

    public partial class Toggle : GUIBase<UnityEngine.UI.Toggle>
    {
        public Toggle(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class Group : ToggleAttribute<UnityEngine.UI.ToggleGroup>
        {
            public Group(UnityEngine.UI.ToggleGroup value): base("group", value) {}
            protected override void Apply(UnityEngine.UI.Toggle component)
            {
                component.group = this.GetValue();
            }
        }

        public partial class IsOn : ToggleAttribute<System.Boolean>
        {
            public IsOn(System.Boolean value): base("isOn", value) {}
            protected override void Apply(UnityEngine.UI.Toggle component)
            {
                component.isOn = this.GetValue();
            }
        }
    }
}