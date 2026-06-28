using UnityEngine;
using Veauty;

namespace Veauty.uGUI
{
    public class Ref<T> : IAttribute<T>
    {
        public T current;

        public Ref(T defaultValue = default(T))
        {
            current = defaultValue;
        }

        public string GetKey() => "ref:" + GetHashCode();

        public void Apply(T obj)
        {
            this.current = obj;
        }
    }
}

public class Ref<T> : Veauty.uGUI.Ref<T>
{
    public Ref(T defaultValue = default(T)) : base(defaultValue)
    {
    }
}
