
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class GraphicAttribute<T> : GuiAttributeBase<UnityEngine.UI.Graphic, T>
    {
        protected GraphicAttribute(string key, T value) : base(key, value) { }
    }

    public class Graphic : GUIBase<UnityEngine.UI.Graphic>
    {
        public Graphic(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Color : GraphicAttribute<UnityEngine.Color>
        {
            public Color(UnityEngine.Color value): base("color", value) {}
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.color = this.GetValue();
            }
        }

        public class RaycastTarget : GraphicAttribute<System.Boolean>
        {
            public RaycastTarget(System.Boolean value): base("raycastTarget", value) {}
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.raycastTarget = this.GetValue();
            }
        }

        public class RaycastPadding : GraphicAttribute<UnityEngine.Vector4>
        {
            public RaycastPadding(UnityEngine.Vector4 value): base("raycastPadding", value) {}
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.raycastPadding = this.GetValue();
            }
        }

        public class Material : GraphicAttribute<UnityEngine.Material>
        {
            public Material(UnityEngine.Material value): base("material", value) {}
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.material = this.GetValue();
            }
        }

    }
}