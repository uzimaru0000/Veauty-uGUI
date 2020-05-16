using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class GUIBase<T> : Widget where T : UnityEngine.Component
    {
        private string tag;
        public IAttribute[] attrs;
        public IVTree[] kids;
        
        public GUIBase(string tag, IAttribute[] attrs, IVTree[] kids)
        {
            this.tag = tag;
            this.attrs = attrs;
            this.kids = kids;
        }

        public override IVTree Render() => new Node<T>(tag, attrs, kids);
        
        public override IVTree[] GetKids() => this.kids;
    }

    public abstract class GUIAttributeBase<T, U> : IAttribute
    where T : UnityEngine.Component
    {
        private string key;
        protected U value;
        
        protected GUIAttributeBase(string key, U value)
        {
            this.key = key;
            this.value = value;
        }
        protected abstract void Apply(T component);
        public string GetKey() => this.key;
        public void Apply(UnityEngine.GameObject obj)
        {
            var component = obj.GetComponent<T>();
            if (component)
            {
                Apply(component);
            }
        }
        public bool Equals(IAttribute attr)
        {
            if (attr is GUIAttributeBase<T, U> other)
            {
                return this.value.Equals(other.value);
            }

            return false;
        }
    }
}