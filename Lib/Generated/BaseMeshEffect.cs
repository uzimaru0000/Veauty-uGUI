
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class BaseMeshEffectAttribute<T> : GuiAttributeBase<UnityEngine.UI.BaseMeshEffect, T>
    {
        protected BaseMeshEffectAttribute(string key, T value) : base(key, value) { }
    }

    public class BaseMeshEffect : GUIBase<UnityEngine.UI.BaseMeshEffect>
    {
        public BaseMeshEffect(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
    }
}