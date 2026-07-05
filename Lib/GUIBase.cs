using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>
    /// Marker interface for widget sub-components (e.g. <c>Slider.SliderFill</c>, <c>Toggle.ToggleCheckmark</c>).
    /// </summary>
    /// <remarks>
    /// Sub-components are lightweight configuration carriers passed as <c>kids</c> to a widget
    /// constructor. They implement <see cref="IVTree"/> only so they can travel through the kids
    /// array; they never render through the VTree pipeline. Widgets filter them out in
    /// <c>GetKids()</c> (so diff/patch never sees them) and read their configuration in
    /// <c>Init</c> via <see cref="GUIBase{T}.FindPart{T}"/> to build internal child GameObjects.
    /// </remarks>
    public interface ISubComponent { }

    /// <summary>
    /// Value bundle describing how an <see cref="UnityEngine.UI.Image"/> should look
    /// (sprite, color, and image type).
    /// </summary>
    public struct ImageStyle
    {
        /// <summary>Sprite to assign. Ignored when <c>null</c> (the image keeps its current sprite).</summary>
        public UnityEngine.Sprite Sprite;

        /// <summary>Tint color to assign. Always applied, including <c>default</c> (transparent black).</summary>
        public UnityEngine.Color Color;

        /// <summary>Image draw mode (Simple, Sliced, Tiled, Filled). Always applied.</summary>
        public UnityEngine.UI.Image.Type ImageType;

        /// <summary>
        /// Applies this style to <paramref name="image"/>. <see cref="Sprite"/> is only set when
        /// non-null; <see cref="Color"/> and <see cref="ImageType"/> are set unconditionally.
        /// </summary>
        /// <param name="image">The target Image component.</param>
        public void ApplyTo(UnityEngine.UI.Image image)
        {
            if (Sprite != null) image.sprite = Sprite;
            image.color = Color;
            image.type = ImageType;
        }
    }

    /// <summary>
    /// Base class for every uGUI widget: a typed VTree node whose tag is the full name of the
    /// backing Unity component <typeparamref name="T"/>, with host lifecycle hooks for building
    /// internal structure.
    /// </summary>
    /// <typeparam name="T">The Unity component attached to the rendered GameObject
    /// (e.g. <c>UnityEngine.UI.Button</c>).</typeparam>
    /// <remarks>
    /// <para>Rendering order for a widget node: the GameObject is created, <typeparamref name="T"/>
    /// is attached, <see cref="Init"/> runs, attributes are applied, VTree children (from
    /// <c>GetKids()</c>) are rendered, then <see cref="AfterRenderKids"/> runs.</para>
    /// <para>Internal children created in <see cref="Init"/> are invisible to the VTree. The patcher
    /// maps virtual children to real children using <c>childOffset = transform.childCount - kids.Length</c>,
    /// which skips the leading internal objects — so <see cref="Init"/> must add internal children
    /// before content children are rendered, never after.</para>
    /// </remarks>
    /// <example>
    /// <code>
    /// using Veauty.uGUI;
    ///
    /// // Any widget: attributes first, then VTree children.
    /// var tree = new Button(
    ///     new IAttribute&lt;UnityEngine.GameObject&gt;[] { new Button.OnClick(() =&gt; Debug.Log("hi")) },
    ///     new Text(new IAttribute&lt;UnityEngine.GameObject&gt;[] { new Text.Value("Click me") }));
    /// </code>
    /// </example>
    public abstract class GUIBase<T> :
        Node<UnityEngine.GameObject, T>,
        IHostLifecycle<UnityEngine.GameObject>,
        IHostLifecycleTree<UnityEngine.GameObject>
        where T : UnityEngine.Component
    {
        /// <summary>
        /// Creates the widget node with the given attributes and children. The node tag is
        /// <c>typeof(T).FullName</c>.
        /// </summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject. Attributes with the
        /// same key overwrite earlier ones.</param>
        /// <param name="kids">VTree children and/or <see cref="ISubComponent"/> configuration objects.</param>
        protected GUIBase(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids)
            : base(typeof(T).FullName, attrs, kids)
        {
        }

        /// <summary>
        /// Called right after the GameObject is created and <typeparamref name="T"/> is attached,
        /// before attributes are applied and before VTree children are rendered. Override to build
        /// internal child objects (e.g. a Slider's fill and handle).
        /// </summary>
        /// <param name="go">The freshly created host GameObject.</param>
        /// <returns>The (possibly same) GameObject to continue rendering with.</returns>
        public virtual UnityEngine.GameObject Init(UnityEngine.GameObject go) => go;

        /// <summary>
        /// Called when the widget's GameObject is about to be unmounted. Override to release
        /// resources or detach listeners. The default does nothing.
        /// </summary>
        /// <param name="go">The host GameObject being destroyed.</param>
        public virtual void Destroy(UnityEngine.GameObject go) { }

        /// <summary>
        /// Called after all VTree children have been rendered and parented. Override for setup that
        /// needs the children to exist (e.g. <c>ScrollRect</c> wiring its <c>content</c> reference).
        /// The default does nothing.
        /// </summary>
        /// <param name="go">The host GameObject with all children attached.</param>
        public virtual void AfterRenderKids(UnityEngine.GameObject go) { }

        /// <summary>
        /// Returns this widget as its own single host lifecycle
        /// (<see cref="IHostLifecycleTree{T}"/> implementation).
        /// </summary>
        /// <returns>An array containing only this widget.</returns>
        public IHostLifecycle<UnityEngine.GameObject>[] GetHostLifecycles()
            => new IHostLifecycle<UnityEngine.GameObject>[] { this };

        /// <summary>
        /// Counts descendants using the filtered <c>GetKids()</c> view, so
        /// <see cref="ISubComponent"/> entries are excluded from the diff traversal size.
        /// </summary>
        /// <returns>The number of VTree descendants (content children only).</returns>
        public override int GetDescendantsCount()
        {
            var count = 0;
            var contentKids = GetKids();
            foreach (var kid in contentKids)
            {
                count += kid.GetDescendantsCount();
            }

            return count + contentKids.Length;
        }

        /// <summary>
        /// Creates an internal child GameObject with a <see cref="UnityEngine.RectTransform"/> and
        /// parents it to <paramref name="parent"/> (with <c>worldPositionStays: false</c>).
        /// </summary>
        /// <param name="parent">The parent GameObject.</param>
        /// <param name="name">Name of the new GameObject.</param>
        /// <returns>The created child GameObject.</returns>
        /// <remarks>Children created this way are invisible to the VTree; call this only from
        /// <see cref="Init"/> so the patcher's child-offset math stays correct.</remarks>
        protected static UnityEngine.GameObject CreateChild(UnityEngine.GameObject parent, string name)
        {
            var child = new UnityEngine.GameObject(name);
            child.AddComponent<UnityEngine.RectTransform>();
            child.transform.SetParent(parent.transform, false);
            return child;
        }

        /// <summary>
        /// Stretches <paramref name="rt"/> to fill its parent: anchors 0..1 and
        /// <c>sizeDelta = (0, 0)</c>.
        /// </summary>
        /// <param name="rt">The RectTransform to stretch.</param>
        protected static void Stretch(UnityEngine.RectTransform rt)
        {
            rt.anchorMin = UnityEngine.Vector2.zero;
            rt.anchorMax = UnityEngine.Vector2.one;
            rt.sizeDelta = UnityEngine.Vector2.zero;
        }

        /// <summary>
        /// Adds a <see cref="UnityEngine.CanvasRenderer"/> plus a graphic component of type
        /// <typeparamref name="TComp"/> to <paramref name="go"/> and sets its color.
        /// </summary>
        /// <typeparam name="TComp">The graphic type to add (e.g. <c>Image</c>, <c>Text</c>).</typeparam>
        /// <param name="go">The GameObject to add the visual to.</param>
        /// <param name="color">Color assigned to the new graphic.</param>
        /// <returns>The added graphic component.</returns>
        protected static TComp AddVisual<TComp>(UnityEngine.GameObject go, UnityEngine.Color color)
            where TComp : UnityEngine.UI.Graphic
        {
            go.AddComponent<UnityEngine.CanvasRenderer>();
            var comp = go.AddComponent<TComp>();
            comp.color = color;
            return comp;
        }

        /// <summary>
        /// Sets only the RectTransform properties whose argument is non-null; all others are left
        /// untouched.
        /// </summary>
        /// <param name="rt">The RectTransform to modify.</param>
        /// <param name="anchorMin">Optional new <c>anchorMin</c>.</param>
        /// <param name="anchorMax">Optional new <c>anchorMax</c>.</param>
        /// <param name="pivot">Optional new <c>pivot</c>.</param>
        /// <param name="sizeDelta">Optional new <c>sizeDelta</c>.</param>
        /// <param name="offsetMin">Optional new <c>offsetMin</c>.</param>
        /// <param name="offsetMax">Optional new <c>offsetMax</c>.</param>
        protected static void SetupRect(
            UnityEngine.RectTransform rt,
            UnityEngine.Vector2? anchorMin = null,
            UnityEngine.Vector2? anchorMax = null,
            UnityEngine.Vector2? pivot = null,
            UnityEngine.Vector2? sizeDelta = null,
            UnityEngine.Vector2? offsetMin = null,
            UnityEngine.Vector2? offsetMax = null)
        {
            if (anchorMin.HasValue) rt.anchorMin = anchorMin.Value;
            if (anchorMax.HasValue) rt.anchorMax = anchorMax.Value;
            if (pivot.HasValue) rt.pivot = pivot.Value;
            if (sizeDelta.HasValue) rt.sizeDelta = sizeDelta.Value;
            if (offsetMin.HasValue) rt.offsetMin = offsetMin.Value;
            if (offsetMax.HasValue) rt.offsetMax = offsetMax.Value;
        }

        /// <summary>
        /// Returns the first kid of type <typeparamref name="T"/> from the raw (unfiltered) kids
        /// array, or <c>null</c> if none exists. Used in <see cref="Init"/> to read
        /// <see cref="ISubComponent"/> configurations.
        /// </summary>
        /// <typeparam name="T">The sub-component type to look for.</typeparam>
        /// <returns>The first matching kid, or <c>null</c>.</returns>
        protected T FindPart<T>() where T : class
        {
            foreach (var kid in this.kids)
                if (kid is T part) return part;
            return null;
        }
    }

    /// <summary>
    /// Base class for all uGUI attributes: a keyed value that is applied to a component of type
    /// <typeparamref name="T1"/> found on the target GameObject.
    /// </summary>
    /// <typeparam name="T1">The Unity component the attribute writes to.</typeparam>
    /// <typeparam name="T2">The value type carried by the attribute.</typeparam>
    /// <remarks>
    /// <para><b>Silent no-op:</b> if the GameObject has no <typeparamref name="T1"/> and the type is
    /// not in the auto-add whitelist, <see cref="Apply(UnityEngine.GameObject)"/> does nothing — no
    /// exception, no log. Make sure the attribute matches the widget's component (or an
    /// auto-addable one).</para>
    /// <para><b>Auto-add whitelist:</b> <c>LayoutElement</c>, <c>ContentSizeFitter</c>,
    /// <c>AspectRatioFitter</c>, <c>CanvasGroup</c>, <c>Shadow</c>, <c>Outline</c>,
    /// <c>PositionAsUV1</c> are added automatically when missing.</para>
    /// </remarks>
    public abstract class GuiAttributeBase<T1, T2> : Attribute<UnityEngine.GameObject, T2> where T1 : UnityEngine.Component
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key used by the diff algorithm; attributes with equal
        /// keys on the same node overwrite each other.</param>
        /// <param name="value">The value to apply.</param>
        protected GuiAttributeBase(string key, T2 value) : base(key, value) { }

        /// <summary>Applies the value to the resolved component. Implemented by concrete attributes.</summary>
        /// <param name="component">The component found (or auto-added) on the GameObject.</param>
        protected abstract void Apply(T1 component);

        /// <summary>
        /// Finds <typeparamref name="T1"/> on <paramref name="obj"/> (auto-adding it when the type
        /// is whitelisted) and calls <see cref="Apply(T1)"/>. Does nothing when the component is
        /// missing and not whitelisted.
        /// </summary>
        /// <param name="obj">The rendered GameObject.</param>
        public override void Apply(UnityEngine.GameObject obj)
        {
            var component = obj.GetComponent<T1>();
            if (component == null && ShouldAddMissingComponent())
            {
                component = obj.AddComponent(typeof(T1)) as T1;
            }

            if (component)
            {
                Apply(component);
            }
        }

        private static bool ShouldAddMissingComponent()
        {
            var type = typeof(T1);
            return type == typeof(UnityEngine.UI.LayoutElement)
                || type == typeof(UnityEngine.UI.ContentSizeFitter)
                || type == typeof(UnityEngine.UI.AspectRatioFitter)
                || type == typeof(UnityEngine.CanvasGroup)
                || type == typeof(UnityEngine.UI.Shadow)
                || type == typeof(UnityEngine.UI.Outline)
                || type == typeof(UnityEngine.UI.PositionAsUV1);
        }
    }
}
