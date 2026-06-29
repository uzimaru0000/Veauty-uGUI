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
