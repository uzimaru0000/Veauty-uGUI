
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class RaycastReceiverAttribute<T> : GuiAttributeBase<UnityEngine.UI.RaycastReceiver, T>
    {
        protected RaycastReceiverAttribute(string key, T value) : base(key, value) { }
    }

    public class RaycastReceiver : GUIBase<UnityEngine.UI.RaycastReceiver>
    {
        public RaycastReceiver(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        public class Color : RaycastReceiverAttribute<UnityEngine.Color>
        {
            public Color(UnityEngine.Color value): base("color", value) {}
            protected override void Apply(UnityEngine.UI.RaycastReceiver component)
            {
                component.color = this.GetValue();
            }
        }

        public class Material : RaycastReceiverAttribute<UnityEngine.Material>
        {
            public Material(UnityEngine.Material value): base("material", value) {}
            protected override void Apply(UnityEngine.UI.RaycastReceiver component)
            {
                component.material = this.GetValue();
            }
        }
    }
}
