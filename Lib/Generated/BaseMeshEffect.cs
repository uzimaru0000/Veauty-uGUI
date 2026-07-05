
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="BaseMeshEffect"/> attributes, targeting <see cref="UnityEngine.UI.BaseMeshEffect"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class BaseMeshEffectAttribute<T> : GuiAttributeBase<UnityEngine.UI.BaseMeshEffect, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected BaseMeshEffectAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.BaseMeshEffect"/>.</summary>
    public partial class BaseMeshEffect : GUIBase<UnityEngine.UI.BaseMeshEffect>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public BaseMeshEffect(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


    }
}