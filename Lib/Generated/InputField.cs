
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class InputFieldAttribute<T> : GuiAttributeBase<UnityEngine.UI.InputField, T>
    {
        protected InputFieldAttribute(string key, T value) : base(key, value) { }
    }

    public class InputField : GUIBase<UnityEngine.UI.InputField>
    {
        public InputField(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class ShouldHideMobileInput : InputFieldAttribute<System.Boolean>
        {
            public ShouldHideMobileInput(System.Boolean value): base("shouldHideMobileInput", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.shouldHideMobileInput = this.GetValue();
            }
        }

        public class ShouldActivateOnSelect : InputFieldAttribute<System.Boolean>
        {
            public ShouldActivateOnSelect(System.Boolean value): base("shouldActivateOnSelect", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.shouldActivateOnSelect = this.GetValue();
            }
        }

        public class Text : InputFieldAttribute<System.String>
        {
            public Text(System.String value): base("text", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.text = this.GetValue();
            }
        }

        public class CaretBlinkRate : InputFieldAttribute<System.Single>
        {
            public CaretBlinkRate(System.Single value): base("caretBlinkRate", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretBlinkRate = this.GetValue();
            }
        }

        public class CaretWidth : InputFieldAttribute<System.Int32>
        {
            public CaretWidth(System.Int32 value): base("caretWidth", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretWidth = this.GetValue();
            }
        }

        public class TextComponent : InputFieldAttribute<UnityEngine.UI.Text>
        {
            public TextComponent(UnityEngine.UI.Text value): base("textComponent", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.textComponent = this.GetValue();
            }
        }

        public class Placeholder : InputFieldAttribute<UnityEngine.UI.Graphic>
        {
            public Placeholder(UnityEngine.UI.Graphic value): base("placeholder", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.placeholder = this.GetValue();
            }
        }

        public class CaretColor : InputFieldAttribute<UnityEngine.Color>
        {
            public CaretColor(UnityEngine.Color value): base("caretColor", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretColor = this.GetValue();
            }
        }

        public class CustomCaretColor : InputFieldAttribute<System.Boolean>
        {
            public CustomCaretColor(System.Boolean value): base("customCaretColor", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.customCaretColor = this.GetValue();
            }
        }

        public class SelectionColor : InputFieldAttribute<UnityEngine.Color>
        {
            public SelectionColor(UnityEngine.Color value): base("selectionColor", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.selectionColor = this.GetValue();
            }
        }

        public class OnEndEdit : InputFieldAttribute<UnityEngine.UI.InputField.SubmitEvent>
        {
            public OnEndEdit(UnityEngine.UI.InputField.SubmitEvent value): base("onEndEdit", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onEndEdit = this.GetValue();
            }
        }

        public class OnValueChange : InputFieldAttribute<UnityEngine.UI.InputField.OnChangeEvent>
        {
            public OnValueChange(UnityEngine.UI.InputField.OnChangeEvent value): base("onValueChange", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onValueChange = this.GetValue();
            }
        }

        public class OnValueChanged : InputFieldAttribute<UnityEngine.UI.InputField.OnChangeEvent>
        {
            public OnValueChanged(UnityEngine.UI.InputField.OnChangeEvent value): base("onValueChanged", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onValueChanged = this.GetValue();
            }
        }

        public class OnValidateInput : InputFieldAttribute<UnityEngine.UI.InputField.OnValidateInput>
        {
            public OnValidateInput(UnityEngine.UI.InputField.OnValidateInput value): base("onValidateInput", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onValidateInput = this.GetValue();
            }
        }

        public class CharacterLimit : InputFieldAttribute<System.Int32>
        {
            public CharacterLimit(System.Int32 value): base("characterLimit", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.characterLimit = this.GetValue();
            }
        }

        public class ContentType : InputFieldAttribute<UnityEngine.UI.InputField.ContentType>
        {
            public ContentType(UnityEngine.UI.InputField.ContentType value): base("contentType", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.contentType = this.GetValue();
            }
        }

        public class LineType : InputFieldAttribute<UnityEngine.UI.InputField.LineType>
        {
            public LineType(UnityEngine.UI.InputField.LineType value): base("lineType", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.lineType = this.GetValue();
            }
        }

        public class InputType : InputFieldAttribute<UnityEngine.UI.InputField.InputType>
        {
            public InputType(UnityEngine.UI.InputField.InputType value): base("inputType", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.inputType = this.GetValue();
            }
        }

        public class KeyboardType : InputFieldAttribute<UnityEngine.TouchScreenKeyboardType>
        {
            public KeyboardType(UnityEngine.TouchScreenKeyboardType value): base("keyboardType", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.keyboardType = this.GetValue();
            }
        }

        public class CharacterValidation : InputFieldAttribute<UnityEngine.UI.InputField.CharacterValidation>
        {
            public CharacterValidation(UnityEngine.UI.InputField.CharacterValidation value): base("characterValidation", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.characterValidation = this.GetValue();
            }
        }

        public class ReadOnly : InputFieldAttribute<System.Boolean>
        {
            public ReadOnly(System.Boolean value): base("readOnly", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.readOnly = this.GetValue();
            }
        }

        public class AsteriskChar : InputFieldAttribute<System.Char>
        {
            public AsteriskChar(System.Char value): base("asteriskChar", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.asteriskChar = this.GetValue();
            }
        }

        public class CaretPosition : InputFieldAttribute<System.Int32>
        {
            public CaretPosition(System.Int32 value): base("caretPosition", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.caretPosition = this.GetValue();
            }
        }

        public class SelectionAnchorPosition : InputFieldAttribute<System.Int32>
        {
            public SelectionAnchorPosition(System.Int32 value): base("selectionAnchorPosition", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.selectionAnchorPosition = this.GetValue();
            }
        }

        public class SelectionFocusPosition : InputFieldAttribute<System.Int32>
        {
            public SelectionFocusPosition(System.Int32 value): base("selectionFocusPosition", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.selectionFocusPosition = this.GetValue();
            }
        }

    }
}