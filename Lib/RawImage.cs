using UnityEngine;
using Veauty.VTree;
using UI = UnityEngine.UI;

namespace Veauty.uGUI
{
    public abstract class RawImageAttribute<T> : GuiAttributeBase<UI.RawImage, T>
    {
        protected RawImageAttribute(string key, T value) : base(key, value)
        {
        }
    }

    public class RawImage : GUIBase<UI.RawImage>
    {
        public RawImage(string tag, IAttribute[] attrs, IVTree[] kids) : base(tag, attrs, kids)
        {
        }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }

        public override void Destroy(UnityEngine.GameObject go)
        {
        }
        
        public class Texture : RawImageAttribute<UnityEngine.Texture>
        {
            public Texture(UnityEngine.Texture value) : base("RawImageTexture", value)
            {
            }

            protected override void Apply(UI.RawImage component) => component.texture = this.GetValue();
        }

        public class UVRect : RawImageAttribute<UnityEngine.Rect>
        {
            public UVRect(Rect value) : base("RawImageUVRect", value)
            {
            }

            protected override void Apply(UI.RawImage component) => component.uvRect = this.GetValue();
        }
    }
}