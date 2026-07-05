
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="LayoutGroup"/> attributes, targeting <see cref="UnityEngine.UI.LayoutGroup"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class LayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.LayoutGroup, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected LayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.LayoutGroup"/>.</summary>
    public partial class LayoutGroup : GUIBase<UnityEngine.UI.LayoutGroup>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public LayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.LayoutGroup.padding"/>.</summary>
        public class Padding : LayoutGroupAttribute<UnityEngine.RectOffset>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>padding</c>.</param>
            public Padding(UnityEngine.RectOffset value): base("padding", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.LayoutGroup component)
            {
                component.padding = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.LayoutGroup.childAlignment"/>.</summary>
        public class ChildAlignment : LayoutGroupAttribute<UnityEngine.TextAnchor>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>childAlignment</c>.</param>
            public ChildAlignment(UnityEngine.TextAnchor value): base("childAlignment", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.LayoutGroup component)
            {
                component.childAlignment = this.GetValue();
            }
        }
    }
}