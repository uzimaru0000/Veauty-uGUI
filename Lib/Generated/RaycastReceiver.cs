
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

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


        public class Material : RaycastReceiverAttribute<UnityEngine.Material>
        {
            public Material(UnityEngine.Material value): base("material", value) {}
            protected override void Apply(UnityEngine.UI.RaycastReceiver component)
            {
                component.material = this.GetValue();
            }
        }

        public class Color : RaycastReceiverAttribute<UnityEngine.Color>
        {
            public Color(UnityEngine.Color value): base("color", value) {}
            protected override void Apply(UnityEngine.UI.RaycastReceiver component)
            {
                component.color = this.GetValue();
            }
        }
    }
}