
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class ImageAttribute<T> : GuiAttributeBase<UnityEngine.UI.Image, T>
    {
        protected ImageAttribute(string key, T value) : base(key, value) { }
    }

    public partial class Image : GUIBase<UnityEngine.UI.Image>
    {
        public Image(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class Sprite : ImageAttribute<UnityEngine.Sprite>
        {
            public Sprite(UnityEngine.Sprite value): base("sprite", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.sprite = this.GetValue();
            }
        }

        public partial class OverrideSprite : ImageAttribute<UnityEngine.Sprite>
        {
            public OverrideSprite(UnityEngine.Sprite value): base("overrideSprite", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.overrideSprite = this.GetValue();
            }
        }

        public partial class Type : ImageAttribute<UnityEngine.UI.Image.Type>
        {
            public Type(UnityEngine.UI.Image.Type value): base("type", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.type = this.GetValue();
            }
        }

        public partial class PreserveAspect : ImageAttribute<System.Boolean>
        {
            public PreserveAspect(System.Boolean value): base("preserveAspect", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.preserveAspect = this.GetValue();
            }
        }

        public partial class FillCenter : ImageAttribute<System.Boolean>
        {
            public FillCenter(System.Boolean value): base("fillCenter", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillCenter = this.GetValue();
            }
        }

        public partial class FillMethod : ImageAttribute<UnityEngine.UI.Image.FillMethod>
        {
            public FillMethod(UnityEngine.UI.Image.FillMethod value): base("fillMethod", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillMethod = this.GetValue();
            }
        }

        public partial class FillAmount : ImageAttribute<System.Single>
        {
            public FillAmount(System.Single value): base("fillAmount", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillAmount = this.GetValue();
            }
        }

        public partial class FillClockwise : ImageAttribute<System.Boolean>
        {
            public FillClockwise(System.Boolean value): base("fillClockwise", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillClockwise = this.GetValue();
            }
        }

        public partial class FillOrigin : ImageAttribute<System.Int32>
        {
            public FillOrigin(System.Int32 value): base("fillOrigin", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillOrigin = this.GetValue();
            }
        }

        public partial class AlphaHitTestMinimumThreshold : ImageAttribute<System.Single>
        {
            public AlphaHitTestMinimumThreshold(System.Single value): base("alphaHitTestMinimumThreshold", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.alphaHitTestMinimumThreshold = this.GetValue();
            }
        }

        public partial class UseSpriteMesh : ImageAttribute<System.Boolean>
        {
            public UseSpriteMesh(System.Boolean value): base("useSpriteMesh", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.useSpriteMesh = this.GetValue();
            }
        }

        public partial class PixelsPerUnitMultiplier : ImageAttribute<System.Single>
        {
            public PixelsPerUnitMultiplier(System.Single value): base("pixelsPerUnitMultiplier", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.pixelsPerUnitMultiplier = this.GetValue();
            }
        }

        public partial class Material : ImageAttribute<UnityEngine.Material>
        {
            public Material(UnityEngine.Material value): base("material", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.material = this.GetValue();
            }
        }
    }
}