
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class MaskAttribute<T> : GuiAttributeBase<UnityEngine.UI.Mask, T>
    {
        protected MaskAttribute(string key, T value) : base(key, value) { }
    }

    public partial class Mask : GUIBase<UnityEngine.UI.Mask>
    {
        public Mask(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class ShowMaskGraphic : MaskAttribute<System.Boolean>
        {
            public ShowMaskGraphic(System.Boolean value): base("showMaskGraphic", value) {}
            protected override void Apply(UnityEngine.UI.Mask component)
            {
                component.showMaskGraphic = this.GetValue();
            }
        }
    }
}