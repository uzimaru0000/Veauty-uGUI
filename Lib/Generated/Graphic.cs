
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class GraphicAttribute<T> : GuiAttributeBase<UnityEngine.UI.Graphic, T>
    {
        protected GraphicAttribute(string key, T value) : base(key, value) { }
    }

    public partial class Graphic : GUIBase<UnityEngine.UI.Graphic>
    {
        public Graphic(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class Color : GraphicAttribute<UnityEngine.Color>
        {
            public Color(UnityEngine.Color value): base("color", value) {}
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.color = this.GetValue();
            }
        }

        public partial class RaycastTarget : GraphicAttribute<System.Boolean>
        {
            public RaycastTarget(System.Boolean value): base("raycastTarget", value) {}
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.raycastTarget = this.GetValue();
            }
        }

        public partial class RaycastPadding : GraphicAttribute<UnityEngine.Vector4>
        {
            public RaycastPadding(UnityEngine.Vector4 value): base("raycastPadding", value) {}
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.raycastPadding = this.GetValue();
            }
        }

        public partial class Material : GraphicAttribute<UnityEngine.Material>
        {
            public Material(UnityEngine.Material value): base("material", value) {}
            protected override void Apply(UnityEngine.UI.Graphic component)
            {
                component.material = this.GetValue();
            }
        }
    }
}