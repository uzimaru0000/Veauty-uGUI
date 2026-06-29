
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class RawImageAttribute<T> : GuiAttributeBase<UnityEngine.UI.RawImage, T>
    {
        protected RawImageAttribute(string key, T value) : base(key, value) { }
    }

    public partial class RawImage : GUIBase<UnityEngine.UI.RawImage>
    {
        public RawImage(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class Texture : RawImageAttribute<UnityEngine.Texture>
        {
            public Texture(UnityEngine.Texture value): base("texture", value) {}
            protected override void Apply(UnityEngine.UI.RawImage component)
            {
                component.texture = this.GetValue();
            }
        }

        public partial class UvRect : RawImageAttribute<UnityEngine.Rect>
        {
            public UvRect(UnityEngine.Rect value): base("uvRect", value) {}
            protected override void Apply(UnityEngine.UI.RawImage component)
            {
                component.uvRect = this.GetValue();
            }
        }
    }
}