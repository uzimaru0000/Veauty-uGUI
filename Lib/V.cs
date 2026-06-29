using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;

namespace Veauty.uGUI
{
    public static class V
    {
        public static IVTree Text(string value,
            int? fontSize = null,
            Color? color = null,
            TextAnchor? alignment = null,
            FontStyle? fontStyle = null,
            float? preferredWidth = null,
            float? preferredHeight = null,
            float? flexibleWidth = null,
            float? flexibleHeight = null,
            params IAttribute<UnityGameObject>[] extras)
        {
            var attrs = new List<IAttribute<UnityGameObject>> { new Text.Value(value) };
            if (fontSize.HasValue) attrs.Add(new Text.FontSize(fontSize.Value));
            if (alignment.HasValue) attrs.Add(new Text.Alignment(alignment.Value));
            if (fontStyle.HasValue) attrs.Add(new Text.FontStyle(fontStyle.Value));
            if (color.HasValue) attrs.Add(new Graphic.Color(color.Value));
            if (preferredWidth.HasValue) attrs.Add(new LayoutElement.PreferredWidth(preferredWidth.Value));
            if (preferredHeight.HasValue) attrs.Add(new LayoutElement.PreferredHeight(preferredHeight.Value));
            if (flexibleWidth.HasValue) attrs.Add(new LayoutElement.FlexibleWidth(flexibleWidth.Value));
            if (flexibleHeight.HasValue) attrs.Add(new LayoutElement.FlexibleHeight(flexibleHeight.Value));
            attrs.AddRange(extras);
            return new Text(attrs);
        }

        public static Element Button(
            UnityAction onClick = null,
            Color? color = null,
            float? preferredWidth = null,
            float? preferredHeight = null,
            float? flexibleWidth = null,
            float? flexibleHeight = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                onClick != null ? new Button.OnClick(onClick) : null,
                color.HasValue ? new Graphic.Color(color.Value) : null,
                preferredWidth.HasValue ? new LayoutElement.PreferredWidth(preferredWidth.Value) : null,
                preferredHeight.HasValue ? new LayoutElement.PreferredHeight(preferredHeight.Value) : null,
                flexibleWidth.HasValue ? new LayoutElement.FlexibleWidth(flexibleWidth.Value) : null,
                flexibleHeight.HasValue ? new LayoutElement.FlexibleHeight(flexibleHeight.Value) : null);
            return new Element(children => new Button(attrs, children));
        }

        public static Element Image(
            Color? color = null,
            float? preferredWidth = null,
            float? preferredHeight = null,
            float? flexibleWidth = null,
            float? flexibleHeight = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                color.HasValue ? new Graphic.Color(color.Value) : null,
                preferredWidth.HasValue ? new LayoutElement.PreferredWidth(preferredWidth.Value) : null,
                preferredHeight.HasValue ? new LayoutElement.PreferredHeight(preferredHeight.Value) : null,
                flexibleWidth.HasValue ? new LayoutElement.FlexibleWidth(flexibleWidth.Value) : null,
                flexibleHeight.HasValue ? new LayoutElement.FlexibleHeight(flexibleHeight.Value) : null);
            return new Element(children => new Image(attrs, children));
        }

        public static Element VLayout(
            float? spacing = null,
            RectOffset padding = null,
            TextAnchor? childAlignment = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                new VerticalLayoutGroup.Spacing(spacing ?? 0f),
                new VerticalLayoutGroup.ChildControlWidth(true),
                new VerticalLayoutGroup.ChildControlHeight(true),
                new VerticalLayoutGroup.ChildForceExpandHeight(false),
                padding != null ? new VerticalLayoutGroup.Padding(padding) : null,
                childAlignment.HasValue ? new VerticalLayoutGroup.ChildAlignment(childAlignment.Value) : null);
            return new Element(children => new VerticalLayoutGroup(attrs, children));
        }

        public static Element HLayout(
            float? spacing = null,
            RectOffset padding = null,
            TextAnchor? childAlignment = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                new HorizontalLayoutGroup.Spacing(spacing ?? 0f),
                new HorizontalLayoutGroup.ChildControlWidth(true),
                new HorizontalLayoutGroup.ChildControlHeight(true),
                new HorizontalLayoutGroup.ChildForceExpandWidth(false),
                padding != null ? new HorizontalLayoutGroup.Padding(padding) : null,
                childAlignment.HasValue ? new HorizontalLayoutGroup.ChildAlignment(childAlignment.Value) : null);
            return new Element(children => new HorizontalLayoutGroup(attrs, children));
        }

        public static Element Grid(
            Vector2? cellSize = null,
            Vector2? spacing = null,
            RectOffset padding = null,
            TextAnchor? childAlignment = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                cellSize.HasValue ? new GridLayoutGroup.CellSize(cellSize.Value) : null,
                spacing.HasValue ? new GridLayoutGroup.Spacing(spacing.Value) : null,
                padding != null ? new GridLayoutGroup.Padding(padding) : null,
                childAlignment.HasValue ? new GridLayoutGroup.ChildAlignment(childAlignment.Value) : null);
            return new Element(children => new GridLayoutGroup(attrs, children));
        }

        public static Element RawImage(
            Texture texture = null,
            Rect? uvRect = null,
            Color? color = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                texture != null ? new RawImage.Texture(texture) : null,
                uvRect.HasValue ? new RawImage.UvRect(uvRect.Value) : null,
                color.HasValue ? new Graphic.Color(color.Value) : null);
            return new Element(children => new RawImage(attrs, children));
        }

        public static Element Toggle(
            bool? isOn = null,
            Color? color = null,
            bool? interactable = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                isOn.HasValue ? new Toggle.IsOn(isOn.Value) : null,
                color.HasValue ? new Graphic.Color(color.Value) : null,
                interactable.HasValue ? new Selectable.Interactable(interactable.Value) : null);
            return new Element(children => new Toggle(attrs, children));
        }

        public static Element ToggleGroup(
            bool? allowSwitchOff = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                allowSwitchOff.HasValue ? new ToggleGroup.AllowSwitchOff(allowSwitchOff.Value) : null);
            return new Element(children => new ToggleGroup(attrs, children));
        }

        public static Element Slider(
            float? value = null,
            float? minValue = null,
            float? maxValue = null,
            bool? wholeNumbers = null,
            UnityEngine.UI.Slider.Direction? direction = null,
            bool? interactable = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                value.HasValue ? new Slider.Value(value.Value) : null,
                minValue.HasValue ? new Slider.MinValue(minValue.Value) : null,
                maxValue.HasValue ? new Slider.MaxValue(maxValue.Value) : null,
                wholeNumbers.HasValue ? new Slider.WholeNumbers(wholeNumbers.Value) : null,
                direction.HasValue ? new Slider.Direction(direction.Value) : null,
                interactable.HasValue ? new Selectable.Interactable(interactable.Value) : null);
            return new Element(children => new Slider(attrs, children));
        }

        public static Element Scrollbar(
            float? value = null,
            float? size = null,
            int? numberOfSteps = null,
            UnityEngine.UI.Scrollbar.Direction? direction = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                value.HasValue ? new Scrollbar.Value(value.Value) : null,
                size.HasValue ? new Scrollbar.Size(size.Value) : null,
                numberOfSteps.HasValue ? new Scrollbar.NumberOfSteps(numberOfSteps.Value) : null,
                direction.HasValue ? new Scrollbar.Direction(direction.Value) : null);
            return new Element(children => new Scrollbar(attrs, children));
        }

        public static Element ScrollRect(
            bool? horizontal = null,
            bool? vertical = null,
            UnityEngine.UI.ScrollRect.MovementType? movementType = null,
            float? elasticity = null,
            bool? inertia = null,
            float? decelerationRate = null,
            float? scrollSensitivity = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                horizontal.HasValue ? new ScrollRect.Horizontal(horizontal.Value) : null,
                vertical.HasValue ? new ScrollRect.Vertical(vertical.Value) : null,
                movementType.HasValue ? new ScrollRect.MovementType(movementType.Value) : null,
                elasticity.HasValue ? new ScrollRect.Elasticity(elasticity.Value) : null,
                inertia.HasValue ? new ScrollRect.Inertia(inertia.Value) : null,
                decelerationRate.HasValue ? new ScrollRect.DecelerationRate(decelerationRate.Value) : null,
                scrollSensitivity.HasValue ? new ScrollRect.ScrollSensitivity(scrollSensitivity.Value) : null);
            return new Element(children => new ScrollRect(attrs, children));
        }

        public static Element InputField(
            string text = null,
            UnityEngine.UI.InputField.ContentType? contentType = null,
            UnityEngine.UI.InputField.LineType? lineType = null,
            int? characterLimit = null,
            bool? readOnly = null,
            Color? color = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                text != null ? new InputField.Text(text) : null,
                contentType.HasValue ? new InputField.ContentType(contentType.Value) : null,
                lineType.HasValue ? new InputField.LineType(lineType.Value) : null,
                characterLimit.HasValue ? new InputField.CharacterLimit(characterLimit.Value) : null,
                readOnly.HasValue ? new InputField.ReadOnly(readOnly.Value) : null,
                color.HasValue ? new Graphic.Color(color.Value) : null);
            return new Element(children => new InputField(attrs, children));
        }

        public static Element Dropdown(
            int? value = null,
            System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData> options = null,
            float? alphaFadeSpeed = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                value.HasValue ? new Dropdown.Value(value.Value) : null,
                options != null ? new Dropdown.Options(options) : null,
                alphaFadeSpeed.HasValue ? new Dropdown.AlphaFadeSpeed(alphaFadeSpeed.Value) : null);
            return new Element(children => new Dropdown(attrs, children));
        }

        public static Element Selectable(
            bool? interactable = null,
            UnityEngine.UI.Selectable.Transition? transition = null,
            UnityEngine.UI.ColorBlock? colors = null,
            UnityEngine.UI.Navigation? navigation = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                interactable.HasValue ? new Selectable.Interactable(interactable.Value) : null,
                transition.HasValue ? new Selectable.Transition(transition.Value) : null,
                colors.HasValue ? new Selectable.Colors(colors.Value) : null,
                navigation.HasValue ? new Selectable.Navigation(navigation.Value) : null);
            return new Element(children => new Selectable(attrs, children));
        }

        public static Element Mask(
            bool? showMaskGraphic = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                showMaskGraphic.HasValue ? new Mask.ShowMaskGraphic(showMaskGraphic.Value) : null);
            return new Element(children => new Mask(attrs, children));
        }

        public static Element RectMask2D(
            Vector4? padding = null,
            Vector2Int? softness = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                padding.HasValue ? new RectMask2D.Padding(padding.Value) : null,
                softness.HasValue ? new RectMask2D.Softness(softness.Value) : null);
            return new Element(children => new RectMask2D(attrs, children));
        }

        private static IAttribute<UnityGameObject>[] BuildAttrs(
            IAttribute<UnityGameObject>[] extras,
            params IAttribute<UnityGameObject>[] candidates)
        {
            var attrs = new List<IAttribute<UnityGameObject>>();
            foreach (var c in candidates)
                if (c != null) attrs.Add(c);
            if (extras != null) attrs.AddRange(extras);
            return attrs.ToArray();
        }
    }
}
