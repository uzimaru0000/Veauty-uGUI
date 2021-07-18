using UnityEngine;
using Veauty;

public class Ref<T> : IAttribute<T>
{
    public T current;

    public Ref(T defaultValue = default(T))
    {
        current = defaultValue;
    }

    public string GetKey() => this.current != null ? this.current.GetHashCode().ToString() : "ref";
    public void Apply(T obj)
    {
        this.current = obj;
    }
}
