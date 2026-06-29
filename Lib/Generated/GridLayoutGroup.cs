
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class GridLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.GridLayoutGroup, T>
    {
        protected GridLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    public partial class GridLayoutGroup : GUIBase<UnityEngine.UI.GridLayoutGroup>
    {
        public GridLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class StartCorner : GridLayoutGroupAttribute<UnityEngine.UI.GridLayoutGroup.Corner>
        {
            public StartCorner(UnityEngine.UI.GridLayoutGroup.Corner value): base("startCorner", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.startCorner = this.GetValue();
            }
        }

        public partial class StartAxis : GridLayoutGroupAttribute<UnityEngine.UI.GridLayoutGroup.Axis>
        {
            public StartAxis(UnityEngine.UI.GridLayoutGroup.Axis value): base("startAxis", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.startAxis = this.GetValue();
            }
        }

        public partial class CellSize : GridLayoutGroupAttribute<UnityEngine.Vector2>
        {
            public CellSize(UnityEngine.Vector2 value): base("cellSize", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.cellSize = this.GetValue();
            }
        }

        public partial class Spacing : GridLayoutGroupAttribute<UnityEngine.Vector2>
        {
            public Spacing(UnityEngine.Vector2 value): base("spacing", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.spacing = this.GetValue();
            }
        }

        public partial class Constraint : GridLayoutGroupAttribute<UnityEngine.UI.GridLayoutGroup.Constraint>
        {
            public Constraint(UnityEngine.UI.GridLayoutGroup.Constraint value): base("constraint", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.constraint = this.GetValue();
            }
        }

        public partial class ConstraintCount : GridLayoutGroupAttribute<System.Int32>
        {
            public ConstraintCount(System.Int32 value): base("constraintCount", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.constraintCount = this.GetValue();
            }
        }
    }
}