using Veauty.VTree;
using UnityEngine;
using UI = UnityEngine.UI;

namespace Veauty.uGUI
{
    public abstract class ImageAttribute<T> : GUIAttributeBase<UI.Image, T>
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
            throw new System.NotImplementedException();
        }

        public class Type : ImageAttribute<UI.Image.Type>
        {
            public Type(string key, UI.Image.Type value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.type = this.value;
        }

        public class Sprite : ImageAttribute<UnityEngine.Sprite>
        {
            public Sprite(string key, UnityEngine.Sprite value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.sprite = this.value;
        }

        public class PreserveAspect : ImageAttribute<bool>
        {
            public PreserveAspect(string key, bool value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.preserveAspect = this.value;
        }
        
        public class FillAmount : ImageAttribute<float>
        {
            public FillAmount(string key, float value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillAmount = this.value;
        }
        
        public class FillCenter : ImageAttribute<bool>
        {
            public FillCenter(string key, bool value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillCenter = this.value;
        }
        
        public class FillClockwise : ImageAttribute<bool>
        {
            public FillClockwise(string key, bool value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillClockwise = this.value;
        }
        
        public class FillMethod : ImageAttribute<UI.Image.FillMethod>
        {
            public FillMethod(string key, UI.Image.FillMethod value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillMethod = this.value;
        }
        
        public class FillOriginHorizontal : ImageAttribute<UI.Image.OriginHorizontal>
        {
            public FillOriginHorizontal(string key, UI.Image.OriginHorizontal value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillOrigin = (int) this.value;
        }

        public class FillOriginVertical : ImageAttribute<UI.Image.OriginVertical>
        {
            public FillOriginVertical(string key, UI.Image.OriginVertical value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillOrigin = (int) this.value;
        }
        
        public class FillOrigin90 : ImageAttribute<UI.Image.Origin90>
        {
            public FillOrigin90(string key, UI.Image.Origin90 value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillOrigin = (int) this.value;
        }
        
        public class FillOrigin180 : ImageAttribute<UI.Image.Origin180>
        {
            public FillOrigin180(string key, UI.Image.Origin180 value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillOrigin = (int) this.value;
        }
        
        public class FillOrigin360 : ImageAttribute<UI.Image.Origin360>
        {
            public FillOrigin360(string key, UI.Image.Origin360 value) : base(key, value)
            {
            }

            protected override void Apply(UI.Image component) => component.fillOrigin = (int) this.value;
        }
    }
}