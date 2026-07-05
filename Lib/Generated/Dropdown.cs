
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Dropdown"/> attributes, targeting <see cref="UnityEngine.UI.Dropdown"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class DropdownAttribute<T> : GuiAttributeBase<UnityEngine.UI.Dropdown, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected DropdownAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Dropdown"/>.</summary>
    public partial class Dropdown : GUIBase<UnityEngine.UI.Dropdown>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Dropdown(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.Dropdown.template"/>.</summary>
        public class Template : DropdownAttribute<UnityEngine.RectTransform>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>template</c>.</param>
            public Template(UnityEngine.RectTransform value): base("template", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.template = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Dropdown.captionText"/>.</summary>
        public class CaptionText : DropdownAttribute<UnityEngine.UI.Text>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>captionText</c>.</param>
            public CaptionText(UnityEngine.UI.Text value): base("captionText", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.captionText = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Dropdown.captionImage"/>.</summary>
        public class CaptionImage : DropdownAttribute<UnityEngine.UI.Image>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>captionImage</c>.</param>
            public CaptionImage(UnityEngine.UI.Image value): base("captionImage", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.captionImage = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Dropdown.itemText"/>.</summary>
        public class ItemText : DropdownAttribute<UnityEngine.UI.Text>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>itemText</c>.</param>
            public ItemText(UnityEngine.UI.Text value): base("itemText", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.itemText = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Dropdown.itemImage"/>.</summary>
        public class ItemImage : DropdownAttribute<UnityEngine.UI.Image>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>itemImage</c>.</param>
            public ItemImage(UnityEngine.UI.Image value): base("itemImage", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.itemImage = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Dropdown.options"/>.</summary>
        public class Options : DropdownAttribute<System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData>>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>options</c>.</param>
            public Options(System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData> value): base("options", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.options = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Dropdown.onValueChanged"/>.</summary>
        public class OnValueChanged : DropdownAttribute<UnityEngine.UI.Dropdown.DropdownEvent>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>onValueChanged</c>.</param>
            public OnValueChanged(UnityEngine.UI.Dropdown.DropdownEvent value): base("onValueChanged", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.onValueChanged = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Dropdown.alphaFadeSpeed"/>.</summary>
        public class AlphaFadeSpeed : DropdownAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>alphaFadeSpeed</c>.</param>
            public AlphaFadeSpeed(System.Single value): base("alphaFadeSpeed", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.alphaFadeSpeed = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Dropdown.value"/>.</summary>
        public class Value : DropdownAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>value</c>.</param>
            public Value(System.Int32 value): base("value", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.value = this.GetValue();
            }
        }
    }
}