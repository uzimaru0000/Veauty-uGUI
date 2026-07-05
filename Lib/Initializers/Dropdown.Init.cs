namespace Veauty.uGUI
{
    public partial class Dropdown
    {
        /// <summary>
        /// Builds the complete internal dropdown structure with hardcoded dark-theme colors:
        /// background Image (RGB 0.22, 0.24, 0.28) as <c>targetGraphic</c>, "Label" caption text,
        /// "Arrow" glyph, and a deactivated "Template" scroll view (viewport mask, content with
        /// VerticalLayoutGroup/ContentSizeFitter, item Toggle with background, checkmark, and
        /// label) wired to <c>template</c>, <c>captionText</c> and <c>itemText</c>.
        /// There are no sub-components to override; customize via attributes instead.
        /// </summary>
        /// <param name="go">The host GameObject (already has the Dropdown component).</param>
        /// <returns>The same GameObject.</returns>
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
            templateRect.sizeDelta = new UnityEngine.Vector2(0f, 200f);
            var viewport = CreateChild(template, "Viewport");
            viewport.AddComponent<UnityEngine.CanvasRenderer>();
            viewport.AddComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.white;
            viewport.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = false;
            Stretch(viewport.GetComponent<UnityEngine.RectTransform>());
            scrollRect.viewport = viewport.GetComponent<UnityEngine.RectTransform>();
            var content = CreateChild(viewport, "Content");
            var contentRect = content.GetComponent<UnityEngine.RectTransform>();
            contentRect.anchorMin = new UnityEngine.Vector2(0f, 1f);
            contentRect.anchorMax = new UnityEngine.Vector2(1f, 1f);
            contentRect.pivot = new UnityEngine.Vector2(0.5f, 1f);
            contentRect.sizeDelta = new UnityEngine.Vector2(0f, 36f);
            scrollRect.content = contentRect;
            var csf = content.AddComponent<UnityEngine.UI.ContentSizeFitter>();
            csf.verticalFit = UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize;
            var vlg = content.AddComponent<UnityEngine.UI.VerticalLayoutGroup>();
            vlg.childControlWidth = true;
            vlg.childControlHeight = true;
            vlg.childForceExpandWidth = true;
            vlg.childForceExpandHeight = false;
            var item = CreateChild(content, "Item");
            var itemToggle = item.AddComponent<UnityEngine.UI.Toggle>();
            item.AddComponent<UnityEngine.UI.LayoutElement>().preferredHeight = 36f;
            var itemRect = item.GetComponent<UnityEngine.RectTransform>();
            itemRect.anchorMin = new UnityEngine.Vector2(0f, 0.5f);
            itemRect.anchorMax = new UnityEngine.Vector2(1f, 0.5f);
            itemRect.sizeDelta = new UnityEngine.Vector2(0f, 36f);
            var itemBg = CreateChild(item, "Item Background");
            itemBg.AddComponent<UnityEngine.CanvasRenderer>();
            var itemBgImage = itemBg.AddComponent<UnityEngine.UI.Image>();
            itemBgImage.color = UnityEngine.Color.white;
            Stretch(itemBg.GetComponent<UnityEngine.RectTransform>());
            itemToggle.targetGraphic = itemBgImage;
            var cb = itemToggle.colors;
            cb.normalColor = new UnityEngine.Color(0.22f, 0.24f, 0.30f);
            cb.highlightedColor = new UnityEngine.Color(0.32f, 0.40f, 0.58f);
            cb.pressedColor = new UnityEngine.Color(0.22f, 0.55f, 0.95f);
            cb.selectedColor = new UnityEngine.Color(0.26f, 0.32f, 0.45f);
            cb.colorMultiplier = 1f;
            itemToggle.colors = cb;
            var itemCheckmark = CreateChild(item, "Item Checkmark");
            itemCheckmark.AddComponent<UnityEngine.CanvasRenderer>();
            var cmImage = itemCheckmark.AddComponent<UnityEngine.UI.Image>();
            cmImage.color = new UnityEngine.Color(0.22f, 0.55f, 0.95f);
            var cmRect = itemCheckmark.GetComponent<UnityEngine.RectTransform>();
            cmRect.anchorMin = new UnityEngine.Vector2(0f, 0f);
            cmRect.anchorMax = new UnityEngine.Vector2(0f, 1f);
            cmRect.pivot = new UnityEngine.Vector2(0f, 0.5f);
            cmRect.sizeDelta = new UnityEngine.Vector2(4f, 0f);
            itemToggle.graphic = cmImage;
            var itemLabel = CreateChild(item, "Item Label");
            itemLabel.AddComponent<UnityEngine.CanvasRenderer>();
            var itemLabelText = itemLabel.AddComponent<UnityEngine.UI.Text>();
            itemLabelText.alignment = UnityEngine.TextAnchor.MiddleLeft;
            itemLabelText.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>("LegacyRuntime.ttf");
            itemLabelText.fontSize = 18;
            itemLabelText.color = UnityEngine.Color.white;
            var itemLabelRect = itemLabel.GetComponent<UnityEngine.RectTransform>();
            itemLabelRect.anchorMin = UnityEngine.Vector2.zero;
            itemLabelRect.anchorMax = UnityEngine.Vector2.one;
            itemLabelRect.offsetMin = new UnityEngine.Vector2(12f, 0f);
            itemLabelRect.offsetMax = UnityEngine.Vector2.zero;
            dropdown.itemText = itemLabelText;
            dropdown.template = templateRect;
            template.SetActive(false);
            return go;
        }
    }
}
