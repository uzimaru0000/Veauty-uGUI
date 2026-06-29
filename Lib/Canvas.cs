using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class CanvasAttribute<T> : GuiAttributeBase<UnityEngine.Canvas, T>
    {
        protected CanvasAttribute(string key, T value) : base(key, value) { }
    }

    public class Canvas : GUIBase<UnityEngine.Canvas>
    {
        public Canvas(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }

        public override void Destroy(UnityEngine.GameObject go) { }

        public class RenderMode : CanvasAttribute<UnityEngine.RenderMode>
        {
            public RenderMode(UnityEngine.RenderMode value) : base("renderMode", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.renderMode = this.GetValue();
            }
        }

        public class WorldCamera : CanvasAttribute<UnityEngine.Camera>
        {
            public WorldCamera(UnityEngine.Camera value) : base("worldCamera", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.worldCamera = this.GetValue();
            }
        }

        public class PlaneDistance : CanvasAttribute<float>
        {
            public PlaneDistance(float value) : base("planeDistance", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.planeDistance = this.GetValue();
            }
        }

        public class PixelPerfect : CanvasAttribute<bool>
        {
            public PixelPerfect(bool value) : base("pixelPerfect", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.pixelPerfect = this.GetValue();
            }
        }

        public class ScaleFactor : CanvasAttribute<float>
        {
            public ScaleFactor(float value) : base("scaleFactor", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.scaleFactor = this.GetValue();
            }
        }

        public class ReferencePixelsPerUnit : CanvasAttribute<float>
        {
            public ReferencePixelsPerUnit(float value) : base("referencePixelsPerUnit", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.referencePixelsPerUnit = this.GetValue();
            }
        }

        public class OverridePixelPerfect : CanvasAttribute<bool>
        {
            public OverridePixelPerfect(bool value) : base("overridePixelPerfect", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.overridePixelPerfect = this.GetValue();
            }
        }

        public class OverrideSorting : CanvasAttribute<bool>
        {
            public OverrideSorting(bool value) : base("overrideSorting", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.overrideSorting = this.GetValue();
            }
        }

        public class SortingOrder : CanvasAttribute<int>
        {
            public SortingOrder(int value) : base("sortingOrder", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.sortingOrder = this.GetValue();
            }
        }

        public class TargetDisplay : CanvasAttribute<int>
        {
            public TargetDisplay(int value) : base("targetDisplay", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.targetDisplay = this.GetValue();
            }
        }

        public class SortingLayerID : CanvasAttribute<int>
        {
            public SortingLayerID(int value) : base("sortingLayerID", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.sortingLayerID = this.GetValue();
            }
        }

        public class SortingLayerName : CanvasAttribute<string>
        {
            public SortingLayerName(string value) : base("sortingLayerName", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.sortingLayerName = this.GetValue();
            }
        }

        public class AdditionalShaderChannels : CanvasAttribute<UnityEngine.AdditionalCanvasShaderChannels>
        {
            public AdditionalShaderChannels(UnityEngine.AdditionalCanvasShaderChannels value) : base("additionalShaderChannels", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.additionalShaderChannels = this.GetValue();
            }
        }

        public class NormalizedSortingGridSize : CanvasAttribute<float>
        {
            public NormalizedSortingGridSize(float value) : base("normalizedSortingGridSize", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.normalizedSortingGridSize = this.GetValue();
            }
        }

        public class UseReflectionProbes : CanvasAttribute<bool>
        {
            public UseReflectionProbes(bool value) : base("useReflectionProbes", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.useReflectionProbes = this.GetValue();
            }
        }

        public class VertexColorAlwaysGammaSpace : CanvasAttribute<bool>
        {
            public VertexColorAlwaysGammaSpace(bool value) : base("vertexColorAlwaysGammaSpace", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.vertexColorAlwaysGammaSpace = this.GetValue();
            }
        }

        public class UpdateRectTransformForStandalone : CanvasAttribute<UnityEngine.StandaloneRenderResize>
        {
            public UpdateRectTransformForStandalone(UnityEngine.StandaloneRenderResize value) : base("updateRectTransformForStandalone", value) { }
            protected override void Apply(UnityEngine.Canvas component)
            {
                component.updateRectTransformForStandalone = this.GetValue();
            }
        }
    }
}
