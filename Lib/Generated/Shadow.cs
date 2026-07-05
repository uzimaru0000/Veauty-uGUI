
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Shadow"/> attributes, targeting <see cref="UnityEngine.UI.Shadow"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class ShadowAttribute<T> : GuiAttributeBase<UnityEngine.UI.Shadow, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected ShadowAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Shadow"/>.</summary>
    public partial class Shadow : GUIBase<UnityEngine.UI.Shadow>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Shadow(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.Shadow.effectColor"/>.</summary>
        public class EffectColor : ShadowAttribute<UnityEngine.Color>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>effectColor</c>.</param>
            public EffectColor(UnityEngine.Color value): base("effectColor", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Shadow component)
            {
                component.effectColor = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Shadow.effectDistance"/>.</summary>
        public class EffectDistance : ShadowAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>effectDistance</c>.</param>
            public EffectDistance(UnityEngine.Vector2 value): base("effectDistance", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Shadow component)
            {
                component.effectDistance = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Shadow.useGraphicAlpha"/>.</summary>
        public class UseGraphicAlpha : ShadowAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>useGraphicAlpha</c>.</param>
            public UseGraphicAlpha(System.Boolean value): base("useGraphicAlpha", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Shadow component)
            {
                component.useGraphicAlpha = this.GetValue();
            }
        }
    }
}