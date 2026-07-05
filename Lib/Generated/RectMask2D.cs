
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="RectMask2D"/> attributes, targeting <see cref="UnityEngine.UI.RectMask2D"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class RectMask2DAttribute<T> : GuiAttributeBase<UnityEngine.UI.RectMask2D, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected RectMask2DAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.RectMask2D"/>.</summary>
    public partial class RectMask2D : GUIBase<UnityEngine.UI.RectMask2D>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public RectMask2D(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.RectMask2D.padding"/>.</summary>
        public class Padding : RectMask2DAttribute<UnityEngine.Vector4>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>padding</c>.</param>
            public Padding(UnityEngine.Vector4 value): base("padding", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.RectMask2D component)
            {
                component.padding = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.RectMask2D.softness"/>.</summary>
        public class Softness : RectMask2DAttribute<UnityEngine.Vector2Int>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>softness</c>.</param>
            public Softness(UnityEngine.Vector2Int value): base("softness", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.RectMask2D component)
            {
                component.softness = this.GetValue();
            }
        }
    }
}