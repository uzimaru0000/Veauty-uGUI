
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Graphic"/> attributes, targeting <see cref="UnityEngine.UI.Graphic"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class GraphicAttribute<T> : GuiAttributeBase<UnityEngine.UI.Graphic, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected GraphicAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Graphic"/>.</summary>
    public partial class Graphic : GUIBase<UnityEngine.UI.Graphic>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Graphic(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.Graphic.color"/>.</summary>
        public class Color : GraphicAttribute<UnityEngine.Color>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>color</c>.</param>
            public Color(UnityEngine.Color value): base("color", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.color = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Graphic.raycastTarget"/>.</summary>
        public class RaycastTarget : GraphicAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>raycastTarget</c>.</param>
            public RaycastTarget(System.Boolean value): base("raycastTarget", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.raycastTarget = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Graphic.raycastPadding"/>.</summary>
        public class RaycastPadding : GraphicAttribute<UnityEngine.Vector4>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>raycastPadding</c>.</param>
            public RaycastPadding(UnityEngine.Vector4 value): base("raycastPadding", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.raycastPadding = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Graphic.material"/>.</summary>
        public class Material : GraphicAttribute<UnityEngine.Material>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>material</c>.</param>
            public Material(UnityEngine.Material value): base("material", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.material = this.GetValue();
            }
        }
    }
}