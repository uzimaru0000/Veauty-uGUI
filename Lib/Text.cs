using System.Linq;
using Veauty.VTree;
using UnityEngine;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;

namespace Veauty.uGUI
{
    public abstract class TextAttribute<T> : GuiAttributeBase<UI.Text, T>
    {
        protected TextAttribute(string key, T value): base(key, value) { }
    }
    
    public class Text : GUIBase<UI.Text>
    {
        public Text(string value, IAttribute[] attrs) : base("Text", attrs.Append(new Value(value)).ToArray(), new IVTree[0]) { }

        public Text(string value) : base("Text", new IAttribute[] {new Value(value)}, new IVTree[0]) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var textComponent = go.GetComponent<UI.Text>();
            textComponent.font = Resources.GetBuiltinResource<UnityEngine.Font>("Arial.ttf");
            
            return go;
        }

        public override void Destroy(UnityEngine.GameObject go) { }
        
        public class Value : TextAttribute<string>
        {
            public Value(string text): base("TextValue", text) { }
            protected override void Apply(UI.Text text) => text.text = this.GetValue();
        }

        public class Font : TextAttribute<UnityEngine.Font>
        {
            public Font(UnityEngine.Font font) : base("TextFont", font) { }
            protected override void Apply(UI.Text text) => text.font = this.GetValue();
        }

        public class Alignment : TextAttribute<UnityEngine.TextAnchor>
        {
            public Alignment(UnityEngine.TextAnchor anchor) : base("TextAlignment", anchor) {}
            protected override void Apply(UI.Text text) => text.alignment = this.GetValue();
        }
        
        public class FontSize : TextAttribute<int>
        {
            public FontSize(int value) : base("TextFontSize", value)
            {
            }

            protected override void Apply(UI.Text component) => component.fontSize = this.GetValue();
        }

        public class FontStyle : TextAttribute<UnityEngine.FontStyle>
        {
            public FontStyle(UnityEngine.FontStyle value) : base("TextFontStyle", value)
            {
            }

            protected override void Apply(UI.Text component) => component.fontStyle = this.GetValue();
        }

        public class HorizontalOverflow : TextAttribute<UnityEngine.HorizontalWrapMode>
        {
            public HorizontalOverflow(HorizontalWrapMode value) : base("TextHorizontalOverflow", value)
            {
            }

            protected override void Apply(UI.Text component) => component.horizontalOverflow = this.GetValue();
        }
        
        public class LineSpacing : TextAttribute<float>
        {
            public LineSpacing(float value) : base("TextLineSpacing", value)
            {
            }

            protected override void Apply(UI.Text component) => component.lineSpacing = this.GetValue();
        }

        public class ResizeTextForBestFit : TextAttribute<bool>
        {
            public ResizeTextForBestFit(bool value) : base("ResizeTextForBestFit", value)
            {
            }

            protected override void Apply(UI.Text component) => component.resizeTextForBestFit = this.GetValue();
        }

        public class ResizeTextMaxSize : TextAttribute<int>
        {
            public ResizeTextMaxSize(int value) : base("TextResizeTextMaxSize", value)
            {
            }

            protected override void Apply(UI.Text component) => component.resizeTextMaxSize = this.GetValue();
        }
        
        public class ResizeTextMinSize : TextAttribute<int>
        {
            public ResizeTextMinSize(int value) : base("ResizeTextMinSize", value)
            {
            }

            protected override void Apply(UI.Text component) => component.resizeTextMinSize = this.GetValue();
        }

        public class SupportRichText : TextAttribute<bool>
        {
            public SupportRichText(bool value) : base("TextSupportRichText", value)
            {
            }

            protected override void Apply(UI.Text component) => component.supportRichText = this.GetValue();
        }

        public class VerticalOverflow : TextAttribute<UnityEngine.VerticalWrapMode>
        {
            public VerticalOverflow(VerticalWrapMode value) : base("TextVerticalOverflow", value)
            {
            }

            protected override void Apply(UI.Text component) => component.verticalOverflow = this.GetValue();
        }
    }
}