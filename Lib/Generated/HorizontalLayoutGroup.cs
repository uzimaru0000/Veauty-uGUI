
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class HorizontalLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.HorizontalLayoutGroup, T>
    {
        protected HorizontalLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    public class HorizontalLayoutGroup : GUIBase<UnityEngine.UI.HorizontalLayoutGroup>
    {
        public HorizontalLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
    }
}