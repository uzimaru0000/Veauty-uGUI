
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class OutlineAttribute<T> : GuiAttributeBase<UnityEngine.UI.Outline, T>
    {
        protected OutlineAttribute(string key, T value) : base(key, value) { }
    }

    public class Outline : GUIBase<UnityEngine.UI.Outline>
    {
        public Outline(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
    }
}