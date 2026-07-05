
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="ToggleGroup"/> attributes, targeting <see cref="UnityEngine.UI.ToggleGroup"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class ToggleGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.ToggleGroup, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected ToggleGroupAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.ToggleGroup"/>.</summary>
    public partial class ToggleGroup : GUIBase<UnityEngine.UI.ToggleGroup>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public ToggleGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.ToggleGroup.allowSwitchOff"/>.</summary>
        public class AllowSwitchOff : ToggleGroupAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>allowSwitchOff</c>.</param>
            public AllowSwitchOff(System.Boolean value): base("allowSwitchOff", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ToggleGroup component)
            {
                component.allowSwitchOff = this.GetValue();
            }
        }
    }
}