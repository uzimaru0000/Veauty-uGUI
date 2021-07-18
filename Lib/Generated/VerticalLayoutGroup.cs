
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class VerticalLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.VerticalLayoutGroup, T>
    {
        protected VerticalLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    public class VerticalLayoutGroup : GUIBase<UnityEngine.UI.VerticalLayoutGroup>
    {
        public VerticalLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
    }
}