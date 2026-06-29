
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class HorizontalLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.HorizontalLayoutGroup, T>
    {
        protected HorizontalLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    public partial class HorizontalLayoutGroup : GUIBase<UnityEngine.UI.HorizontalLayoutGroup>
    {
        public HorizontalLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }


    }
}