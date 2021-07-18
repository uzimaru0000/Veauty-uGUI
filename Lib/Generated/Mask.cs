
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class MaskAttribute<T> : GuiAttributeBase<UnityEngine.UI.Mask, T>
    {
        protected MaskAttribute(string key, T value) : base(key, value) { }
    }

    public class Mask : GUIBase<UnityEngine.UI.Mask>
    {
        public Mask(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class ShowMaskGraphic : MaskAttribute<System.Boolean>
        {
            public ShowMaskGraphic(System.Boolean value): base("showMaskGraphic", value) {}
            protected override void Apply(UnityEngine.UI.Mask component)
            {
                component.showMaskGraphic = this.GetValue();
            }
        }

    }
}