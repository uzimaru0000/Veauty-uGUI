
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class ButtonAttribute<T> : GuiAttributeBase<UnityEngine.UI.Button, T>
    {
        protected ButtonAttribute(string key, T value) : base(key, value) { }
    }

    public partial class Button : GUIBase<UnityEngine.UI.Button>
    {
        public Button(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class OnClick : ButtonAttribute<UnityEngine.Events.UnityAction>
        {
            public OnClick(UnityEngine.Events.UnityAction value): base("onClick", value) {}
            protected override void Apply(UnityEngine.UI.Button component)
            {
                component.onClick.RemoveAllListeners();
                component.onClick.AddListener(GetValue());
            }
        }
    }
}