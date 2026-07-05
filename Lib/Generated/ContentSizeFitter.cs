
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="ContentSizeFitter"/> attributes, targeting <see cref="UnityEngine.UI.ContentSizeFitter"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class ContentSizeFitterAttribute<T> : GuiAttributeBase<UnityEngine.UI.ContentSizeFitter, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected ContentSizeFitterAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.ContentSizeFitter"/>.</summary>
    public partial class ContentSizeFitter : GUIBase<UnityEngine.UI.ContentSizeFitter>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public ContentSizeFitter(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.ContentSizeFitter.horizontalFit"/>.</summary>
        public class HorizontalFit : ContentSizeFitterAttribute<UnityEngine.UI.ContentSizeFitter.FitMode>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>horizontalFit</c>.</param>
            public HorizontalFit(UnityEngine.UI.ContentSizeFitter.FitMode value): base("horizontalFit", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ContentSizeFitter component)
            {
                component.horizontalFit = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.ContentSizeFitter.verticalFit"/>.</summary>
        public class VerticalFit : ContentSizeFitterAttribute<UnityEngine.UI.ContentSizeFitter.FitMode>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>verticalFit</c>.</param>
            public VerticalFit(UnityEngine.UI.ContentSizeFitter.FitMode value): base("verticalFit", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.ContentSizeFitter component)
            {
                component.verticalFit = this.GetValue();
            }
        }
    }
}