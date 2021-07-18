
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class PositionAsUV1Attribute<T> : GuiAttributeBase<UnityEngine.UI.PositionAsUV1, T>
    {
        protected PositionAsUV1Attribute(string key, T value) : base(key, value) { }
    }

    public class PositionAsUV1 : GUIBase<UnityEngine.UI.PositionAsUV1>
    {
        public PositionAsUV1(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
    }
}