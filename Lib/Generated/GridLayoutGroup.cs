
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="GridLayoutGroup"/> attributes, targeting <see cref="UnityEngine.UI.GridLayoutGroup"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class GridLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.GridLayoutGroup, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected GridLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.GridLayoutGroup"/>.</summary>
    public partial class GridLayoutGroup : GUIBase<UnityEngine.UI.GridLayoutGroup>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public GridLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.GridLayoutGroup.startCorner"/>.</summary>
        public class StartCorner : GridLayoutGroupAttribute<UnityEngine.UI.GridLayoutGroup.Corner>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>startCorner</c>.</param>
            public StartCorner(UnityEngine.UI.GridLayoutGroup.Corner value): base("startCorner", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.startCorner = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.GridLayoutGroup.startAxis"/>.</summary>
        public class StartAxis : GridLayoutGroupAttribute<UnityEngine.UI.GridLayoutGroup.Axis>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>startAxis</c>.</param>
            public StartAxis(UnityEngine.UI.GridLayoutGroup.Axis value): base("startAxis", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.startAxis = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.GridLayoutGroup.cellSize"/>.</summary>
        public class CellSize : GridLayoutGroupAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>cellSize</c>.</param>
            public CellSize(UnityEngine.Vector2 value): base("cellSize", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.cellSize = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.GridLayoutGroup.spacing"/>.</summary>
        public class Spacing : GridLayoutGroupAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>spacing</c>.</param>
            public Spacing(UnityEngine.Vector2 value): base("spacing", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.spacing = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.GridLayoutGroup.constraint"/>.</summary>
        public class Constraint : GridLayoutGroupAttribute<UnityEngine.UI.GridLayoutGroup.Constraint>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>constraint</c>.</param>
            public Constraint(UnityEngine.UI.GridLayoutGroup.Constraint value): base("constraint", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.constraint = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.GridLayoutGroup.constraintCount"/>.</summary>
        public class ConstraintCount : GridLayoutGroupAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>constraintCount</c>.</param>
            public ConstraintCount(System.Int32 value): base("constraintCount", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.constraintCount = this.GetValue();
            }
        }
    }
}