
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class HorizontalOrVerticalLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.HorizontalOrVerticalLayoutGroup, T>
    {
        protected HorizontalOrVerticalLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    public class HorizontalOrVerticalLayoutGroup : GUIBase<UnityEngine.UI.HorizontalOrVerticalLayoutGroup>
    {
        public HorizontalOrVerticalLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Spacing : HorizontalOrVerticalLayoutGroupAttribute<System.Single>
        {
            public Spacing(System.Single value): base("spacing", value) {}
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.spacing = this.GetValue();
            }
        }

        public class ChildForceExpandWidth : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            public ChildForceExpandWidth(System.Boolean value): base("childForceExpandWidth", value) {}
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childForceExpandWidth = this.GetValue();
            }
        }

        public class ChildForceExpandHeight : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            public ChildForceExpandHeight(System.Boolean value): base("childForceExpandHeight", value) {}
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childForceExpandHeight = this.GetValue();
            }
        }

        public class ChildControlWidth : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            public ChildControlWidth(System.Boolean value): base("childControlWidth", value) {}
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childControlWidth = this.GetValue();
            }
        }

        public class ChildControlHeight : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            public ChildControlHeight(System.Boolean value): base("childControlHeight", value) {}
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childControlHeight = this.GetValue();
            }
        }

        public class ChildScaleWidth : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            public ChildScaleWidth(System.Boolean value): base("childScaleWidth", value) {}
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childScaleWidth = this.GetValue();
            }
        }

        public class ChildScaleHeight : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            public ChildScaleHeight(System.Boolean value): base("childScaleHeight", value) {}
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.childScaleHeight = this.GetValue();
            }
        }

        public class ReverseArrangement : HorizontalOrVerticalLayoutGroupAttribute<System.Boolean>
        {
            public ReverseArrangement(System.Boolean value): base("reverseArrangement", value) {}
            protected override void Apply(UnityEngine.UI.HorizontalOrVerticalLayoutGroup component)
            {
                component.reverseArrangement = this.GetValue();
            }
        }

    }
}