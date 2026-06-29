
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class TextAttribute<T> : GuiAttributeBase<UnityEngine.UI.Text, T>
    {
        protected TextAttribute(string key, T value) : base(key, value) { }
    }

    public partial class Text : GUIBase<UnityEngine.UI.Text>
    {
        public Text(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class Value : TextAttribute<System.String>
        {
            public Value(System.String value): base("Value", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.text = this.GetValue();
            }
        }

        public partial class Font : TextAttribute<UnityEngine.Font>
        {
            public Font(UnityEngine.Font value): base("font", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.font = this.GetValue();
            }
        }

        public partial class SupportRichText : TextAttribute<System.Boolean>
        {
            public SupportRichText(System.Boolean value): base("supportRichText", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.supportRichText = this.GetValue();
            }
        }

        public partial class ResizeTextForBestFit : TextAttribute<System.Boolean>
        {
            public ResizeTextForBestFit(System.Boolean value): base("resizeTextForBestFit", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.resizeTextForBestFit = this.GetValue();
            }
        }

        public partial class ResizeTextMinSize : TextAttribute<System.Int32>
        {
            public ResizeTextMinSize(System.Int32 value): base("resizeTextMinSize", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.resizeTextMinSize = this.GetValue();
            }
        }

        public partial class ResizeTextMaxSize : TextAttribute<System.Int32>
        {
            public ResizeTextMaxSize(System.Int32 value): base("resizeTextMaxSize", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.resizeTextMaxSize = this.GetValue();
            }
        }

        public partial class Alignment : TextAttribute<UnityEngine.TextAnchor>
        {
            public Alignment(UnityEngine.TextAnchor value): base("alignment", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.alignment = this.GetValue();
            }
        }

        public partial class AlignByGeometry : TextAttribute<System.Boolean>
        {
            public AlignByGeometry(System.Boolean value): base("alignByGeometry", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.alignByGeometry = this.GetValue();
            }
        }

        public partial class FontSize : TextAttribute<System.Int32>
        {
            public FontSize(System.Int32 value): base("fontSize", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.fontSize = this.GetValue();
            }
        }

        public partial class HorizontalOverflow : TextAttribute<UnityEngine.HorizontalWrapMode>
        {
            public HorizontalOverflow(UnityEngine.HorizontalWrapMode value): base("horizontalOverflow", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.horizontalOverflow = this.GetValue();
            }
        }

        public partial class VerticalOverflow : TextAttribute<UnityEngine.VerticalWrapMode>
        {
            public VerticalOverflow(UnityEngine.VerticalWrapMode value): base("verticalOverflow", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.verticalOverflow = this.GetValue();
            }
        }

        public partial class LineSpacing : TextAttribute<System.Single>
        {
            public LineSpacing(System.Single value): base("lineSpacing", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.lineSpacing = this.GetValue();
            }
        }

        public partial class FontStyle : TextAttribute<UnityEngine.FontStyle>
        {
            public FontStyle(UnityEngine.FontStyle value): base("fontStyle", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.fontStyle = this.GetValue();
            }
        }
    }
}