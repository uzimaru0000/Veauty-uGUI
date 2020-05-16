using Veauty.VTree;
using UnityEngine;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;

namespace Veauty.uGUI
{
    public abstract class TextAttribute<T> : GUIAttributeBase<UI.Text, T>
    {
        protected TextAttribute(string key, T value): base(key, value) { }
    }
    
    public class Text : GUIBase
    {
        public Text(IAttribute[] attrs) : base(attrs, new IVTree[0]) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var textComponent = go.GetComponent<UI.Text>();
            textComponent.font = Resources.GetBuiltinResource<UnityEngine.Font>("Arial.ttf");
            
            return go;
        }

        public override IVTree Render() =>
            new Node<UI.Text>("Text", this.attrs, this.kids);

        public override void Destroy(UnityEngine.GameObject go) { }
        
        public class Value : TextAttribute<string>
        {
            public Value(string text): base("TextValue", text) { }
            protected override void Apply(UI.Text text) => text.text = this.value;
        }

        public class Color : TextAttribute<UnityEngine.Color>
        {
            public Color(UnityEngine.Color color) : base("TextColor", color) { }
            protected override void Apply(UI.Text text) => text.color = this.value;
        }

        public class Font : TextAttribute<UnityEngine.Font>
        {
            public Font(UnityEngine.Font font) : base("TextFont", font) { }
            protected override void Apply(UI.Text text) => text.font = this.value;
        }

        public class Alignment : TextAttribute<UnityEngine.TextAnchor>
        {
            public Alignment(UnityEngine.TextAnchor anchor) : base("TextAlignment", anchor) {}
            protected override void Apply(UI.Text text) => text.alignment = this.value;
        }
        
        public class FontSize : TextAttribute<int>
        {
            public FontSize(string key, int value) : base(key, value)
            {
            }

            protected override void Apply(UI.Text component) => component.fontSize = this.value;
        }

        public class FontStyle : TextAttribute<UnityEngine.FontStyle>
        {
            public FontStyle(string key, UnityEngine.FontStyle value) : base(key, value)
            {
            }

            protected override void Apply(UI.Text component) => component.fontStyle = this.value;
        }

        public class HorizontalOverflow : TextAttribute<UnityEngine.HorizontalWrapMode>
        {
            public HorizontalOverflow(string key, HorizontalWrapMode value) : base(key, value)
            {
            }

            protected override void Apply(UI.Text component) => component.horizontalOverflow = this.value;
        }
        
        public class LineSpacing : TextAttribute<float>
        {
            public LineSpacing(string key, float value) : base(key, value)
            {
            }

            protected override void Apply(UI.Text component) => component.lineSpacing = this.value;
        }

        public class ResizeTextForBestFit : TextAttribute<bool>
        {
            public ResizeTextForBestFit(string key, bool value) : base(key, value)
            {
            }

            protected override void Apply(UI.Text component) => component.resizeTextForBestFit = this.value;
        }

        public class ResizeTextMaxSize : TextAttribute<int>
        {
            public ResizeTextMaxSize(string key, int value) : base(key, value)
            {
            }

            protected override void Apply(UI.Text component) => component.resizeTextMaxSize = this.value;
        }
        
        public class ResizeTextMinSize : TextAttribute<int>
        {
            public ResizeTextMinSize(string key, int value) : base(key, value)
            {
            }

            protected override void Apply(UI.Text component) => component.resizeTextMinSize = this.value;
        }

        public class SupportRichText : TextAttribute<bool>
        {
            public SupportRichText(string key, bool value) : base(key, value)
            {
            }

            protected override void Apply(UI.Text component) => component.supportRichText = this.value;
        }

        public class VerticalOverflow : TextAttribute<UnityEngine.VerticalWrapMode>
        {
            public VerticalOverflow(string key, VerticalWrapMode value) : base(key, value)
            {
            }

            protected override void Apply(UI.Text component) => component.verticalOverflow = this.value;
        }
    }
}