
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Mask"/> attributes, targeting <see cref="UnityEngine.UI.Mask"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class MaskAttribute<T> : GuiAttributeBase<UnityEngine.UI.Mask, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected MaskAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Mask"/>.</summary>
    public partial class Mask : GUIBase<UnityEngine.UI.Mask>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Mask(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.Mask.showMaskGraphic"/>.</summary>
        public class ShowMaskGraphic : MaskAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>showMaskGraphic</c>.</param>
            public ShowMaskGraphic(System.Boolean value): base("showMaskGraphic", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Mask component)
            {
                component.showMaskGraphic = this.GetValue();
            }
        }
    }
}