
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="MaskableGraphic"/> attributes, targeting <see cref="UnityEngine.UI.MaskableGraphic"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class MaskableGraphicAttribute<T> : GuiAttributeBase<UnityEngine.UI.MaskableGraphic, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected MaskableGraphicAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.MaskableGraphic"/>.</summary>
    public partial class MaskableGraphic : GUIBase<UnityEngine.UI.MaskableGraphic>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public MaskableGraphic(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.MaskableGraphic.onCullStateChanged"/>.</summary>
        public class OnCullStateChanged : MaskableGraphicAttribute<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>onCullStateChanged</c>.</param>
            public OnCullStateChanged(UnityEngine.UI.MaskableGraphic.CullStateChangedEvent value): base("onCullStateChanged", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.MaskableGraphic component)
            {
                component.onCullStateChanged = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.MaskableGraphic.maskable"/>.</summary>
        public class Maskable : MaskableGraphicAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>maskable</c>.</param>
            public Maskable(System.Boolean value): base("maskable", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.MaskableGraphic component)
            {
                component.maskable = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.MaskableGraphic.isMaskingGraphic"/>.</summary>
        public class IsMaskingGraphic : MaskableGraphicAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>isMaskingGraphic</c>.</param>
            public IsMaskingGraphic(System.Boolean value): base("isMaskingGraphic", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.MaskableGraphic component)
            {
                component.isMaskingGraphic = this.GetValue();
            }
        }
    }
}