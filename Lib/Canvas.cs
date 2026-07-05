using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Canvas"/> attributes, targeting <see cref="UnityEngine.Canvas"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class CanvasAttribute<T> : GuiAttributeBase<UnityEngine.Canvas, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected CanvasAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>
    /// Veauty widget for <see cref="UnityEngine.Canvas"/> (hand-written; not emitted by the code
    /// generator).
    /// </summary>
    /// <remarks>Rendering a Canvas widget does not add a <c>GraphicRaycaster</c> or create an
    /// <c>EventSystem</c> — set those up in the scene yourself.</remarks>
    public partial class Canvas : GUIBase<UnityEngine.Canvas>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Canvas(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        /// <summary>Sets <see cref="UnityEngine.Canvas.renderMode"/>.</summary>
        public class RenderMode : CanvasAttribute<UnityEngine.RenderMode>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>renderMode</c>.</param>
            public RenderMode(UnityEngine.RenderMode value) : base("renderMode", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.renderMode = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.worldCamera"/>.</summary>
        public class WorldCamera : CanvasAttribute<UnityEngine.Camera>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>worldCamera</c>.</param>
            public WorldCamera(UnityEngine.Camera value) : base("worldCamera", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.worldCamera = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.planeDistance"/>.</summary>
        public class PlaneDistance : CanvasAttribute<float>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>planeDistance</c>.</param>
            public PlaneDistance(float value) : base("planeDistance", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.planeDistance = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.pixelPerfect"/>.</summary>
        public class PixelPerfect : CanvasAttribute<bool>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>pixelPerfect</c>.</param>
            public PixelPerfect(bool value) : base("pixelPerfect", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.pixelPerfect = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.scaleFactor"/>.</summary>
        public class ScaleFactor : CanvasAttribute<float>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>scaleFactor</c>.</param>
            public ScaleFactor(float value) : base("scaleFactor", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.scaleFactor = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.referencePixelsPerUnit"/>.</summary>
        public class ReferencePixelsPerUnit : CanvasAttribute<float>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>referencePixelsPerUnit</c>.</param>
            public ReferencePixelsPerUnit(float value) : base("referencePixelsPerUnit", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.referencePixelsPerUnit = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.overridePixelPerfect"/>.</summary>
        public class OverridePixelPerfect : CanvasAttribute<bool>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>overridePixelPerfect</c>.</param>
            public OverridePixelPerfect(bool value) : base("overridePixelPerfect", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.overridePixelPerfect = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.overrideSorting"/>.</summary>
        public class OverrideSorting : CanvasAttribute<bool>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>overrideSorting</c>.</param>
            public OverrideSorting(bool value) : base("overrideSorting", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.overrideSorting = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.sortingOrder"/>.</summary>
        public class SortingOrder : CanvasAttribute<int>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>sortingOrder</c>.</param>
            public SortingOrder(int value) : base("sortingOrder", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.sortingOrder = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.targetDisplay"/>.</summary>
        public class TargetDisplay : CanvasAttribute<int>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>targetDisplay</c>.</param>
            public TargetDisplay(int value) : base("targetDisplay", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.targetDisplay = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.sortingLayerID"/>.</summary>
        public class SortingLayerID : CanvasAttribute<int>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>sortingLayerID</c>.</param>
            public SortingLayerID(int value) : base("sortingLayerID", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.sortingLayerID = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.sortingLayerName"/>.</summary>
        public class SortingLayerName : CanvasAttribute<string>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>sortingLayerName</c>.</param>
            public SortingLayerName(string value) : base("sortingLayerName", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.sortingLayerName = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.additionalShaderChannels"/>.</summary>
        public class AdditionalShaderChannels : CanvasAttribute<UnityEngine.AdditionalCanvasShaderChannels>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>additionalShaderChannels</c>.</param>
            public AdditionalShaderChannels(UnityEngine.AdditionalCanvasShaderChannels value) : base("additionalShaderChannels", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.additionalShaderChannels = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.normalizedSortingGridSize"/>.</summary>
        public class NormalizedSortingGridSize : CanvasAttribute<float>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>normalizedSortingGridSize</c>.</param>
            public NormalizedSortingGridSize(float value) : base("normalizedSortingGridSize", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.normalizedSortingGridSize = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.useReflectionProbes"/>.</summary>
        public class UseReflectionProbes : CanvasAttribute<bool>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>useReflectionProbes</c>.</param>
            public UseReflectionProbes(bool value) : base("useReflectionProbes", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.useReflectionProbes = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.vertexColorAlwaysGammaSpace"/>.</summary>
        public class VertexColorAlwaysGammaSpace : CanvasAttribute<bool>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>vertexColorAlwaysGammaSpace</c>.</param>
            public VertexColorAlwaysGammaSpace(bool value) : base("vertexColorAlwaysGammaSpace", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.vertexColorAlwaysGammaSpace = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.Canvas.updateRectTransformForStandalone"/>.</summary>
        public class UpdateRectTransformForStandalone : CanvasAttribute<UnityEngine.StandaloneRenderResize>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>updateRectTransformForStandalone</c>.</param>
            public UpdateRectTransformForStandalone(UnityEngine.StandaloneRenderResize value) : base("updateRectTransformForStandalone", value) { }
            /// <inheritdoc />
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.updateRectTransformForStandalone = this.GetValue();
            }
        }
    }
}
