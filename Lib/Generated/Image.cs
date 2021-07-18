
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class ImageAttribute<T> : GuiAttributeBase<UnityEngine.UI.Image, T>
    {
        protected ImageAttribute(string key, T value) : base(key, value) { }
    }

    public class Image : GUIBase<UnityEngine.UI.Image>
    {
        public Image(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Sprite : ImageAttribute<UnityEngine.Sprite>
        {
            public Sprite(UnityEngine.Sprite value): base("sprite", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.sprite = this.GetValue();
            }
        }

        public class OverrideSprite : ImageAttribute<UnityEngine.Sprite>
        {
            public OverrideSprite(UnityEngine.Sprite value): base("overrideSprite", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.overrideSprite = this.GetValue();
            }
        }

        public class Type : ImageAttribute<UnityEngine.UI.Image.Type>
        {
            public Type(UnityEngine.UI.Image.Type value): base("type", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.type = this.GetValue();
            }
        }

        public class PreserveAspect : ImageAttribute<System.Boolean>
        {
            public PreserveAspect(System.Boolean value): base("preserveAspect", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.preserveAspect = this.GetValue();
            }
        }

        public class FillCenter : ImageAttribute<System.Boolean>
        {
            public FillCenter(System.Boolean value): base("fillCenter", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillCenter = this.GetValue();
            }
        }

        public class FillMethod : ImageAttribute<UnityEngine.UI.Image.FillMethod>
        {
            public FillMethod(UnityEngine.UI.Image.FillMethod value): base("fillMethod", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillMethod = this.GetValue();
            }
        }

        public class FillAmount : ImageAttribute<System.Single>
        {
            public FillAmount(System.Single value): base("fillAmount", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillAmount = this.GetValue();
            }
        }

        public class FillClockwise : ImageAttribute<System.Boolean>
        {
            public FillClockwise(System.Boolean value): base("fillClockwise", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillClockwise = this.GetValue();
            }
        }

        public class FillOrigin : ImageAttribute<System.Int32>
        {
            public FillOrigin(System.Int32 value): base("fillOrigin", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.fillOrigin = this.GetValue();
            }
        }

        public class EventAlphaThreshold : ImageAttribute<System.Single>
        {
            public EventAlphaThreshold(System.Single value): base("eventAlphaThreshold", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.alphaHitTestMinimumThreshold = this.GetValue();
            }
        }

        public class AlphaHitTestMinimumThreshold : ImageAttribute<System.Single>
        {
            public AlphaHitTestMinimumThreshold(System.Single value): base("alphaHitTestMinimumThreshold", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.alphaHitTestMinimumThreshold = this.GetValue();
            }
        }

        public class UseSpriteMesh : ImageAttribute<System.Boolean>
        {
            public UseSpriteMesh(System.Boolean value): base("useSpriteMesh", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.useSpriteMesh = this.GetValue();
            }
        }

        public class PixelsPerUnitMultiplier : ImageAttribute<System.Single>
        {
            public PixelsPerUnitMultiplier(System.Single value): base("pixelsPerUnitMultiplier", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.pixelsPerUnitMultiplier = this.GetValue();
            }
        }

        public class Material : ImageAttribute<UnityEngine.Material>
        {
            public Material(UnityEngine.Material value): base("material", value) {}
            protected override void Apply(UnityEngine.UI.Image component)
            {
                component.material = this.GetValue();
            }
        }

    }
}