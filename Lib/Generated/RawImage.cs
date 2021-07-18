
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class RawImageAttribute<T> : GuiAttributeBase<UnityEngine.UI.RawImage, T>
    {
        protected RawImageAttribute(string key, T value) : base(key, value) { }
    }

    public class RawImage : GUIBase<UnityEngine.UI.RawImage>
    {
        public RawImage(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Texture : RawImageAttribute<UnityEngine.Texture>
        {
            public Texture(UnityEngine.Texture value): base("texture", value) {}
            protected override void Apply(UnityEngine.UI.RawImage component)
            {
                component.texture = this.GetValue();
            }
        }

        public class UvRect : RawImageAttribute<UnityEngine.Rect>
        {
            public UvRect(UnityEngine.Rect value): base("uvRect", value) {}
            protected override void Apply(UnityEngine.UI.RawImage component)
            {
                component.uvRect = this.GetValue();
            }
        }

    }
}