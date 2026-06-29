
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class DropdownAttribute<T> : GuiAttributeBase<UnityEngine.UI.Dropdown, T>
    {
        protected DropdownAttribute(string key, T value) : base(key, value) { }
    }

    public class Dropdown : GUIBase<UnityEngine.UI.Dropdown>
    {
        public Dropdown(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var dropdown = go.GetComponent<UnityEngine.UI.Dropdown>();
            var bgImage = go.GetComponent<UnityEngine.UI.Image>();
            if (bgImage == null) { go.AddComponent<UnityEngine.CanvasRenderer>(); bgImage = go.AddComponent<UnityEngine.UI.Image>(); }
            bgImage.color = new UnityEngine.Color(0.22f, 0.24f, 0.28f);
            dropdown.targetGraphic = bgImage;
            var label = CreateChild(go, "Label");
            label.AddComponent<UnityEngine.CanvasRenderer>();
            var labelText = label.AddComponent<UnityEngine.UI.Text>();
            labelText.alignment = UnityEngine.TextAnchor.MiddleLeft;
            labelText.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>("LegacyRuntime.ttf");
            labelText.fontSize = 16;
            labelText.color = UnityEngine.Color.white;
            var labelRect = label.GetComponent<UnityEngine.RectTransform>();
            labelRect.anchorMin = UnityEngine.Vector2.zero;
            labelRect.anchorMax = UnityEngine.Vector2.one;
            labelRect.offsetMin = new UnityEngine.Vector2(10f, 0f);
            labelRect.offsetMax = new UnityEngine.Vector2(-30f, 0f);
            dropdown.captionText = labelText;
            var arrow = CreateChild(go, "Arrow");
            arrow.AddComponent<UnityEngine.CanvasRenderer>();
            var arrowText = arrow.AddComponent<UnityEngine.UI.Text>();
            arrowText.text = "▼";
            arrowText.alignment = UnityEngine.TextAnchor.MiddleCenter;
            arrowText.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>("LegacyRuntime.ttf");
            arrowText.fontSize = 14;
            arrowText.color = UnityEngine.Color.white;
            var arrowRect = arrow.GetComponent<UnityEngine.RectTransform>();
            arrowRect.anchorMin = new UnityEngine.Vector2(1f, 0f);
            arrowRect.anchorMax = new UnityEngine.Vector2(1f, 1f);
            arrowRect.pivot = new UnityEngine.Vector2(1f, 0.5f);
            arrowRect.sizeDelta = new UnityEngine.Vector2(28f, 0f);
            var template = CreateChild(go, "Template");
            template.AddComponent<UnityEngine.CanvasRenderer>();
            var templateImage = template.AddComponent<UnityEngine.UI.Image>();
            templateImage.color = new UnityEngine.Color(0.16f, 0.18f, 0.22f);
            var scrollRect = template.AddComponent<UnityEngine.UI.ScrollRect>();
            scrollRect.horizontal = false;
            scrollRect.movementType = UnityEngine.UI.ScrollRect.MovementType.Clamped;
            var templateRect = template.GetComponent<UnityEngine.RectTransform>();
            templateRect.anchorMin = new UnityEngine.Vector2(0f, 0f);
            templateRect.anchorMax = new UnityEngine.Vector2(1f, 0f);
            templateRect.pivot = new UnityEngine.Vector2(0.5f, 1f);
            templateRect.sizeDelta = new UnityEngine.Vector2(0f, 150f);
            var viewport = CreateChild(template, "Viewport");
            viewport.AddComponent<UnityEngine.CanvasRenderer>();
            viewport.AddComponent<UnityEngine.UI.Image>().color = new UnityEngine.Color(0f, 0f, 0f, 0f);
            viewport.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = false;
            Stretch(viewport.GetComponent<UnityEngine.RectTransform>());
            scrollRect.viewport = viewport.GetComponent<UnityEngine.RectTransform>();
            var content = CreateChild(viewport, "Content");
            var contentRect = content.GetComponent<UnityEngine.RectTransform>();
            contentRect.anchorMin = new UnityEngine.Vector2(0f, 1f);
            contentRect.anchorMax = new UnityEngine.Vector2(1f, 1f);
            contentRect.pivot = new UnityEngine.Vector2(0.5f, 1f);
            contentRect.sizeDelta = new UnityEngine.Vector2(0f, 28f);
            scrollRect.content = contentRect;
            var item = CreateChild(content, "Item");
            var itemToggle = item.AddComponent<UnityEngine.UI.Toggle>();
            item.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2(0f, 28f);
            var itemBg = CreateChild(item, "Item Background");
            itemBg.AddComponent<UnityEngine.CanvasRenderer>();
            var itemBgImage = itemBg.AddComponent<UnityEngine.UI.Image>();
            itemBgImage.color = new UnityEngine.Color(0.25f, 0.35f, 0.5f);
            Stretch(itemBg.GetComponent<UnityEngine.RectTransform>());
            itemToggle.targetGraphic = itemBgImage;
            var itemLabel = CreateChild(item, "Item Label");
            itemLabel.AddComponent<UnityEngine.CanvasRenderer>();
            var itemLabelText = itemLabel.AddComponent<UnityEngine.UI.Text>();
            itemLabelText.alignment = UnityEngine.TextAnchor.MiddleLeft;
            itemLabelText.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>("LegacyRuntime.ttf");
            itemLabelText.fontSize = 16;
            itemLabelText.color = UnityEngine.Color.white;
            var itemLabelRect = itemLabel.GetComponent<UnityEngine.RectTransform>();
            itemLabelRect.anchorMin = UnityEngine.Vector2.zero;
            itemLabelRect.anchorMax = UnityEngine.Vector2.one;
            itemLabelRect.offsetMin = new UnityEngine.Vector2(10f, 0f);
            itemLabelRect.sizeDelta = UnityEngine.Vector2.zero;
            dropdown.itemText = itemLabelText;
            dropdown.template = templateRect;
            template.SetActive(false);
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }


        public class Template : DropdownAttribute<UnityEngine.RectTransform>
        {
            public Template(UnityEngine.RectTransform value): base("template", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.template = this.GetValue();
            }
        }

        public class CaptionText : DropdownAttribute<UnityEngine.UI.Text>
        {
            public CaptionText(UnityEngine.UI.Text value): base("captionText", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.captionText = this.GetValue();
            }
        }

        public class CaptionImage : DropdownAttribute<UnityEngine.UI.Image>
        {
            public CaptionImage(UnityEngine.UI.Image value): base("captionImage", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.captionImage = this.GetValue();
            }
        }

        public class ItemText : DropdownAttribute<UnityEngine.UI.Text>
        {
            public ItemText(UnityEngine.UI.Text value): base("itemText", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.itemText = this.GetValue();
            }
        }

        public class ItemImage : DropdownAttribute<UnityEngine.UI.Image>
        {
            public ItemImage(UnityEngine.UI.Image value): base("itemImage", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.itemImage = this.GetValue();
            }
        }

        public class Options : DropdownAttribute<System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData>>
        {
            public Options(System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData> value): base("options", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.options = this.GetValue();
            }
        }

        public class OnValueChanged : DropdownAttribute<UnityEngine.UI.Dropdown.DropdownEvent>
        {
            public OnValueChanged(UnityEngine.UI.Dropdown.DropdownEvent value): base("onValueChanged", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.onValueChanged = this.GetValue();
            }
        }

        public class AlphaFadeSpeed : DropdownAttribute<System.Single>
        {
            public AlphaFadeSpeed(System.Single value): base("alphaFadeSpeed", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.alphaFadeSpeed = this.GetValue();
            }
        }

        public class Value : DropdownAttribute<System.Int32>
        {
            public Value(System.Int32 value): base("value", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.value = this.GetValue();
            }
        }
    }
}