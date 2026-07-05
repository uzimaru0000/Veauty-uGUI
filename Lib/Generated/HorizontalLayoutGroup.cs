
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="HorizontalLayoutGroup"/> attributes, targeting <see cref="UnityEngine.UI.HorizontalLayoutGroup"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class HorizontalLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.HorizontalLayoutGroup, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected HorizontalLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.HorizontalLayoutGroup"/>.</summary>
    public partial class HorizontalLayoutGroup : GUIBase<UnityEngine.UI.HorizontalLayoutGroup>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public HorizontalLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


    }
}