
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="InputField"/> attributes, targeting <see cref="UnityEngine.UI.InputField"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class InputFieldAttribute<T> : GuiAttributeBase<UnityEngine.UI.InputField, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected InputFieldAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.InputField"/>.</summary>
    public partial class InputField : GUIBase<UnityEngine.UI.InputField>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public InputField(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.InputField.shouldHideMobileInput"/>.</summary>
        public class ShouldHideMobileInput : InputFieldAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>shouldHideMobileInput</c>.</param>
            public ShouldHideMobileInput(System.Boolean value): base("shouldHideMobileInput", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.shouldHideMobileInput = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.shouldActivateOnSelect"/>.</summary>
        public class ShouldActivateOnSelect : InputFieldAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>shouldActivateOnSelect</c>.</param>
            public ShouldActivateOnSelect(System.Boolean value): base("shouldActivateOnSelect", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.shouldActivateOnSelect = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.text"/>.</summary>
        public class Text : InputFieldAttribute<System.String>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>text</c>.</param>
            public Text(System.String value): base("text", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.text = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.caretBlinkRate"/>.</summary>
        public class CaretBlinkRate : InputFieldAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>caretBlinkRate</c>.</param>
            public CaretBlinkRate(System.Single value): base("caretBlinkRate", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretBlinkRate = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.caretWidth"/>.</summary>
        public class CaretWidth : InputFieldAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>caretWidth</c>.</param>
            public CaretWidth(System.Int32 value): base("caretWidth", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretWidth = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.textComponent"/>.</summary>
        public class TextComponent : InputFieldAttribute<UnityEngine.UI.Text>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>textComponent</c>.</param>
            public TextComponent(UnityEngine.UI.Text value): base("textComponent", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.textComponent = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.placeholder"/>.</summary>
        public class Placeholder : InputFieldAttribute<UnityEngine.UI.Graphic>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>placeholder</c>.</param>
            public Placeholder(UnityEngine.UI.Graphic value): base("placeholder", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.placeholder = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.caretColor"/>.</summary>
        public class CaretColor : InputFieldAttribute<UnityEngine.Color>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>caretColor</c>.</param>
            public CaretColor(UnityEngine.Color value): base("caretColor", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretColor = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.customCaretColor"/>.</summary>
        public class CustomCaretColor : InputFieldAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>customCaretColor</c>.</param>
            public CustomCaretColor(System.Boolean value): base("customCaretColor", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.customCaretColor = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.selectionColor"/>.</summary>
        public class SelectionColor : InputFieldAttribute<UnityEngine.Color>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>selectionColor</c>.</param>
            public SelectionColor(UnityEngine.Color value): base("selectionColor", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.selectionColor = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.onEndEdit"/>.</summary>
        public class OnEndEdit : InputFieldAttribute<UnityEngine.UI.InputField.EndEditEvent>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>onEndEdit</c>.</param>
            public OnEndEdit(UnityEngine.UI.InputField.EndEditEvent value): base("onEndEdit", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onEndEdit = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.onSubmit"/>.</summary>
        public class OnSubmit : InputFieldAttribute<UnityEngine.UI.InputField.SubmitEvent>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>onSubmit</c>.</param>
            public OnSubmit(UnityEngine.UI.InputField.SubmitEvent value): base("onSubmit", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onSubmit = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.onValueChanged"/>.</summary>
        public class OnValueChanged : InputFieldAttribute<UnityEngine.UI.InputField.OnChangeEvent>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>onValueChanged</c>.</param>
            public OnValueChanged(UnityEngine.UI.InputField.OnChangeEvent value): base("onValueChanged", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onValueChanged = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.onValidateInput"/>.</summary>
        public class OnValidateInput : InputFieldAttribute<UnityEngine.UI.InputField.OnValidateInput>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>onValidateInput</c>.</param>
            public OnValidateInput(UnityEngine.UI.InputField.OnValidateInput value): base("onValidateInput", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onValidateInput = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.characterLimit"/>.</summary>
        public class CharacterLimit : InputFieldAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>characterLimit</c>.</param>
            public CharacterLimit(System.Int32 value): base("characterLimit", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.characterLimit = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.contentType"/>.</summary>
        public class ContentType : InputFieldAttribute<UnityEngine.UI.InputField.ContentType>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>contentType</c>.</param>
            public ContentType(UnityEngine.UI.InputField.ContentType value): base("contentType", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.contentType = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.lineType"/>.</summary>
        public class LineType : InputFieldAttribute<UnityEngine.UI.InputField.LineType>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>lineType</c>.</param>
            public LineType(UnityEngine.UI.InputField.LineType value): base("lineType", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.lineType = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.inputType"/>.</summary>
        public class InputType : InputFieldAttribute<UnityEngine.UI.InputField.InputType>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>inputType</c>.</param>
            public InputType(UnityEngine.UI.InputField.InputType value): base("inputType", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.inputType = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.keyboardType"/>.</summary>
        public class KeyboardType : InputFieldAttribute<UnityEngine.TouchScreenKeyboardType>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>keyboardType</c>.</param>
            public KeyboardType(UnityEngine.TouchScreenKeyboardType value): base("keyboardType", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.keyboardType = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.characterValidation"/>.</summary>
        public class CharacterValidation : InputFieldAttribute<UnityEngine.UI.InputField.CharacterValidation>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>characterValidation</c>.</param>
            public CharacterValidation(UnityEngine.UI.InputField.CharacterValidation value): base("characterValidation", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.characterValidation = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.readOnly"/>.</summary>
        public class ReadOnly : InputFieldAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>readOnly</c>.</param>
            public ReadOnly(System.Boolean value): base("readOnly", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.readOnly = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.asteriskChar"/>.</summary>
        public class AsteriskChar : InputFieldAttribute<System.Char>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>asteriskChar</c>.</param>
            public AsteriskChar(System.Char value): base("asteriskChar", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.asteriskChar = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.caretPosition"/>.</summary>
        public class CaretPosition : InputFieldAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>caretPosition</c>.</param>
            public CaretPosition(System.Int32 value): base("caretPosition", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretPosition = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.selectionAnchorPosition"/>.</summary>
        public class SelectionAnchorPosition : InputFieldAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>selectionAnchorPosition</c>.</param>
            public SelectionAnchorPosition(System.Int32 value): base("selectionAnchorPosition", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.selectionAnchorPosition = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.InputField.selectionFocusPosition"/>.</summary>
        public class SelectionFocusPosition : InputFieldAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>selectionFocusPosition</c>.</param>
            public SelectionFocusPosition(System.Int32 value): base("selectionFocusPosition", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.selectionFocusPosition = this.GetValue();
            }
        }
    }
}