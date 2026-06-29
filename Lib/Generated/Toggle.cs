
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class ToggleAttribute<T> : GuiAttributeBase<UnityEngine.UI.Toggle, T>
    {
        protected ToggleAttribute(string key, T value) : base(key, value) { }
    }

    public class Toggle : GUIBase<UnityEngine.UI.Toggle>
    {
        public Toggle(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var toggle = go.GetComponent<UnityEngine.UI.Toggle>();
            var bg = CreateChild(go, "Background");
            bg.AddComponent<UnityEngine.CanvasRenderer>();
            var bgImage = bg.AddComponent<UnityEngine.UI.Image>();
            bgImage.color = new UnityEngine.Color(0.22f, 0.24f, 0.28f);
            var bgRect = bg.GetComponent<UnityEngine.RectTransform>();
            bgRect.anchorMin = new UnityEngine.Vector2(0f, 0.1f);
            bgRect.anchorMax = new UnityEngine.Vector2(0f, 0.9f);
            bgRect.pivot = new UnityEngine.Vector2(0f, 0.5f);
            bgRect.sizeDelta = new UnityEngine.Vector2(24f, 0f);
            toggle.targetGraphic = bgImage;
            var cm = CreateChild(bg, "Checkmark");
            cm.AddComponent<UnityEngine.CanvasRenderer>();
            var cmImage = cm.AddComponent<UnityEngine.UI.Image>();
            cmImage.color = new UnityEngine.Color(0.2f, 0.75f, 0.4f);
            var cmRect = cm.GetComponent<UnityEngine.RectTransform>();
            cmRect.anchorMin = new UnityEngine.Vector2(0.15f, 0.15f);
            cmRect.anchorMax = new UnityEngine.Vector2(0.85f, 0.85f);
            cmRect.sizeDelta = UnityEngine.Vector2.zero;
            toggle.graphic = cmImage;
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }


        public class Group : ToggleAttribute<UnityEngine.UI.ToggleGroup>
        {
            public Group(UnityEngine.UI.ToggleGroup value): base("group", value) {}
            protected override void Apply(UnityEngine.UI.Toggle component)
            {
                component.group = this.GetValue();
            }
        }

        public class IsOn : ToggleAttribute<System.Boolean>
        {
            public IsOn(System.Boolean value): base("isOn", value) {}
            protected override void Apply(UnityEngine.UI.Toggle component)
            {
                component.isOn = this.GetValue();
            }
        }
    }
}