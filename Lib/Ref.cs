using UnityEngine;
using Veauty;

namespace Veauty.uGUI
{
    /// <summary>
    /// Attribute that captures the rendered target object instead of setting a value on it. Add it
    /// to a widget's attribute list and read <see cref="current"/> after rendering to get the
    /// underlying <see cref="UnityEngine.GameObject"/>.
    /// </summary>
    /// <typeparam name="T">The captured object type. For uGUI widgets this is
    /// <see cref="UnityEngine.GameObject"/>.</typeparam>
    /// <remarks>
    /// The attribute key includes the instance hash code (<c>"ref:" + GetHashCode()</c>), so two
    /// different Ref instances never collide, but a <i>new</i> Ref instance on each render is seen
    /// as a changed attribute and is re-applied. <see cref="current"/> keeps its default value
    /// until the attribute is applied during rendering.
    /// </remarks>
    /// <example>
    /// <code>
    /// var buttonRef = new Ref&lt;UnityEngine.GameObject&gt;();
    /// var tree = V.Button(extras: new IAttribute&lt;UnityEngine.GameObject&gt;[] { buttonRef })[
    ///     V.Text("Click")
    /// ];
    /// // after mounting: buttonRef.current is the Button's GameObject
    /// </code>
    /// </example>
    public class Ref<T> : IAttribute<T>
    {
        /// <summary>The most recently captured object, or the constructor default before the
        /// attribute has been applied.</summary>
        public T current;

        /// <summary>Creates a ref whose <see cref="current"/> starts at
        /// <paramref name="defaultValue"/>.</summary>
        /// <param name="defaultValue">Initial value of <see cref="current"/>.</param>
        public Ref(T defaultValue = default(T))
        {
            current = defaultValue;
        }

        /// <summary>Returns the per-instance attribute key (<c>"ref:" + GetHashCode()</c>).</summary>
        public string GetKey() => "ref:" + GetHashCode();

        /// <summary>Stores <paramref name="obj"/> in <see cref="current"/>.</summary>
        /// <param name="obj">The rendered target object.</param>
        public void Apply(T obj)
        {
            this.current = obj;
        }
    }
}

/// <summary>
/// Global-namespace alias of <see cref="Veauty.uGUI.Ref{T}"/> so user code can write
/// <c>new Ref&lt;GameObject&gt;()</c> without a <c>using Veauty.uGUI;</c> directive.
/// </summary>
/// <typeparam name="T">The captured object type.</typeparam>
/// <remarks>This type lives in the global namespace on purpose. It adds no behavior; prefer
/// <see cref="Veauty.uGUI.Ref{T}"/> in library code to avoid ambiguity.</remarks>
public class Ref<T> : Veauty.uGUI.Ref<T>
{
    /// <summary>Creates a ref whose <c>current</c> starts at <paramref name="defaultValue"/>.</summary>
    /// <param name="defaultValue">Initial value of <c>current</c>.</param>
    public Ref(T defaultValue = default(T)) : base(defaultValue)
    {
    }
}
