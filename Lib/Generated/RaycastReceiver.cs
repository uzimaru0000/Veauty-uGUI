
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="RaycastReceiver"/> attributes, targeting <see cref="UnityEngine.UI.RaycastReceiver"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class RaycastReceiverAttribute<T> : GuiAttributeBase<UnityEngine.UI.RaycastReceiver, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected RaycastReceiverAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.RaycastReceiver"/>.</summary>
    public partial class RaycastReceiver : GUIBase<UnityEngine.UI.RaycastReceiver>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public RaycastReceiver(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.RaycastReceiver.material"/>.</summary>
        public class Material : RaycastReceiverAttribute<UnityEngine.Material>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>material</c>.</param>
            public Material(UnityEngine.Material value): base("material", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.RaycastReceiver component)
            {
                component.material = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.RaycastReceiver.color"/>.</summary>
        public class Color : RaycastReceiverAttribute<UnityEngine.Color>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>color</c>.</param>
            public Color(UnityEngine.Color value): base("color", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.RaycastReceiver component)
            {
                component.color = this.GetValue();
            }
        }
    }
}