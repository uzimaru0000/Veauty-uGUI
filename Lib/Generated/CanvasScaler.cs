
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="CanvasScaler"/> attributes, targeting <see cref="UnityEngine.UI.CanvasScaler"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class CanvasScalerAttribute<T> : GuiAttributeBase<UnityEngine.UI.CanvasScaler, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected CanvasScalerAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.CanvasScaler"/>.</summary>
    public partial class CanvasScaler : GUIBase<UnityEngine.UI.CanvasScaler>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public CanvasScaler(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.CanvasScaler.uiScaleMode"/>.</summary>
        public class UiScaleMode : CanvasScalerAttribute<UnityEngine.UI.CanvasScaler.ScaleMode>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>uiScaleMode</c>.</param>
            public UiScaleMode(UnityEngine.UI.CanvasScaler.ScaleMode value): base("uiScaleMode", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.uiScaleMode = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.CanvasScaler.referencePixelsPerUnit"/>.</summary>
        public class ReferencePixelsPerUnit : CanvasScalerAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>referencePixelsPerUnit</c>.</param>
            public ReferencePixelsPerUnit(System.Single value): base("referencePixelsPerUnit", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.referencePixelsPerUnit = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.CanvasScaler.scaleFactor"/>.</summary>
        public class ScaleFactor : CanvasScalerAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>scaleFactor</c>.</param>
            public ScaleFactor(System.Single value): base("scaleFactor", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.scaleFactor = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.CanvasScaler.referenceResolution"/>.</summary>
        public class ReferenceResolution : CanvasScalerAttribute<UnityEngine.Vector2>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>referenceResolution</c>.</param>
            public ReferenceResolution(UnityEngine.Vector2 value): base("referenceResolution", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.referenceResolution = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.CanvasScaler.screenMatchMode"/>.</summary>
        public class ScreenMatchMode : CanvasScalerAttribute<UnityEngine.UI.CanvasScaler.ScreenMatchMode>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>screenMatchMode</c>.</param>
            public ScreenMatchMode(UnityEngine.UI.CanvasScaler.ScreenMatchMode value): base("screenMatchMode", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.screenMatchMode = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.CanvasScaler.matchWidthOrHeight"/>.</summary>
        public class MatchWidthOrHeight : CanvasScalerAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>matchWidthOrHeight</c>.</param>
            public MatchWidthOrHeight(System.Single value): base("matchWidthOrHeight", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.matchWidthOrHeight = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.CanvasScaler.physicalUnit"/>.</summary>
        public class PhysicalUnit : CanvasScalerAttribute<UnityEngine.UI.CanvasScaler.Unit>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>physicalUnit</c>.</param>
            public PhysicalUnit(UnityEngine.UI.CanvasScaler.Unit value): base("physicalUnit", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.physicalUnit = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.CanvasScaler.fallbackScreenDPI"/>.</summary>
        public class FallbackScreenDPI : CanvasScalerAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>fallbackScreenDPI</c>.</param>
            public FallbackScreenDPI(System.Single value): base("fallbackScreenDPI", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.fallbackScreenDPI = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.CanvasScaler.defaultSpriteDPI"/>.</summary>
        public class DefaultSpriteDPI : CanvasScalerAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>defaultSpriteDPI</c>.</param>
            public DefaultSpriteDPI(System.Single value): base("defaultSpriteDPI", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.defaultSpriteDPI = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.CanvasScaler.dynamicPixelsPerUnit"/>.</summary>
        public class DynamicPixelsPerUnit : CanvasScalerAttribute<System.Single>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>dynamicPixelsPerUnit</c>.</param>
            public DynamicPixelsPerUnit(System.Single value): base("dynamicPixelsPerUnit", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.dynamicPixelsPerUnit = this.GetValue();
            }
        }
    }
}