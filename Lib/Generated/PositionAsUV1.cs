
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="PositionAsUV1"/> attributes, targeting <see cref="UnityEngine.UI.PositionAsUV1"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class PositionAsUV1Attribute<T> : GuiAttributeBase<UnityEngine.UI.PositionAsUV1, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected PositionAsUV1Attribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.PositionAsUV1"/>.</summary>
    public partial class PositionAsUV1 : GUIBase<UnityEngine.UI.PositionAsUV1>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public PositionAsUV1(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


    }
}