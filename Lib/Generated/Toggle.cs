
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class ToggleAttribute<T> : GuiAttributeBase<UnityEngine.UI.Toggle, T>
    {
        protected ToggleAttribute(string key, T value) : base(key, value) { }
    }

    public class Toggle : GUIBase<UnityEngine.UI.Toggle>
    {
        public Toggle(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Group : ToggleAttribute<UnityEngine.UI.ToggleGroup>
        {
            public Group(UnityEngine.UI.ToggleGroup value): base("group", value) {}
            protected override void Apply(UnityEngine.UI.Toggle component)
            {
                component.group = this.GetValue();
            }
        }

        public class IsOn : ToggleAttribute<System.Boolean>
        {
            public IsOn(System.Boolean value): base("isOn", value) {}
            protected override void Apply(UnityEngine.UI.Toggle component)
            {
                component.isOn = this.GetValue();
            }
        }

    }
}