using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;
using Veauty.uGUI;

namespace Veauty.uGUI.Presets
{
    /// <summary>
    /// Static factory for building uGUI trees with sensible defaults (the Presets API). Most
    /// methods return an <see cref="Element"/>; supply children with the indexer:
    /// <c>V.VLayout(spacing: 8f)[ V.Text("hi") ]</c>.
    /// </summary>
    /// <remarks>
    /// <para><see cref="Toggle"/>, <see cref="Slider"/>, <see cref="Scrollbar"/> and
    /// <see cref="InputField"/> auto-inject their required sub-components (background, fill,
    /// handle, placeholder, ...) with default colors when you do not pass them explicitly; pass a
    /// sub-component (e.g. <c>Slider.Fill(color: Color.red)</c>) as a child to override just that
    /// part.</para>
    /// <para><see cref="VLayout"/> / <see cref="HLayout"/> always force
    /// <c>ChildControlWidth/Height = true</c> and <c>ChildForceExpandHeight</c> (V) or
    /// <c>ChildForceExpandWidth</c> (H) <c>= false</c>; pass <c>extras</c> attributes to override.</para>
    /// </remarks>
    /// <example>
    /// <code>
    /// using Veauty.uGUI.Presets;
    ///
    /// V.VLayout(spacing: 8f)[
    ///     V.Text("Hello", fontSize: 24, color: Color.white),
    ///     V.Button(onClick: () =&gt; Debug.Log("clicked"))[ V.Text("OK") ],
    ///     V.Slider(value: 0.5f)
    /// ]
    /// </code>
    /// </example>
    public static class V
    {
        /// <summary>Wraps a parameterless function component (hooks allowed inside) as a tree node.</summary>
        /// <param name="component">The function component to render.</param>
        /// <returns>A <c>FunctionComponentNode</c> tree.</returns>
        public static IVTree Component(FunctionComponent component)
            => Veauty.VTree.FunctionComponents.Create(component);

        /// <summary>Wraps a function component with an explicit identity key for hook-state matching.</summary>
        /// <param name="key">Identity key that distinguishes this component instance across renders.</param>
        /// <param name="component">The function component to render.</param>
        /// <returns>A <c>FunctionComponentNode</c> tree.</returns>
        public static IVTree Component(string key, FunctionComponent component)
            => Veauty.VTree.FunctionComponents.Create(key, component);

        /// <summary>Wraps a props-taking function component as a tree node.</summary>
        /// <typeparam name="TProps">The props type.</typeparam>
        /// <param name="component">The function component to render.</param>
        /// <param name="props">Props passed to the component.</param>
        /// <returns>A <c>FunctionComponentNode</c> tree.</returns>
        public static IVTree Component<TProps>(FunctionComponent<TProps> component, TProps props)
            => Veauty.VTree.FunctionComponents.Create(component, props);

        /// <summary>Wraps a props-taking function component with an explicit identity key.</summary>
        /// <typeparam name="TProps">The props type.</typeparam>
        /// <param name="key">Identity key that distinguishes this component instance across renders.</param>
        /// <param name="component">The function component to render.</param>
        /// <param name="props">Props passed to the component.</param>
        /// <returns>A <c>FunctionComponentNode</c> tree.</returns>
        public static IVTree Component<TProps>(string key, FunctionComponent<TProps> component, TProps props)
            => Veauty.VTree.FunctionComponents.Create(key, component, props);

        /// <summary>Wraps a function component as a keyed node for efficient list diffing.</summary>
        /// <param name="key">List key (also used as the component identity key).</param>
        /// <param name="component">The function component to render.</param>
        /// <returns>A keyed function-component tree.</returns>
        public static IVTree KeyedComponent(string key, FunctionComponent component)
            => Veauty.VTree.FunctionComponents.Keyed(key, component);

        /// <summary>Wraps a props-taking function component as a keyed node for list diffing.</summary>
        /// <typeparam name="TProps">The props type.</typeparam>
        /// <param name="key">List key (also used as the component identity key).</param>
        /// <param name="component">The function component to render.</param>
        /// <param name="props">Props passed to the component.</param>
        /// <returns>A keyed function-component tree.</returns>
        public static IVTree KeyedComponent<TProps>(string key, FunctionComponent<TProps> component, TProps props)
            => Veauty.VTree.FunctionComponents.Keyed(key, component, props);

        /// <summary>
        /// Creates a <c>Text</c> widget (legacy uGUI Text). Only the parameters you pass become
        /// attributes; the widget's <c>Init</c> assigns the built-in <c>LegacyRuntime.ttf</c> font
        /// when none is set.
        /// </summary>
        /// <param name="value">The text string (always applied, via <c>Text.Value</c>).</param>
        /// <param name="fontSize">Optional font size.</param>
        /// <param name="color">Optional text color (<c>Graphic.Color</c>).</param>
        /// <param name="alignment">Optional text anchor.</param>
        /// <param name="fontStyle">Optional font style.</param>
        /// <param name="preferredWidth">Optional <c>LayoutElement.preferredWidth</c> (auto-adds LayoutElement).</param>
        /// <param name="preferredHeight">Optional <c>LayoutElement.preferredHeight</c>.</param>
        /// <param name="flexibleWidth">Optional <c>LayoutElement.flexibleWidth</c>.</param>
        /// <param name="flexibleHeight">Optional <c>LayoutElement.flexibleHeight</c>.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>The finished text node (not an <see cref="Element"/>; Text takes no children).</returns>
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

        /// <summary>
        /// Creates a <c>Button</c> element. The widget's <c>Init</c> adds an <c>Image</c> as
        /// <c>targetGraphic</c> when the GameObject has no Graphic.
        /// </summary>
        /// <param name="onClick">Optional click handler (replaces all existing listeners).</param>
        /// <param name="color">Optional graphic color.</param>
        /// <param name="preferredWidth">Optional <c>LayoutElement.preferredWidth</c>.</param>
        /// <param name="preferredHeight">Optional <c>LayoutElement.preferredHeight</c>.</param>
        /// <param name="flexibleWidth">Optional <c>LayoutElement.flexibleWidth</c>.</param>
        /// <param name="flexibleHeight">Optional <c>LayoutElement.flexibleHeight</c>.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add children (e.g. a label).</returns>
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

        /// <summary>Creates an <c>Image</c> element.</summary>
        /// <param name="color">Optional graphic color.</param>
        /// <param name="preferredWidth">Optional <c>LayoutElement.preferredWidth</c>.</param>
        /// <param name="preferredHeight">Optional <c>LayoutElement.preferredHeight</c>.</param>
        /// <param name="flexibleWidth">Optional <c>LayoutElement.flexibleWidth</c>.</param>
        /// <param name="flexibleHeight">Optional <c>LayoutElement.flexibleHeight</c>.</param>
        /// <param name="extras">Additional attributes (e.g. <c>Image.Sprite</c>) appended after the
        /// generated ones.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add children.</returns>
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

        /// <summary>
        /// Creates a <c>VerticalLayoutGroup</c> element. Always applies
        /// <c>Spacing</c> (default 0), <c>ChildControlWidth = true</c>,
        /// <c>ChildControlHeight = true</c> and <c>ChildForceExpandHeight = false</c>.
        /// </summary>
        /// <param name="spacing">Spacing between children; defaults to 0.</param>
        /// <param name="padding">Optional layout padding.</param>
        /// <param name="childAlignment">Optional child alignment.</param>
        /// <param name="extras">Additional attributes; an extra with the same key (e.g.
        /// <c>ChildForceExpandHeight</c>) overrides the forced default.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add the laid-out children.</returns>
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

        /// <summary>
        /// Creates a <c>HorizontalLayoutGroup</c> element. Always applies
        /// <c>Spacing</c> (default 0), <c>ChildControlWidth = true</c>,
        /// <c>ChildControlHeight = true</c> and <c>ChildForceExpandWidth = false</c>.
        /// </summary>
        /// <param name="spacing">Spacing between children; defaults to 0.</param>
        /// <param name="padding">Optional layout padding.</param>
        /// <param name="childAlignment">Optional child alignment.</param>
        /// <param name="extras">Additional attributes; an extra with the same key (e.g.
        /// <c>ChildForceExpandWidth</c>) overrides the forced default.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add the laid-out children.</returns>
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

        /// <summary>Creates a <c>GridLayoutGroup</c> element. Only the parameters you pass become
        /// attributes; nothing is forced.</summary>
        /// <param name="cellSize">Optional cell size.</param>
        /// <param name="spacing">Optional spacing between cells.</param>
        /// <param name="padding">Optional layout padding.</param>
        /// <param name="childAlignment">Optional child alignment.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add the grid children.</returns>
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

        /// <summary>Creates a <c>RawImage</c> element.</summary>
        /// <param name="texture">Optional texture.</param>
        /// <param name="uvRect">Optional UV rect.</param>
        /// <param name="color">Optional graphic color.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add children.</returns>
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

        /// <summary>
        /// Creates a <c>Toggle</c> element. When the children do not contain a
        /// <c>Toggle.ToggleBackground</c> / <c>Toggle.ToggleCheckmark</c>, default ones are
        /// injected automatically; sub-components are ordered before content children.
        /// </summary>
        /// <param name="isOn">Optional initial on/off state.</param>
        /// <param name="color">Optional graphic color.</param>
        /// <param name="interactable">Optional <c>Selectable.interactable</c>.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; children may mix sub-components (e.g.
        /// <c>Toggle.Checkmark(color: ...)</c>) and content (e.g. a label).</returns>
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
            return new Element(children =>
            {
                var parts = new System.Collections.Generic.List<IVTree>();
                bool hasBg = false, hasCm = false;
                var content = new System.Collections.Generic.List<IVTree>();
                foreach (var c in children)
                {
                    if (c is Toggle.ToggleBackground) hasBg = true;
                    else if (c is Toggle.ToggleCheckmark) hasCm = true;
                    if (c is ISubComponent) parts.Add(c);
                    else content.Add(c);
                }
                if (!hasBg) parts.Add(new Toggle.ToggleBackground());
                if (!hasCm) parts.Add(new Toggle.ToggleCheckmark());
                parts.AddRange(content);
                return new Toggle(attrs, parts.ToArray());
            });
        }

        /// <summary>Creates a <c>ToggleGroup</c> element.</summary>
        /// <param name="allowSwitchOff">Optional <c>allowSwitchOff</c> value.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add the grouped toggles.</returns>
        public static Element ToggleGroup(
            bool? allowSwitchOff = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                allowSwitchOff.HasValue ? new ToggleGroup.AllowSwitchOff(allowSwitchOff.Value) : null);
            return new Element(children => new ToggleGroup(attrs, children));
        }

        /// <summary>
        /// Creates a <c>Slider</c> element. When the children do not contain a
        /// <c>Slider.SliderBackground</c> / <c>Slider.SliderFill</c> / <c>Slider.SliderHandle</c>,
        /// default ones are injected automatically; sub-components are ordered before content
        /// children.
        /// </summary>
        /// <param name="value">Optional slider value (applied after min/max/direction).</param>
        /// <param name="minValue">Optional minimum value.</param>
        /// <param name="maxValue">Optional maximum value.</param>
        /// <param name="wholeNumbers">Optional whole-numbers flag.</param>
        /// <param name="direction">Optional slide direction.</param>
        /// <param name="interactable">Optional <c>Selectable.interactable</c>.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; children may override individual sub-components,
        /// e.g. <c>V.Slider(value: 0.5f)[ Slider.Fill(color: Color.red) ]</c>.</returns>
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
                minValue.HasValue ? new Slider.MinValue(minValue.Value) : null,
                maxValue.HasValue ? new Slider.MaxValue(maxValue.Value) : null,
                wholeNumbers.HasValue ? new Slider.WholeNumbers(wholeNumbers.Value) : null,
                direction.HasValue ? new Slider.Direction(direction.Value) : null,
                interactable.HasValue ? new Selectable.Interactable(interactable.Value) : null,
                value.HasValue ? new Slider.Value(value.Value) : null);
            return new Element(children =>
            {
                var parts = new System.Collections.Generic.List<IVTree>();
                bool hasBg = false, hasFill = false, hasHandle = false;
                var content = new System.Collections.Generic.List<IVTree>();
                foreach (var c in children)
                {
                    if (c is Slider.SliderBackground) hasBg = true;
                    else if (c is Slider.SliderFill) hasFill = true;
                    else if (c is Slider.SliderHandle) hasHandle = true;
                    if (c is ISubComponent) parts.Add(c);
                    else content.Add(c);
                }
                if (!hasBg) parts.Add(new Slider.SliderBackground());
                if (!hasFill) parts.Add(new Slider.SliderFill());
                if (!hasHandle) parts.Add(new Slider.SliderHandle());
                parts.AddRange(content);
                return new Slider(attrs, parts.ToArray());
            });
        }

        /// <summary>
        /// Creates a <c>Scrollbar</c> element. When the children do not contain a
        /// <c>Scrollbar.ScrollbarHandlePart</c>, a default handle is injected automatically.
        /// The widget's <c>Init</c> also adds a background <c>Image</c> when none exists.
        /// </summary>
        /// <param name="value">Optional scrollbar value (applied last).</param>
        /// <param name="size">Optional handle size (0..1).</param>
        /// <param name="numberOfSteps">Optional step count.</param>
        /// <param name="direction">Optional scroll direction.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; pass <c>Scrollbar.Handle(...)</c> as a child to
        /// customize the handle.</returns>
        public static Element Scrollbar(
            float? value = null,
            float? size = null,
            int? numberOfSteps = null,
            UnityEngine.UI.Scrollbar.Direction? direction = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                size.HasValue ? new Scrollbar.Size(size.Value) : null,
                numberOfSteps.HasValue ? new Scrollbar.NumberOfSteps(numberOfSteps.Value) : null,
                direction.HasValue ? new Scrollbar.Direction(direction.Value) : null,
                value.HasValue ? new Scrollbar.Value(value.Value) : null);
            return new Element(children =>
            {
                var parts = new System.Collections.Generic.List<IVTree>();
                bool hasHandle = false;
                var content = new System.Collections.Generic.List<IVTree>();
                foreach (var c in children)
                {
                    if (c is Scrollbar.ScrollbarHandlePart) hasHandle = true;
                    if (c is ISubComponent) parts.Add(c);
                    else content.Add(c);
                }
                if (!hasHandle) parts.Add(new Scrollbar.ScrollbarHandlePart());
                parts.AddRange(content);
                return new Scrollbar(attrs, parts.ToArray());
            });
        }

        /// <summary>
        /// Creates a <c>ScrollRect</c> element. The widget's <c>Init</c> adds an <c>Image</c> and a
        /// <c>RectMask2D</c> when missing, and <c>AfterRenderKids</c> wires the first child as the
        /// scroll <c>content</c> (top-stretched anchors) when <c>content</c> is not set.
        /// </summary>
        /// <param name="horizontal">Optional horizontal scrolling flag.</param>
        /// <param name="vertical">Optional vertical scrolling flag.</param>
        /// <param name="movementType">Optional movement type.</param>
        /// <param name="elasticity">Optional elasticity.</param>
        /// <param name="inertia">Optional inertia flag.</param>
        /// <param name="decelerationRate">Optional deceleration rate.</param>
        /// <param name="scrollSensitivity">Optional scroll sensitivity.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; the first child becomes the scrolled content.</returns>
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

        /// <summary>
        /// Creates an <c>InputField</c> element. When the children do not contain an
        /// <c>InputField.InputFieldPlaceholderPart</c> / <c>InputField.InputFieldTextPart</c>,
        /// default ones are injected automatically. The widget's <c>Init</c> also adds a background
        /// <c>Image</c> when none exists.
        /// </summary>
        /// <param name="text">Optional initial text.</param>
        /// <param name="contentType">Optional content type.</param>
        /// <param name="lineType">Optional line type.</param>
        /// <param name="characterLimit">Optional character limit.</param>
        /// <param name="readOnly">Optional read-only flag.</param>
        /// <param name="color">Optional graphic color.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; pass <c>InputField.PlaceholderText(...)</c> /
        /// <c>InputField.TextDisplay(...)</c> as children to customize the internal texts.</returns>
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
            return new Element(children =>
            {
                var parts = new System.Collections.Generic.List<IVTree>();
                bool hasPh = false, hasTxt = false;
                var content = new System.Collections.Generic.List<IVTree>();
                foreach (var c in children)
                {
                    if (c is InputField.InputFieldPlaceholderPart) hasPh = true;
                    else if (c is InputField.InputFieldTextPart) hasTxt = true;
                    if (c is ISubComponent) parts.Add(c);
                    else content.Add(c);
                }
                if (!hasPh) parts.Add(new InputField.InputFieldPlaceholderPart());
                if (!hasTxt) parts.Add(new InputField.InputFieldTextPart());
                parts.AddRange(content);
                return new InputField(attrs, parts.ToArray());
            });
        }

        /// <summary>
        /// Creates a <c>Dropdown</c> element. The widget's <c>Init</c> builds the full internal
        /// structure (label, arrow, template with scroll view and item toggles) with hardcoded
        /// dark-theme colors; there are no sub-components to override.
        /// </summary>
        /// <param name="value">Optional selected option index.</param>
        /// <param name="options">Optional option list.</param>
        /// <param name="alphaFadeSpeed">Optional fade speed of the dropdown list.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add extra children.</returns>
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

        /// <summary>Creates a plain <c>Selectable</c> element.</summary>
        /// <param name="interactable">Optional interactable flag.</param>
        /// <param name="transition">Optional transition mode.</param>
        /// <param name="colors">Optional color block.</param>
        /// <param name="navigation">Optional navigation settings.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add children.</returns>
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

        /// <summary>Creates a <c>Mask</c> element (requires a Graphic on the same node to mask with).</summary>
        /// <param name="showMaskGraphic">Optional flag to render the mask graphic itself.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add the masked children.</returns>
        public static Element Mask(
            bool? showMaskGraphic = null,
            IAttribute<UnityGameObject>[] extras = null)
        {
            var attrs = BuildAttrs(extras,
                showMaskGraphic.HasValue ? new Mask.ShowMaskGraphic(showMaskGraphic.Value) : null);
            return new Element(children => new Mask(attrs, children));
        }

        /// <summary>Creates a <c>RectMask2D</c> element (rectangular clipping without a Graphic).</summary>
        /// <param name="padding">Optional clipping padding.</param>
        /// <param name="softness">Optional edge softness.</param>
        /// <param name="extras">Additional attributes appended after the generated ones.</param>
        /// <returns>An <see cref="Element"/>; use the indexer to add the clipped children.</returns>
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
