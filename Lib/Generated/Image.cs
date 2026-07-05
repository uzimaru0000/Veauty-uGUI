
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Image"/> attributes, targeting <see cref="UnityEngine.UI.Image"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class ImageAttribute<T> : GuiAttributeBase<UnityEngine.UI.Image, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected ImageAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Image"/>.</summary>
    public partial class Image : GUIBase<UnityEngine.UI.Image>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Image(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.Image.sprite"/>.</summary>
        public class Sprite : ImageAttribute<UnityEngine.Sprite>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>sprite</c>.</param>
            public Sprite(UnityEngine.Sprite value): base("sprite", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.sprite = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.overrideSprite"/>.</summary>
        public class OverrideSprite : ImageAttribute<UnityEngine.Sprite>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>overrideSprite</c>.</param>
            public OverrideSprite(UnityEngine.Sprite value): base("overrideSprite", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.overrideSprite = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.type"/>.</summary>
        public class Type : ImageAttribute<UnityEngine.UI.Image.Type>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>type</c>.</param>
            public Type(UnityEngine.UI.Image.Type value): base("type", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.type = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.preserveAspect"/>.</summary>
        public class PreserveAspect : ImageAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>preserveAspect</c>.</param>
            public PreserveAspect(System.Boolean value): base("preserveAspect", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.preserveAspect = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.fillCenter"/>.</summary>
        public class FillCenter : ImageAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>fillCenter</c>.</param>
            public FillCenter(System.Boolean value): base("fillCenter", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillCenter = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.fillMethod"/>.</summary>
        public class FillMethod : ImageAttribute<UnityEngine.UI.Image.FillMethod>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>fillMethod</c>.</param>
            public FillMethod(UnityEngine.UI.Image.FillMethod value): base("fillMethod", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillMethod = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.fillAmount"/>.</summary>
        public class FillAmount : ImageAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>fillAmount</c>.</param>
            public FillAmount(System.Single value): base("fillAmount", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillAmount = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.fillClockwise"/>.</summary>
        public class FillClockwise : ImageAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>fillClockwise</c>.</param>
            public FillClockwise(System.Boolean value): base("fillClockwise", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillClockwise = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.fillOrigin"/>.</summary>
        public class FillOrigin : ImageAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>fillOrigin</c>.</param>
            public FillOrigin(System.Int32 value): base("fillOrigin", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillOrigin = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.alphaHitTestMinimumThreshold"/>.</summary>
        public class AlphaHitTestMinimumThreshold : ImageAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>alphaHitTestMinimumThreshold</c>.</param>
            public AlphaHitTestMinimumThreshold(System.Single value): base("alphaHitTestMinimumThreshold", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.alphaHitTestMinimumThreshold = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.useSpriteMesh"/>.</summary>
        public class UseSpriteMesh : ImageAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>useSpriteMesh</c>.</param>
            public UseSpriteMesh(System.Boolean value): base("useSpriteMesh", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.useSpriteMesh = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.pixelsPerUnitMultiplier"/>.</summary>
        public class PixelsPerUnitMultiplier : ImageAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>pixelsPerUnitMultiplier</c>.</param>
            public PixelsPerUnitMultiplier(System.Single value): base("pixelsPerUnitMultiplier", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.pixelsPerUnitMultiplier = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Image.material"/>.</summary>
        public class Material : ImageAttribute<UnityEngine.Material>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>material</c>.</param>
            public Material(UnityEngine.Material value): base("material", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.material = this.GetValue();
            }
        }
    }
}