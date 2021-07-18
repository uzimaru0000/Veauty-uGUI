
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class MaskableGraphicAttribute<T> : GuiAttributeBase<UnityEngine.UI.MaskableGraphic, T>
    {
        protected MaskableGraphicAttribute(string key, T value) : base(key, value) { }
    }

    public class MaskableGraphic : GUIBase<UnityEngine.UI.MaskableGraphic>
    {
        public MaskableGraphic(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class OnCullStateChanged : MaskableGraphicAttribute<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent>
        {
            public OnCullStateChanged(UnityEngine.UI.MaskableGraphic.CullStateChangedEvent value): base("onCullStateChanged", value) {}
            protected override void Apply(UnityEngine.UI.MaskableGraphic component)
            {
                component.onCullStateChanged = this.GetValue();
            }
        }

        public class Maskable : MaskableGraphicAttribute<System.Boolean>
        {
            public Maskable(System.Boolean value): base("maskable", value) {}
            protected override void Apply(UnityEngine.UI.MaskableGraphic component)
            {
                component.maskable = this.GetValue();
            }
        }

        public class IsMaskingGraphic : MaskableGraphicAttribute<System.Boolean>
        {
            public IsMaskingGraphic(System.Boolean value): base("isMaskingGraphic", value) {}
            protected override void Apply(UnityEngine.UI.MaskableGraphic component)
            {
                component.isMaskingGraphic = this.GetValue();
            }
        }

    }
}