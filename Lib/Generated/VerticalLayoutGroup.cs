
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class VerticalLayoutGroupAttribute<T> : GuiAttributeBase<UnityEngine.UI.VerticalLayoutGroup, T>
    {
        protected VerticalLayoutGroupAttribute(string key, T value) : base(key, value) { }
    }

    public partial class VerticalLayoutGroup : GUIBase<UnityEngine.UI.VerticalLayoutGroup>
    {
        public VerticalLayoutGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

    }
}