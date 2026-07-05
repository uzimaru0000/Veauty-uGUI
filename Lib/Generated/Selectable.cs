
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    /// <summary>Base class for <see cref="Selectable"/> attributes, targeting <see cref="UnityEngine.UI.Selectable"/>.</summary>
    /// <typeparam name="T">The attribute value type.</typeparam>
    public abstract class SelectableAttribute<T> : GuiAttributeBase<UnityEngine.UI.Selectable, T>
    {
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name="key">The attribute key.</param>
        /// <param name="value">The value to apply.</param>
        protected SelectableAttribute(string key, T value) : base(key, value) { }
    }

    /// <summary>Veauty widget for <see cref="UnityEngine.UI.Selectable"/>.</summary>
    public partial class Selectable : GUIBase<UnityEngine.UI.Selectable>
    {
        /// <summary>Creates the widget node.</summary>
        /// <param name="attrs">Attributes applied to the rendered GameObject.</param>
        /// <param name="kids">VTree children.</param>
        public Selectable(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }


        /// <summary>Sets <see cref="UnityEngine.UI.Selectable.navigation"/>.</summary>
        public class Navigation : SelectableAttribute<UnityEngine.UI.Navigation>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>navigation</c>.</param>
            public Navigation(UnityEngine.UI.Navigation value): base("navigation", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.navigation = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Selectable.transition"/>.</summary>
        public class Transition : SelectableAttribute<UnityEngine.UI.Selectable.Transition>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>transition</c>.</param>
            public Transition(UnityEngine.UI.Selectable.Transition value): base("transition", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.transition = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Selectable.colors"/>.</summary>
        public class Colors : SelectableAttribute<UnityEngine.UI.ColorBlock>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>colors</c>.</param>
            public Colors(UnityEngine.UI.ColorBlock value): base("colors", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.colors = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Selectable.spriteState"/>.</summary>
        public class SpriteState : SelectableAttribute<UnityEngine.UI.SpriteState>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>spriteState</c>.</param>
            public SpriteState(UnityEngine.UI.SpriteState value): base("spriteState", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.spriteState = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Selectable.animationTriggers"/>.</summary>
        public class AnimationTriggers : SelectableAttribute<UnityEngine.UI.AnimationTriggers>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>animationTriggers</c>.</param>
            public AnimationTriggers(UnityEngine.UI.AnimationTriggers value): base("animationTriggers", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.animationTriggers = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Selectable.targetGraphic"/>.</summary>
        public class TargetGraphic : SelectableAttribute<UnityEngine.UI.Graphic>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>targetGraphic</c>.</param>
            public TargetGraphic(UnityEngine.UI.Graphic value): base("targetGraphic", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.targetGraphic = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Selectable.interactable"/>.</summary>
        public class Interactable : SelectableAttribute<System.Boolean>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>interactable</c>.</param>
            public Interactable(System.Boolean value): base("interactable", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.interactable = this.GetValue();
            }
        }

        /// <summary>Sets <see cref="UnityEngine.UI.Selectable.image"/>.</summary>
        public class Image : SelectableAttribute<UnityEngine.UI.Image>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name="value">The value assigned to <c>image</c>.</param>
            public Image(UnityEngine.UI.Image value): base("image", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.Selectable component)
            {
                component.image = this.GetValue();
            }
        }
    }
}