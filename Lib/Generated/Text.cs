
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Text"/> attributes, targeting <see cref="UnityEngine.UI.Text"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class TextAttribute<T> : GuiAttributeBase<UnityEngine.UI.Text, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected TextAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Text"/>.</summary>
    public partial class Text : GUIBase<UnityEngine.UI.Text>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Text(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.Text.text"/>.</summary>
        public class Value : TextAttribute<System.String>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The string assigned to <c>text</c>.</param>
            public Value(System.String value): base("Value", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.text = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.font"/>.</summary>
        public class Font : TextAttribute<UnityEngine.Font>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>font</c>.</param>
            public Font(UnityEngine.Font value): base("font", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.font = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.supportRichText"/>.</summary>
        public class SupportRichText : TextAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>supportRichText</c>.</param>
            public SupportRichText(System.Boolean value): base("supportRichText", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.supportRichText = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.resizeTextForBestFit"/>.</summary>
        public class ResizeTextForBestFit : TextAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>resizeTextForBestFit</c>.</param>
            public ResizeTextForBestFit(System.Boolean value): base("resizeTextForBestFit", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.resizeTextForBestFit = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.resizeTextMinSize"/>.</summary>
        public class ResizeTextMinSize : TextAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>resizeTextMinSize</c>.</param>
            public ResizeTextMinSize(System.Int32 value): base("resizeTextMinSize", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.resizeTextMinSize = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.resizeTextMaxSize"/>.</summary>
        public class ResizeTextMaxSize : TextAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>resizeTextMaxSize</c>.</param>
            public ResizeTextMaxSize(System.Int32 value): base("resizeTextMaxSize", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.resizeTextMaxSize = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.alignment"/>.</summary>
        public class Alignment : TextAttribute<UnityEngine.TextAnchor>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>alignment</c>.</param>
            public Alignment(UnityEngine.TextAnchor value): base("alignment", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.alignment = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.alignByGeometry"/>.</summary>
        public class AlignByGeometry : TextAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>alignByGeometry</c>.</param>
            public AlignByGeometry(System.Boolean value): base("alignByGeometry", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.alignByGeometry = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.fontSize"/>.</summary>
        public class FontSize : TextAttribute<System.Int32>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>fontSize</c>.</param>
            public FontSize(System.Int32 value): base("fontSize", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.fontSize = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.horizontalOverflow"/>.</summary>
        public class HorizontalOverflow : TextAttribute<UnityEngine.HorizontalWrapMode>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>horizontalOverflow</c>.</param>
            public HorizontalOverflow(UnityEngine.HorizontalWrapMode value): base("horizontalOverflow", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.horizontalOverflow = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.verticalOverflow"/>.</summary>
        public class VerticalOverflow : TextAttribute<UnityEngine.VerticalWrapMode>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>verticalOverflow</c>.</param>
            public VerticalOverflow(UnityEngine.VerticalWrapMode value): base("verticalOverflow", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.verticalOverflow = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.lineSpacing"/>.</summary>
        public class LineSpacing : TextAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>lineSpacing</c>.</param>
            public LineSpacing(System.Single value): base("lineSpacing", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.lineSpacing = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Text.fontStyle"/>.</summary>
        public class FontStyle : TextAttribute<UnityEngine.FontStyle>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>fontStyle</c>.</param>
            public FontStyle(UnityEngine.FontStyle value): base("fontStyle", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.fontStyle = this.GetValue();
            }
        }
    }
}