using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class RectTransformAttribute<T> : GuiAttributeBase<UnityEngine.RectTransform, T>
    {
        protected RectTransformAttribute(string key, T value) : base(key, value) { }
    }

    public partial class RectTransform : GUIBase<UnityEngine.RectTransform>
    {
        public RectTransform(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public class AnchorMin : RectTransformAttribute<UnityEngine.Vector2>
        {
            public AnchorMin(UnityEngine.Vector2 value) : base("anchorMin", value) { }
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.anchorMin = this.GetValue();
            }
        }

        public class AnchorMax : RectTransformAttribute<UnityEngine.Vector2>
        {
            public AnchorMax(UnityEngine.Vector2 value) : base("anchorMax", value) { }
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.anchorMax = this.GetValue();
            }
        }

        public class AnchoredPosition : RectTransformAttribute<UnityEngine.Vector2>
        {
            public AnchoredPosition(UnityEngine.Vector2 value) : base("anchoredPosition", value) { }
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.anchoredPosition = this.GetValue();
            }
        }

        public class AnchoredPosition3D : RectTransformAttribute<UnityEngine.Vector3>
        {
            public AnchoredPosition3D(UnityEngine.Vector3 value) : base("anchoredPosition3D", value) { }
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.anchoredPosition3D = this.GetValue();
            }
        }

        public class SizeDelta : RectTransformAttribute<UnityEngine.Vector2>
        {
            public SizeDelta(UnityEngine.Vector2 value) : base("sizeDelta", value) { }
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.sizeDelta = this.GetValue();
            }
        }

        public class Pivot : RectTransformAttribute<UnityEngine.Vector2>
        {
            public Pivot(UnityEngine.Vector2 value) : base("pivot", value) { }
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.pivot = this.GetValue();
            }
        }

        public class OffsetMin : RectTransformAttribute<UnityEngine.Vector2>
        {
            public OffsetMin(UnityEngine.Vector2 value) : base("offsetMin", value) { }
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.offsetMin = this.GetValue();
            }
        }

        public class OffsetMax : RectTransformAttribute<UnityEngine.Vector2>
        {
            public OffsetMax(UnityEngine.Vector2 value) : base("offsetMax", value) { }
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.offsetMax = this.GetValue();
            }
        }

        public class SendChildDimensionsChange : RectTransformAttribute<bool>
        {
            public SendChildDimensionsChange(bool value) : base("sendChildDimensionsChange", value) { }
            protected override void Apply(UnityEngine.RectTransform component)
            {
                component.sendChildDimensionsChange = this.GetValue();
            }
        }
    }
}
