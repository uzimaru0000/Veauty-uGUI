using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class ButtonAttribute<T> : GUIAttributeBase<UI.Button, T>
    {
        protected ButtonAttribute(string key, T value) : base(key, value) { }
    }

    public class Button : GUIBase
    {
        public Button(IAttribute[] attrs, IVTree[] kids) : base(attrs, kids) { }
        
        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var btn = go.GetComponent<UI.Button>();
            var img = go.AddComponent<UI.Image>();

            btn.targetGraphic = img;
            return go;
        }
        public override IVTree Render() =>
            new Node<UI.Button>("Button", this.attrs, this.kids);
        public override void Destroy(UnityEngine.GameObject go) { }
        
        public class OnClick : ButtonAttribute<UnityAction>
        {
            public OnClick(UnityAction action): base("ButtonOnClick", action) {}
            protected override void Apply(UI.Button component)
            {
                component.onClick.RemoveAllListeners();
                component.onClick.AddListener(this.value);
            }
        }
    }
}
