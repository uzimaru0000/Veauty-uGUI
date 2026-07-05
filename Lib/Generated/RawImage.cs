
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="RawImage"/> attributes, targeting <see cref="UnityEngine.UI.RawImage"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class RawImageAttribute<T> : GuiAttributeBase<UnityEngine.UI.RawImage, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected RawImageAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.RawImage"/>.</summary>
    public partial class RawImage : GUIBase<UnityEngine.UI.RawImage>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public RawImage(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.RawImage.texture"/>.</summary>
        public class Texture : RawImageAttribute<UnityEngine.Texture>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>texture</c>.</param>
            public Texture(UnityEngine.Texture value): base("texture", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.RawImage component)
            {
                component.texture = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.RawImage.uvRect"/>.</summary>
        public class UvRect : RawImageAttribute<UnityEngine.Rect>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>uvRect</c>.</param>
            public UvRect(UnityEngine.Rect value): base("uvRect", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.RawImage component)
            {
                component.uvRect = this.GetValue();
            }
        }
    }
}