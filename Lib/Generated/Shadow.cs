
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class ShadowAttribute<T> : GuiAttributeBase<UnityEngine.UI.Shadow, T>
    {
        protected ShadowAttribute(string key, T value) : base(key, value) { }
    }

    public partial class Shadow : GUIBase<UnityEngine.UI.Shadow>
    {
        public Shadow(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class EffectColor : ShadowAttribute<UnityEngine.Color>
        {
            public EffectColor(UnityEngine.Color value): base("effectColor", value) {}
            protected override void Apply(UnityEngine.UI.Shadow component)
            {
                component.effectColor = this.GetValue();
            }
        }

        public partial class EffectDistance : ShadowAttribute<UnityEngine.Vector2>
        {
            public EffectDistance(UnityEngine.Vector2 value): base("effectDistance", value) {}
            protected override void Apply(UnityEngine.UI.Shadow component)
            {
                component.effectDistance = this.GetValue();
            }
        }

        public partial class UseGraphicAlpha : ShadowAttribute<System.Boolean>
        {
            public UseGraphicAlpha(System.Boolean value): base("useGraphicAlpha", value) {}
            protected override void Apply(UnityEngine.UI.Shadow component)
            {
                component.useGraphicAlpha = this.GetValue();
            }
        }
    }
}