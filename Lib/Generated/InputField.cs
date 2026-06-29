
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class InputFieldAttribute<T> : GuiAttributeBase<UnityEngine.UI.InputField, T>
    {
        protected InputFieldAttribute(string key, T value) : base(key, value) { }
    }

    public partial class InputField : GUIBase<UnityEngine.UI.InputField>
    {
        public InputField(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class ShouldHideMobileInput : InputFieldAttribute<System.Boolean>
        {
            public ShouldHideMobileInput(System.Boolean value): base("shouldHideMobileInput", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.shouldHideMobileInput = this.GetValue();
            }
        }

        public partial class ShouldActivateOnSelect : InputFieldAttribute<System.Boolean>
        {
            public ShouldActivateOnSelect(System.Boolean value): base("shouldActivateOnSelect", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.shouldActivateOnSelect = this.GetValue();
            }
        }

        public partial class Text : InputFieldAttribute<System.String>
        {
            public Text(System.String value): base("text", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.text = this.GetValue();
            }
        }

        public partial class CaretBlinkRate : InputFieldAttribute<System.Single>
        {
            public CaretBlinkRate(System.Single value): base("caretBlinkRate", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretBlinkRate = this.GetValue();
            }
        }

        public partial class CaretWidth : InputFieldAttribute<System.Int32>
        {
            public CaretWidth(System.Int32 value): base("caretWidth", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretWidth = this.GetValue();
            }
        }

        public partial class TextComponent : InputFieldAttribute<UnityEngine.UI.Text>
        {
            public TextComponent(UnityEngine.UI.Text value): base("textComponent", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.textComponent = this.GetValue();
            }
        }

        public partial class Placeholder : InputFieldAttribute<UnityEngine.UI.Graphic>
        {
            public Placeholder(UnityEngine.UI.Graphic value): base("placeholder", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.placeholder = this.GetValue();
            }
        }

        public partial class CaretColor : InputFieldAttribute<UnityEngine.Color>
        {
            public CaretColor(UnityEngine.Color value): base("caretColor", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretColor = this.GetValue();
            }
        }

        public partial class CustomCaretColor : InputFieldAttribute<System.Boolean>
        {
            public CustomCaretColor(System.Boolean value): base("customCaretColor", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.customCaretColor = this.GetValue();
            }
        }

        public partial class SelectionColor : InputFieldAttribute<UnityEngine.Color>
        {
            public SelectionColor(UnityEngine.Color value): base("selectionColor", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.selectionColor = this.GetValue();
            }
        }

        public partial class OnEndEdit : InputFieldAttribute<UnityEngine.UI.InputField.EndEditEvent>
        {
            public OnEndEdit(UnityEngine.UI.InputField.EndEditEvent value): base("onEndEdit", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onEndEdit = this.GetValue();
            }
        }

        public partial class OnSubmit : InputFieldAttribute<UnityEngine.UI.InputField.SubmitEvent>
        {
            public OnSubmit(UnityEngine.UI.InputField.SubmitEvent value): base("onSubmit", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onSubmit = this.GetValue();
            }
        }

        public partial class OnValueChanged : InputFieldAttribute<UnityEngine.UI.InputField.OnChangeEvent>
        {
            public OnValueChanged(UnityEngine.UI.InputField.OnChangeEvent value): base("onValueChanged", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onValueChanged = this.GetValue();
            }
        }

        public partial class OnValidateInput : InputFieldAttribute<UnityEngine.UI.InputField.OnValidateInput>
        {
            public OnValidateInput(UnityEngine.UI.InputField.OnValidateInput value): base("onValidateInput", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onValidateInput = this.GetValue();
            }
        }

        public partial class CharacterLimit : InputFieldAttribute<System.Int32>
        {
            public CharacterLimit(System.Int32 value): base("characterLimit", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.characterLimit = this.GetValue();
            }
        }

        public partial class ContentType : InputFieldAttribute<UnityEngine.UI.InputField.ContentType>
        {
            public ContentType(UnityEngine.UI.InputField.ContentType value): base("contentType", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.contentType = this.GetValue();
            }
        }

        public partial class LineType : InputFieldAttribute<UnityEngine.UI.InputField.LineType>
        {
            public LineType(UnityEngine.UI.InputField.LineType value): base("lineType", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.lineType = this.GetValue();
            }
        }

        public partial class InputType : InputFieldAttribute<UnityEngine.UI.InputField.InputType>
        {
            public InputType(UnityEngine.UI.InputField.InputType value): base("inputType", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.inputType = this.GetValue();
            }
        }

        public partial class KeyboardType : InputFieldAttribute<UnityEngine.TouchScreenKeyboardType>
        {
            public KeyboardType(UnityEngine.TouchScreenKeyboardType value): base("keyboardType", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.keyboardType = this.GetValue();
            }
        }

        public partial class CharacterValidation : InputFieldAttribute<UnityEngine.UI.InputField.CharacterValidation>
        {
            public CharacterValidation(UnityEngine.UI.InputField.CharacterValidation value): base("characterValidation", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.characterValidation = this.GetValue();
            }
        }

        public partial class ReadOnly : InputFieldAttribute<System.Boolean>
        {
            public ReadOnly(System.Boolean value): base("readOnly", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.readOnly = this.GetValue();
            }
        }

        public partial class AsteriskChar : InputFieldAttribute<System.Char>
        {
            public AsteriskChar(System.Char value): base("asteriskChar", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.asteriskChar = this.GetValue();
            }
        }

        public partial class CaretPosition : InputFieldAttribute<System.Int32>
        {
            public CaretPosition(System.Int32 value): base("caretPosition", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretPosition = this.GetValue();
            }
        }

        public partial class SelectionAnchorPosition : InputFieldAttribute<System.Int32>
        {
            public SelectionAnchorPosition(System.Int32 value): base("selectionAnchorPosition", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.selectionAnchorPosition = this.GetValue();
            }
        }

        public partial class SelectionFocusPosition : InputFieldAttribute<System.Int32>
        {
            public SelectionFocusPosition(System.Int32 value): base("selectionFocusPosition", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.selectionFocusPosition = this.GetValue();
            }
        }
    }
}