using UnityEngine;
using UI = UnityEngine.UI;

namespace Veauty.uGUI
{
    public abstract class GraphicAttribute<T> : GUIAttributeBase<UI.Graphic, T>
    {
        protected GraphicAttribute(string key, T value) : base(key, value)
        {
        }
    }

    public class Color : GraphicAttribute<UnityEngine.Color>
    {
        public Color(string key, UnityEngine.Color value) : base(key, value)
        {
        }

        protected override void Apply(UI.Graphic component) => component.color = this.value;
    }

    public class Material : GraphicAttribute<UnityEngine.Material>
    {
        public Material(string key, UnityEngine.Material value) : base(key, value)
        {
        }

        protected override void Apply(UI.Graphic component) => component.material = this.value;
    }

    public class RaycastTarget : GraphicAttribute<bool>
    {
        public RaycastTarget(string key, bool value) : base(key, value)
        {
        }

        protected override void Apply(UI.Graphic component) => component.raycastTarget = this.value;
    }
}