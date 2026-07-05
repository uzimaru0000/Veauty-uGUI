
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="AspectRatioFitter"/> attributes, targeting <see cref="UnityEngine.UI.AspectRatioFitter"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class AspectRatioFitterAttribute<T> : GuiAttributeBase<UnityEngine.UI.AspectRatioFitter, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected AspectRatioFitterAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.AspectRatioFitter"/>.</summary>
    public partial class AspectRatioFitter : GUIBase<UnityEngine.UI.AspectRatioFitter>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public AspectRatioFitter(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.AspectRatioFitter.aspectMode"/>.</summary>
        public class AspectMode : AspectRatioFitterAttribute<UnityEngine.UI.AspectRatioFitter.AspectMode>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>aspectMode</c>.</param>
            public AspectMode(UnityEngine.UI.AspectRatioFitter.AspectMode value): base("aspectMode", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.AspectRatioFitter component)
            {
                component.aspectMode = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.AspectRatioFitter.aspectRatio"/>.</summary>
        public class AspectRatio : AspectRatioFitterAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>aspectRatio</c>.</param>
            public AspectRatio(System.Single value): base("aspectRatio", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.AspectRatioFitter component)
            {
                component.aspectRatio = this.GetValue();
            }
        }
    }
}