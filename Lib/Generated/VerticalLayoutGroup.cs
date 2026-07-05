
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="VerticalLayoutGroup"/> attributes, targeting <see cref="UnityEngine.UI.VerticalLayoutGroup"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class VerticalLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.VerticalLayoutGroup, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected VerticalLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.VerticalLayoutGroup"/>.</summary>
    public partial class VerticalLayoutGroup : GUIBase<UnityEngine.UI.VerticalLayoutGroup>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public VerticalLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


    }
}