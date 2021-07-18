
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class GridLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.GridLayoutGroup, T>
    {
        protected GridLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    public class GridLayoutGroup : GUIBase<UnityEngine.UI.GridLayoutGroup>
    {
        public GridLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class StartCorner : GridLayoutGroupAttribute<UnityEngine.UI.GridLayoutGroup.Corner>
        {
            public StartCorner(UnityEngine.UI.GridLayoutGroup.Corner value): base("startCorner", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.startCorner = this.GetValue();
            }
        }

        public class StartAxis : GridLayoutGroupAttribute<UnityEngine.UI.GridLayoutGroup.Axis>
        {
            public StartAxis(UnityEngine.UI.GridLayoutGroup.Axis value): base("startAxis", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.startAxis = this.GetValue();
            }
        }

        public class CellSize : GridLayoutGroupAttribute<UnityEngine.Vector2>
        {
            public CellSize(UnityEngine.Vector2 value): base("cellSize", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.cellSize = this.GetValue();
            }
        }

        public class Spacing : GridLayoutGroupAttribute<UnityEngine.Vector2>
        {
            public Spacing(UnityEngine.Vector2 value): base("spacing", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.spacing = this.GetValue();
            }
        }

        public class Constraint : GridLayoutGroupAttribute<UnityEngine.UI.GridLayoutGroup.Constraint>
        {
            public Constraint(UnityEngine.UI.GridLayoutGroup.Constraint value): base("constraint", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.constraint = this.GetValue();
            }
        }

        public class ConstraintCount : GridLayoutGroupAttribute<System.Int32>
        {
            public ConstraintCount(System.Int32 value): base("constraintCount", value) {}
            protected override void Apply(UnityEngine.UI.GridLayoutGroup component)
            {
                component.constraintCount = this.GetValue();
            }
        }

    }
}