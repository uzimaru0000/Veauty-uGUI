
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class TextAttribute<T> : GuiAttributeBase<UnityEngine.UI.Text, T>
    {
        protected TextAttribute(string key, T value) : base(key, value) { }
    }

    public class Text : GUIBase<UnityEngine.UI.Text>
    {
        public Text(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Font : TextAttribute<UnityEngine.Font>
        {
            public Font(UnityEngine.Font value): base("font", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.font = this.GetValue();
            }
        }

        public class Value : TextAttribute<System.String>
        {
            public Value(System.String value): base("Value", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.text = this.GetValue();
            }
        }

        public class SupportRichText : TextAttribute<System.Boolean>
        {
            public SupportRichText(System.Boolean value): base("supportRichText", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.supportRichText = this.GetValue();
            }
        }

        public class ResizeTextForBestFit : TextAttribute<System.Boolean>
        {
            public ResizeTextForBestFit(System.Boolean value): base("resizeTextForBestFit", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.resizeTextForBestFit = this.GetValue();
            }
        }

        public class ResizeTextMinSize : TextAttribute<System.Int32>
        {
            public ResizeTextMinSize(System.Int32 value): base("resizeTextMinSize", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.resizeTextMinSize = this.GetValue();
            }
        }

        public class ResizeTextMaxSize : TextAttribute<System.Int32>
        {
            public ResizeTextMaxSize(System.Int32 value): base("resizeTextMaxSize", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.resizeTextMaxSize = this.GetValue();
            }
        }

        public class Alignment : TextAttribute<UnityEngine.TextAnchor>
        {
            public Alignment(UnityEngine.TextAnchor value): base("alignment", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.alignment = this.GetValue();
            }
        }

        public class AlignByGeometry : TextAttribute<System.Boolean>
        {
            public AlignByGeometry(System.Boolean value): base("alignByGeometry", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.alignByGeometry = this.GetValue();
            }
        }

        public class FontSize : TextAttribute<System.Int32>
        {
            public FontSize(System.Int32 value): base("fontSize", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.fontSize = this.GetValue();
            }
        }

        public class HorizontalOverflow : TextAttribute<UnityEngine.HorizontalWrapMode>
        {
            public HorizontalOverflow(UnityEngine.HorizontalWrapMode value): base("horizontalOverflow", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.horizontalOverflow = this.GetValue();
            }
        }

        public class VerticalOverflow : TextAttribute<UnityEngine.VerticalWrapMode>
        {
            public VerticalOverflow(UnityEngine.VerticalWrapMode value): base("verticalOverflow", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.verticalOverflow = this.GetValue();
            }
        }

        public class LineSpacing : TextAttribute<System.Single>
        {
            public LineSpacing(System.Single value): base("lineSpacing", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.lineSpacing = this.GetValue();
            }
        }

        public class FontStyle : TextAttribute<UnityEngine.FontStyle>
        {
            public FontStyle(UnityEngine.FontStyle value): base("fontStyle", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.fontStyle = this.GetValue();
            }
        }

    }
}