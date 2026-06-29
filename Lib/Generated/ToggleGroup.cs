
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class ToggleGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.ToggleGroup, T>
    {
        protected ToggleGroupAttribute(string key, T value) : base(key, value) { }
    }

    public partial class ToggleGroup : GUIBase<UnityEngine.UI.ToggleGroup>
    {
        public ToggleGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class AllowSwitchOff : ToggleGroupAttribute<System.Boolean>
        {
            public AllowSwitchOff(System.Boolean value): base("allowSwitchOff", value) {}
            protected override void Apply(UnityEngine.UI.ToggleGroup component)
            {
                component.allowSwitchOff = this.GetValue();
            }
        }
    }
}