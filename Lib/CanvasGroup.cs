using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class CanvasGroupAttribute<T> : GuiAttributeBase<UnityEngine.CanvasGroup, T>
    {
        protected CanvasGroupAttribute(string key, T value) : base(key, value) { }
    }

    public partial class CanvasGroup : GUIBase<UnityEngine.CanvasGroup>
    {
        public CanvasGroup(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public class Alpha : CanvasGroupAttribute<float>
        {
            public Alpha(float value) : base("alpha", value) { }
            protected override void Apply(UnityEngine.CanvasGroup component)
            {
                component.alpha = this.GetValue();
            }
        }

        public class Interactable : CanvasGroupAttribute<bool>
        {
            public Interactable(bool value) : base("interactable", value) { }
            protected override void Apply(UnityEngine.CanvasGroup component)
            {
                component.interactable = this.GetValue();
            }
        }

        public class BlocksRaycasts : CanvasGroupAttribute<bool>
        {
            public BlocksRaycasts(bool value) : base("blocksRaycasts", value) { }
            protected override void Apply(UnityEngine.CanvasGroup component)
            {
                component.blocksRaycasts = this.GetValue();
            }
        }

        public class IgnoreParentGroups : CanvasGroupAttribute<bool>
        {
            public IgnoreParentGroups(bool value) : base("ignoreParentGroups", value) { }
            protected override void Apply(UnityEngine.CanvasGroup component)
            {
                component.ignoreParentGroups = this.GetValue();
            }
        }
    }
}
