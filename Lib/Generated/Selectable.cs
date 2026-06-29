
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class SelectableAttribute<T> : GuiAttributeBase<UnityEngine.UI.Selectable, T>
    {
        protected SelectableAttribute(string key, T value) : base(key, value) { }
    }

    public partial class Selectable : GUIBase<UnityEngine.UI.Selectable>
    {
        public Selectable(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class Navigation : SelectableAttribute<UnityEngine.UI.Navigation>
        {
            public Navigation(UnityEngine.UI.Navigation value): base("navigation", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.navigation = this.GetValue();
            }
        }

        public partial class Transition : SelectableAttribute<UnityEngine.UI.Selectable.Transition>
        {
            public Transition(UnityEngine.UI.Selectable.Transition value): base("transition", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.transition = this.GetValue();
            }
        }

        public partial class Colors : SelectableAttribute<UnityEngine.UI.ColorBlock>
        {
            public Colors(UnityEngine.UI.ColorBlock value): base("colors", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.colors = this.GetValue();
            }
        }

        public partial class SpriteState : SelectableAttribute<UnityEngine.UI.SpriteState>
        {
            public SpriteState(UnityEngine.UI.SpriteState value): base("spriteState", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.spriteState = this.GetValue();
            }
        }

        public partial class AnimationTriggers : SelectableAttribute<UnityEngine.UI.AnimationTriggers>
        {
            public AnimationTriggers(UnityEngine.UI.AnimationTriggers value): base("animationTriggers", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.animationTriggers = this.GetValue();
            }
        }

        public partial class TargetGraphic : SelectableAttribute<UnityEngine.UI.Graphic>
        {
            public TargetGraphic(UnityEngine.UI.Graphic value): base("targetGraphic", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.targetGraphic = this.GetValue();
            }
        }

        public partial class Interactable : SelectableAttribute<System.Boolean>
        {
            public Interactable(System.Boolean value): base("interactable", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.interactable = this.GetValue();
            }
        }

        public partial class Image : SelectableAttribute<UnityEngine.UI.Image>
        {
            public Image(UnityEngine.UI.Image value): base("image", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.image = this.GetValue();
            }
        }
    }
}