
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class BaseMeshEffectAttribute<T> : GuiAttributeBase<UnityEngine.UI.BaseMeshEffect, T>
    {
        protected BaseMeshEffectAttribute(string key, T value) : base(key, value) { }
    }

    public partial class BaseMeshEffect : GUIBase<UnityEngine.UI.BaseMeshEffect>
    {
        public BaseMeshEffect(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

    }
}