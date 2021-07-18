
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class ButtonAttribute<T> : GuiAttributeBase<UnityEngine.UI.Button, T>
    {
        protected ButtonAttribute(string key, T value) : base(key, value) { }
    }

    public class Button : GUIBase<UnityEngine.UI.Button>
    {
        public Button(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class OnClick : ButtonAttribute<UnityEngine.Events.UnityAction>
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