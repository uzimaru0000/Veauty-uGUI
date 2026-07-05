
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Button"/> attributes, targeting <see cref="UnityEngine.UI.Button"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class ButtonAttribute<T> : GuiAttributeBase<UnityEngine.UI.Button, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected ButtonAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Button"/>.</summary>
    public partial class Button : GUIBase<UnityEngine.UI.Button>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Button(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets the click handler: removes all existing listeners from <see cref="UnityEngine.UI.Button.onClick"/> and adds the given one.</summary>
        public class OnClick : ButtonAttribute<UnityEngine.Events.UnityAction>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The listener invoked on click.</param>
            public OnClick(UnityEngine.Events.UnityAction value): base("onClick", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Button component)
            {
                component.onClick.RemoveAllListeners();
                component.onClick.AddListener(GetValue());
            }
        }
    }
}