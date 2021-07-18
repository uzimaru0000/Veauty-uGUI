
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class GraphicRaycasterAttribute<T> : GuiAttributeBase<UnityEngine.UI.GraphicRaycaster, T>
    {
        protected GraphicRaycasterAttribute(string key, T value) : base(key, value) { }
    }

    public class GraphicRaycaster : GUIBase<UnityEngine.UI.GraphicRaycaster>
    {
        public GraphicRaycaster(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class IgnoreReversedGraphics : GraphicRaycasterAttribute<System.Boolean>
        {
            public IgnoreReversedGraphics(System.Boolean value): base("ignoreReversedGraphics", value) {}
            protected override void Apply(UnityEngine.UI.GraphicRaycaster component)
            {
                component.ignoreReversedGraphics = this.GetValue();
            }
        }

        public class BlockingObjects : GraphicRaycasterAttribute<UnityEngine.UI.GraphicRaycaster.BlockingObjects>
        {
            public BlockingObjects(UnityEngine.UI.GraphicRaycaster.BlockingObjects value): base("blockingObjects", value) {}
            protected override void Apply(UnityEngine.UI.GraphicRaycaster component)
            {
                component.blockingObjects = this.GetValue();
            }
        }

        public class BlockingMask : GraphicRaycasterAttribute<UnityEngine.LayerMask>
        {
            public BlockingMask(UnityEngine.LayerMask value): base("blockingMask", value) {}
            protected override void Apply(UnityEngine.UI.GraphicRaycaster component)
            {
                component.blockingMask = this.GetValue();
            }
        }

    }
}