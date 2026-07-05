using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="RectTransform"/> attributes, targeting <see cref="UnityEngine.RectTransform"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    /// <remarks>In uGUI mode every rendered GameObject already has a RectTransform, so these
    /// attributes can be used on any widget (pass them via <c>extras</c> in the Presets API).</remarks>
    public abstract class RectTransformAttribute<T> : GuiAttributeBase<UnityEngine.RectTransform, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected RectTransformAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>
    /// Veauty widget for <see cref="UnityEngine.RectTransform"/> (hand-written; not emitted by the
    /// code generator). Useful as a plain container node; its nested attribute classes are more
    /// commonly passed to other widgets to position them.
    /// </summary>
    public partial class RectTransform : GUIBase<UnityEngine.RectTransform>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public RectTransform(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        /// <summary>Sets <see cref="UnityEngine.RectTransform.anchorMin"/>.</summary>
        public class AnchorMin : RectTransformAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>anchorMin</c>.</param>
            public AnchorMin(UnityEngine.Vector2 value) : base("anchorMin", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.anchorMin = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.RectTransform.anchorMax"/>.</summary>
        public class AnchorMax : RectTransformAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>anchorMax</c>.</param>
            public AnchorMax(UnityEngine.Vector2 value) : base("anchorMax", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.anchorMax = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.RectTransform.anchoredPosition"/>.</summary>
        public class AnchoredPosition : RectTransformAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>anchoredPosition</c>.</param>
            public AnchoredPosition(UnityEngine.Vector2 value) : base("anchoredPosition", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.anchoredPosition = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.RectTransform.anchoredPosition3D"/>.</summary>
        public class AnchoredPosition3D : RectTransformAttribute<UnityEngine.Vector3>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>anchoredPosition3D</c>.</param>
            public AnchoredPosition3D(UnityEngine.Vector3 value) : base("anchoredPosition3D", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.anchoredPosition3D = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.RectTransform.sizeDelta"/>.</summary>
        public class SizeDelta : RectTransformAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>sizeDelta</c>.</param>
            public SizeDelta(UnityEngine.Vector2 value) : base("sizeDelta", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.sizeDelta = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.RectTransform.pivot"/>.</summary>
        public class Pivot : RectTransformAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>pivot</c>.</param>
            public Pivot(UnityEngine.Vector2 value) : base("pivot", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.pivot = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.RectTransform.offsetMin"/>.</summary>
        public class OffsetMin : RectTransformAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>offsetMin</c>.</param>
            public OffsetMin(UnityEngine.Vector2 value) : base("offsetMin", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.offsetMin = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.RectTransform.offsetMax"/>.</summary>
        public class OffsetMax : RectTransformAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>offsetMax</c>.</param>
            public OffsetMax(UnityEngine.Vector2 value) : base("offsetMax", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.offsetMax = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.RectTransform.sendChildDimensionsChange"/>.</summary>
        public class SendChildDimensionsChange : RectTransformAttribute<bool>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>sendChildDimensionsChange</c>.</param>
            public SendChildDimensionsChange(bool value) : base("sendChildDimensionsChange", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.sendChildDimensionsChange = this.GetValue();
            }
        }
    }
}
