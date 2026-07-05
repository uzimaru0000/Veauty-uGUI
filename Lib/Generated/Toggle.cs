
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Toggle"/> attributes, targeting <see cref="UnityEngine.UI.Toggle"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class ToggleAttribute<T> : GuiAttributeBase<UnityEngine.UI.Toggle, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected ToggleAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Toggle"/>.</summary>
    public partial class Toggle : GUIBase<UnityEngine.UI.Toggle>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Toggle(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.Toggle.group"/>.</summary>
        public class Group : ToggleAttribute<UnityEngine.UI.ToggleGroup>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>group</c>.</param>
            public Group(UnityEngine.UI.ToggleGroup value): base("group", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Toggle component)
            {
                component.group = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Toggle.isOn"/>.</summary>
        public class IsOn : ToggleAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>isOn</c>.</param>
            public IsOn(System.Boolean value): base("isOn", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Toggle component)
            {
                component.isOn = this.GetValue();
            }
        }
    }
}