using UnityEngine;
using UI = UnityEngine.UI;

namespace Veauty.uGUI
{
    public abstract class GraphicAttribute<T> : GuiAttributeBase<UI.Graphic, T>
    {
        protected GraphicAttribute(string key, T value) : base(key, value) { }
    }

    public class Color : GraphicAttribute<UnityEngine.Color>
    {
        public Color(UnityEngine.Color value) : base("GraphicColor", value)
        {
        }

        protected override void Apply(UI.Graphic component) => component.color = this.GetValue();
    }

    public class Material : GraphicAttribute<UnityEngine.Material>
    {
        public Material(UnityEngine.Material value) : base("GraphicMaterial", value)
        {
        }

        protected override void Apply(UI.Graphic component) => component.material = this.GetValue();
    }

    public class RaycastTarget : GraphicAttribute<bool>
    {
        public RaycastTarget(bool value) : base("GraphicRaycast", value)
        {
        }

        protected override void Apply(UI.Graphic component) => component.raycastTarget = this.GetValue();
    }
}