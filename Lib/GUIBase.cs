using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class GUIBase<T> : Widget<UnityEngine.GameObject> where T : UnityEngine.Component
    {
        protected GUIBase(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override IVTree Render() => new Node<UnityEngine.GameObject, T>(typeof(T).FullName, attrs, kids);
    }

    public abstract class GuiAttributeBase<T1, T2> : Attribute<UnityEngine.GameObject, T2> where T1 : UnityEngine.Component
    {
        protected GuiAttributeBase(string key, T2 value) : base(key, value) { }
        protected abstract void Apply(T1 component);
        public override void Apply(UnityEngine.GameObject obj)
        {
            var component = obj.GetComponent<T1>();
            if (component)
            {
                Apply(component);
            }
        }
    }
}