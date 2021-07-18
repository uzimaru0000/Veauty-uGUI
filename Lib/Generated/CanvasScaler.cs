
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class CanvasScalerAttribute<T> : GuiAttributeBase<UnityEngine.UI.CanvasScaler, T>
    {
        protected CanvasScalerAttribute(string key, T value) : base(key, value) { }
    }

    public class CanvasScaler : GUIBase<UnityEngine.UI.CanvasScaler>
    {
        public CanvasScaler(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class UiScaleMode : CanvasScalerAttribute<UnityEngine.UI.CanvasScaler.ScaleMode>
        {
            public UiScaleMode(UnityEngine.UI.CanvasScaler.ScaleMode value): base("uiScaleMode", value) {}
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.uiScaleMode = this.GetValue();
            }
        }

        public class ReferencePixelsPerUnit : CanvasScalerAttribute<System.Single>
        {
            public ReferencePixelsPerUnit(System.Single value): base("referencePixelsPerUnit", value) {}
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.referencePixelsPerUnit = this.GetValue();
            }
        }

        public class ScaleFactor : CanvasScalerAttribute<System.Single>
        {
            public ScaleFactor(System.Single value): base("scaleFactor", value) {}
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.scaleFactor = this.GetValue();
            }
        }

        public class ReferenceResolution : CanvasScalerAttribute<UnityEngine.Vector2>
        {
            public ReferenceResolution(UnityEngine.Vector2 value): base("referenceResolution", value) {}
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.referenceResolution = this.GetValue();
            }
        }

        public class ScreenMatchMode : CanvasScalerAttribute<UnityEngine.UI.CanvasScaler.ScreenMatchMode>
        {
            public ScreenMatchMode(UnityEngine.UI.CanvasScaler.ScreenMatchMode value): base("screenMatchMode", value) {}
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.screenMatchMode = this.GetValue();
            }
        }

        public class MatchWidthOrHeight : CanvasScalerAttribute<System.Single>
        {
            public MatchWidthOrHeight(System.Single value): base("matchWidthOrHeight", value) {}
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.matchWidthOrHeight = this.GetValue();
            }
        }

        public class PhysicalUnit : CanvasScalerAttribute<UnityEngine.UI.CanvasScaler.Unit>
        {
            public PhysicalUnit(UnityEngine.UI.CanvasScaler.Unit value): base("physicalUnit", value) {}
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.physicalUnit = this.GetValue();
            }
        }

        public class FallbackScreenDPI : CanvasScalerAttribute<System.Single>
        {
            public FallbackScreenDPI(System.Single value): base("fallbackScreenDPI", value) {}
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.fallbackScreenDPI = this.GetValue();
            }
        }

        public class DefaultSpriteDPI : CanvasScalerAttribute<System.Single>
        {
            public DefaultSpriteDPI(System.Single value): base("defaultSpriteDPI", value) {}
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.defaultSpriteDPI = this.GetValue();
            }
        }

        public class DynamicPixelsPerUnit : CanvasScalerAttribute<System.Single>
        {
            public DynamicPixelsPerUnit(System.Single value): base("dynamicPixelsPerUnit", value) {}
            protected override void Apply(UnityEngine.UI.CanvasScaler component)
            {
                component.dynamicPixelsPerUnit = this.GetValue();
            }
        }

    }
}