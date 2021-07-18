
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class ShadowAttribute<T> : GuiAttributeBase<UnityEngine.UI.Shadow, T>
    {
        protected ShadowAttribute(string key, T value) : base(key, value) { }
    }

    public class Shadow : GUIBase<UnityEngine.UI.Shadow>
    {
        public Shadow(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class EffectColor : ShadowAttribute<UnityEngine.Color>
        {
            public EffectColor(UnityEngine.Color value): base("effectColor", value) {}
            protected override void Apply(UnityEngine.UI.Shadow component)
            {
                component.effectColor = this.GetValue();
            }
        }

        public class EffectDistance : ShadowAttribute<UnityEngine.Vector2>
        {
            public EffectDistance(UnityEngine.Vector2 value): base("effectDistance", value) {}
            protected override void Apply(UnityEngine.UI.Shadow component)
            {
                component.effectDistance = this.GetValue();
            }
        }

        public class UseGraphicAlpha : ShadowAttribute<System.Boolean>
        {
            public UseGraphicAlpha(System.Boolean value): base("useGraphicAlpha", value) {}
            protected override void Apply(UnityEngine.UI.Shadow component)
            {
                component.useGraphicAlpha = this.GetValue();
            }
        }

    }
}