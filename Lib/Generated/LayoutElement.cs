
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="LayoutElement"/> attributes, targeting <see cref="UnityEngine.UI.LayoutElement"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class LayoutElementAttribute<T> : GuiAttributeBase<UnityEngine.UI.LayoutElement, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected LayoutElementAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.LayoutElement"/>.</summary>
    public partial class LayoutElement : GUIBase<UnityEngine.UI.LayoutElement>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public LayoutElement(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.LayoutElement.ignoreLayout"/>.</summary>
        public class IgnoreLayout : LayoutElementAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>ignoreLayout</c>.</param>
            public IgnoreLayout(System.Boolean value): base("ignoreLayout", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.ignoreLayout = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.LayoutElement.minWidth"/>.</summary>
        public class MinWidth : LayoutElementAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>minWidth</c>.</param>
            public MinWidth(System.Single value): base("minWidth", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.minWidth = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.LayoutElement.minHeight"/>.</summary>
        public class MinHeight : LayoutElementAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>minHeight</c>.</param>
            public MinHeight(System.Single value): base("minHeight", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.minHeight = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.LayoutElement.preferredWidth"/>.</summary>
        public class PreferredWidth : LayoutElementAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>preferredWidth</c>.</param>
            public PreferredWidth(System.Single value): base("preferredWidth", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.preferredWidth = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.LayoutElement.preferredHeight"/>.</summary>
        public class PreferredHeight : LayoutElementAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>preferredHeight</c>.</param>
            public PreferredHeight(System.Single value): base("preferredHeight", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.preferredHeight = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.LayoutElement.flexibleWidth"/>.</summary>
        public class FlexibleWidth : LayoutElementAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>flexibleWidth</c>.</param>
            public FlexibleWidth(System.Single value): base("flexibleWidth", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.flexibleWidth = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.LayoutElement.flexibleHeight"/>.</summary>
        public class FlexibleHeight : LayoutElementAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>flexibleHeight</c>.</param>
            public FlexibleHeight(System.Single value): base("flexibleHeight", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.flexibleHeight = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.LayoutElement.layoutPriority"/>.</summary>
        public class LayoutPriority : LayoutElementAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>layoutPriority</c>.</param>
            public LayoutPriority(System.Int32 value): base("layoutPriority", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.LayoutElement component)
            {
                component.layoutPriority = this.GetValue();
            }
        }
    }
}