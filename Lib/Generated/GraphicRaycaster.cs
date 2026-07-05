
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="GraphicRaycaster"/> attributes, targeting <see cref="UnityEngine.UI.GraphicRaycaster"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class GraphicRaycasterAttribute<T> : GuiAttributeBase<UnityEngine.UI.GraphicRaycaster, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected GraphicRaycasterAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.GraphicRaycaster"/>.</summary>
    public partial class GraphicRaycaster : GUIBase<UnityEngine.UI.GraphicRaycaster>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public GraphicRaycaster(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.GraphicRaycaster.ignoreReversedGraphics"/>.</summary>
        public class IgnoreReversedGraphics : GraphicRaycasterAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>ignoreReversedGraphics</c>.</param>
            public IgnoreReversedGraphics(System.Boolean value): base("ignoreReversedGraphics", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.GraphicRaycaster component)
            {
                component.ignoreReversedGraphics = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.GraphicRaycaster.blockingObjects"/>.</summary>
        public class BlockingObjects : GraphicRaycasterAttribute<UnityEngine.UI.GraphicRaycaster.BlockingObjects>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>blockingObjects</c>.</param>
            public BlockingObjects(UnityEngine.UI.GraphicRaycaster.BlockingObjects value): base("blockingObjects", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.GraphicRaycaster component)
            {
                component.blockingObjects = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.GraphicRaycaster.blockingMask"/>.</summary>
        public class BlockingMask : GraphicRaycasterAttribute<UnityEngine.LayerMask>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>blockingMask</c>.</param>
            public BlockingMask(UnityEngine.LayerMask value): base("blockingMask", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.GraphicRaycaster component)
            {
                component.blockingMask = this.GetValue();
            }
        }
    }
}