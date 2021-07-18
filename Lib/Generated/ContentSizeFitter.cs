
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class ContentSizeFitterAttribute<T> : GuiAttributeBase<UnityEngine.UI.ContentSizeFitter, T>
    {
        protected ContentSizeFitterAttribute(string key, T value) : base(key, value) { }
    }

    public class ContentSizeFitter : GUIBase<UnityEngine.UI.ContentSizeFitter>
    {
        public ContentSizeFitter(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class HorizontalFit : ContentSizeFitterAttribute<UnityEngine.UI.ContentSizeFitter.FitMode>
        {
            public HorizontalFit(UnityEngine.UI.ContentSizeFitter.FitMode value): base("horizontalFit", value) {}
            protected override void Apply(UnityEngine.UI.ContentSizeFitter component)
            {
                component.horizontalFit = this.GetValue();
            }
        }

        public class VerticalFit : ContentSizeFitterAttribute<UnityEngine.UI.ContentSizeFitter.FitMode>
        {
            public VerticalFit(UnityEngine.UI.ContentSizeFitter.FitMode value): base("verticalFit", value) {}
            protected override void Apply(UnityEngine.UI.ContentSizeFitter component)
            {
                component.verticalFit = this.GetValue();
            }
        }

    }
}