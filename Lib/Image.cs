using Veauty.VTree;
using UnityEngine;
using UI = UnityEngine.UI;

namespace Veauty.uGUI
{
    public abstract class ImageAttribute<T> : GuiAttributeBase<UI.Image, T>
    {
        protected ImageAttribute(string key, T value) : base(key, value)
        {
        }
    }
    
    public class Image : GUIBase<UI.Image>
    {
        public Image(IAttribute[] attrs, IVTree[] kids) : base("Image", attrs, kids)
        {
        }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }

        public override void Destroy(UnityEngine.GameObject go)
        {
        }

        public class Type : ImageAttribute<UI.Image.Type>
        {
            public Type(UI.Image.Type value) : base("ImageType", value)
            {
            }

            protected override void Apply(UI.Image component) => component.type = this.GetValue();
        }

        public class Sprite : ImageAttribute<UnityEngine.Sprite>
        {
            public Sprite(UnityEngine.Sprite value) : base("ImageSprint", value)
            {
            }

            protected override void Apply(UI.Image component) => component.sprite = this.GetValue();
        }

        public class PreserveAspect : ImageAttribute<bool>
        {
            public PreserveAspect(bool value) : base("ImagePreserveAspect", value)
            {
            }

            protected override void Apply(UI.Image component) => component.preserveAspect = this.GetValue();
        }
        
        public class FillAmount : ImageAttribute<float>
        {
            public FillAmount(float value) : base("ImageFillAmount", value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillAmount = this.GetValue();
        }
        
        public class FillCenter : ImageAttribute<bool>
        {
            public FillCenter(bool value) : base("ImageFillCenter", value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillCenter = this.GetValue();
        }
        
        public class FillClockwise : ImageAttribute<bool>
        {
            public FillClockwise(bool value) : base("ImageFillClockwise", value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillClockwise = this.GetValue();
        }
        
        public class FillMethod : ImageAttribute<UI.Image.FillMethod>
        {
            public FillMethod(UI.Image.FillMethod value) : base("ImageFillMethod", value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillMethod = this.GetValue();
        }
        
        public class FillOriginHorizontal : ImageAttribute<UI.Image.OriginHorizontal>
        {
            public FillOriginHorizontal(UI.Image.OriginHorizontal value) : base("ImageFillOriginHorizontal", value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillOrigin = (int) this.GetValue();
        }

        public class FillOriginVertical : ImageAttribute<UI.Image.OriginVertical>
        {
            public FillOriginVertical(UI.Image.OriginVertical value) : base("ImageFillOriginVertical", value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillOrigin = (int) this.GetValue();
        }
        
        public class FillOrigin90 : ImageAttribute<UI.Image.Origin90>
        {
            public FillOrigin90(UI.Image.Origin90 value) : base("ImageFillOrigin90", value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillOrigin = (int) this.GetValue();
        }
        
        public class FillOrigin180 : ImageAttribute<UI.Image.Origin180>
        {
            public FillOrigin180(UI.Image.Origin180 value) : base("ImageFillOrigin180", value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillOrigin = (int) this.GetValue();
        }
        
        public class FillOrigin360 : ImageAttribute<UI.Image.Origin360>
        {
            public FillOrigin360(UI.Image.Origin360 value) : base("ImageFillOrigin360", value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillOrigin = (int) this.GetValue();
        }
    }
}