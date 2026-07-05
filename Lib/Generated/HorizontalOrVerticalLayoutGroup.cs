
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="HorizontalOrVerticalLayoutGroup"/> attributes, targeting <see cref="UnityEngine.UI.HorizontalOrVerticalLayoutGroup"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class HorizontalOrVerticalLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.HorizontalOrVerticalLayoutGroup, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected HorizontalOrVerticalLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.HorizontalOrVerticalLayoutGroup"/>.</summary>
    public partial class HorizontalOrVerticalLayoutGroup : GUIBase<UnityEngine.UI.HorizontalOrVerticalLayoutGroup>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public HorizontalOrVerticalLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.HorizontalOrVerticalLayoutGroup.spacing"/>.</summary>
        public class Spacing : HorizontalOrVerticalLayoutGroupAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>spacing</c>.</param>
            public Spacing(System.Single value): base("spacing", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.spacing = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.HorizontalOrVerticalLayoutGroup.childForceExpandWidth"/>.</summary>
        public class ChildForceExpandWidth : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>childForceExpandWidth</c>.</param>
            public ChildForceExpandWidth(System.Boolean value): base("childForceExpandWidth", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childForceExpandWidth = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.HorizontalOrVerticalLayoutGroup.childForceExpandHeight"/>.</summary>
        public class ChildForceExpandHeight : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>childForceExpandHeight</c>.</param>
            public ChildForceExpandHeight(System.Boolean value): base("childForceExpandHeight", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childForceExpandHeight = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.HorizontalOrVerticalLayoutGroup.childControlWidth"/>.</summary>
        public class ChildControlWidth : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>childControlWidth</c>.</param>
            public ChildControlWidth(System.Boolean value): base("childControlWidth", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childControlWidth = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.HorizontalOrVerticalLayoutGroup.childControlHeight"/>.</summary>
        public class ChildControlHeight : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>childControlHeight</c>.</param>
            public ChildControlHeight(System.Boolean value): base("childControlHeight", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childControlHeight = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.HorizontalOrVerticalLayoutGroup.childScaleWidth"/>.</summary>
        public class ChildScaleWidth : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>childScaleWidth</c>.</param>
            public ChildScaleWidth(System.Boolean value): base("childScaleWidth", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childScaleWidth = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.HorizontalOrVerticalLayoutGroup.childScaleHeight"/>.</summary>
        public class ChildScaleHeight : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>childScaleHeight</c>.</param>
            public ChildScaleHeight(System.Boolean value): base("childScaleHeight", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childScaleHeight = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.HorizontalOrVerticalLayoutGroup.reverseArrangement"/>.</summary>
        public class ReverseArrangement : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>reverseArrangement</c>.</param>
            public ReverseArrangement(System.Boolean value): base("reverseArrangement", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.reverseArrangement = this.GetValue();
            }
        }
    }
}