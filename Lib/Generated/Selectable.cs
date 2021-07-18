
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class SelectableAttribute<T> : GuiAttributeBase<UnityEngine.UI.Selectable, T>
    {
        protected SelectableAttribute(string key, T value) : base(key, value) { }
    }

    public class Selectable : GUIBase<UnityEngine.UI.Selectable>
    {
        public Selectable(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Navigation : SelectableAttribute<UnityEngine.UI.Navigation>
        {
            public Navigation(UnityEngine.UI.Navigation value): base("navigation", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.navigation = this.GetValue();
            }
        }

        public class Transition : SelectableAttribute<UnityEngine.UI.Selectable.Transition>
        {
            public Transition(UnityEngine.UI.Selectable.Transition value): base("transition", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.transition = this.GetValue();
            }
        }

        public class Colors : SelectableAttribute<UnityEngine.UI.ColorBlock>
        {
            public Colors(UnityEngine.UI.ColorBlock value): base("colors", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.colors = this.GetValue();
            }
        }

        public class SpriteState : SelectableAttribute<UnityEngine.UI.SpriteState>
        {
            public SpriteState(UnityEngine.UI.SpriteState value): base("spriteState", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.spriteState = this.GetValue();
            }
        }

        public class AnimationTriggers : SelectableAttribute<UnityEngine.UI.AnimationTriggers>
        {
            public AnimationTriggers(UnityEngine.UI.AnimationTriggers value): base("animationTriggers", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.animationTriggers = this.GetValue();
            }
        }

        public class TargetGraphic : SelectableAttribute<UnityEngine.UI.Graphic>
        {
            public TargetGraphic(UnityEngine.UI.Graphic value): base("targetGraphic", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.targetGraphic = this.GetValue();
            }
        }

        public class Interactable : SelectableAttribute<System.Boolean>
        {
            public Interactable(System.Boolean value): base("interactable", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.interactable = this.GetValue();
            }
        }

        public class Image : SelectableAttribute<UnityEngine.UI.Image>
        {
            public Image(UnityEngine.UI.Image value): base("image", value) {}
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.image = this.GetValue();
            }
        }

    }
}