using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="CanvasGroup"/> attributes, targeting <see cref="UnityEngine.CanvasGroup"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    /// <remarks><see cref="UnityEngine.CanvasGroup"/> is on the auto-add whitelist, so these
    /// attributes add the component when it is missing.</remarks>
    public abstract class CanvasGroupAttribute<T> : GuiAttributeBase<UnityEngine.CanvasGroup, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected CanvasGroupAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>
    /// Veauty widget for <see cref="UnityEngine.CanvasGroup"/> (hand-written; not emitted by the
    /// code generator).
    /// </summary>
    public partial class CanvasGroup : GUIBase<UnityEngine.CanvasGroup>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public CanvasGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        /// <summary>Sets <see cref="UnityEngine.CanvasGroup.alpha"/>.</summary>
        public class Alpha : CanvasGroupAttribute<float>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>alpha</c>.</param>
            public Alpha(float value) : base("alpha", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.CanvasGroup component)
            {
                component.alpha = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.CanvasGroup.interactable"/>.</summary>
        public class Interactable : CanvasGroupAttribute<bool>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>interactable</c>.</param>
            public Interactable(bool value) : base("interactable", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.CanvasGroup component)
            {
                component.interactable = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.CanvasGroup.blocksRaycasts"/>.</summary>
        public class BlocksRaycasts : CanvasGroupAttribute<bool>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>blocksRaycasts</c>.</param>
            public BlocksRaycasts(bool value) : base("blocksRaycasts", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.CanvasGroup component)
            {
                component.blocksRaycasts = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.CanvasGroup.ignoreParentGroups"/>.</summary>
        public class IgnoreParentGroups : CanvasGroupAttribute<bool>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>ignoreParentGroups</c>.</param>
            public IgnoreParentGroups(bool value) : base("ignoreParentGroups", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.CanvasGroup component)
            {
                component.ignoreParentGroups = this.GetValue();
            }
        }
    }
}
