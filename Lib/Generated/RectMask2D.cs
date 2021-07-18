
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class RectMask2DAttribute<T> : GuiAttributeBase<UnityEngine.UI.RectMask2D, T>
    {
        protected RectMask2DAttribute(string key, T value) : base(key, value) { }
    }

    public class RectMask2D : GUIBase<UnityEngine.UI.RectMask2D>
    {
        public RectMask2D(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Padding : RectMask2DAttribute<UnityEngine.Vector4>
        {
            public Padding(UnityEngine.Vector4 value): base("padding", value) {}
            protected override void Apply(UnityEngine.UI.RectMask2D component)
            {
                component.padding = this.GetValue();
            }
        }

        public class Softness : RectMask2DAttribute<UnityEngine.Vector2Int>
        {
            public Softness(UnityEngine.Vector2Int value): base("softness", value) {}
            protected override void Apply(UnityEngine.UI.RectMask2D component)
            {
                component.softness = this.GetValue();
            }
        }

    }
}