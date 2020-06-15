using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class GUIBase<T> : Widget where T : UnityEngine.Component
    {
        private string tag;
        private IAttribute[] attrs;
        private IVTree[] kids;

        protected GUIBase(string tag, IAttribute[] attrs, IVTree[] kids)
        {
            this.tag = tag;
            this.attrs = attrs;
            this.kids = kids;
        }

        public override IVTree Render() => new Node<T>(tag, attrs, kids);
        
        public override IVTree[] GetKids() => this.kids;
    }

    public abstract class GuiAttributeBase<T1, T2> : Attribute<T2>
    where T1 : UnityEngine.Component
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