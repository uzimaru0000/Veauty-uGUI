
// THIS CODE IS AUTO GENERATED

using UnityEngine;
using UnityEngine.Events;
using Veauty.GameObject.Attributes;
using UI = UnityEngine.UI;
using Veauty.VTree;
using System.Collections.Generic;

namespace Veauty.uGUI
{
    public abstract class DropdownAttribute<T> : GuiAttributeBase<UnityEngine.UI.Dropdown, T>
    {
        protected DropdownAttribute(string key, T value) : base(key, value) { }
    }

    public class Dropdown : GUIBase<UnityEngine.UI.Dropdown>
    {
        public Dropdown(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }
        public override void Destroy(UnityEngine.GameObject go) { }

        
        public class Template : DropdownAttribute<UnityEngine.RectTransform>
        {
            public Template(UnityEngine.RectTransform value): base("template", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.template = this.GetValue();
            }
        }

        public class CaptionText : DropdownAttribute<UnityEngine.UI.Text>
        {
            public CaptionText(UnityEngine.UI.Text value): base("captionText", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.captionText = this.GetValue();
            }
        }

        public class CaptionImage : DropdownAttribute<UnityEngine.UI.Image>
        {
            public CaptionImage(UnityEngine.UI.Image value): base("captionImage", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.captionImage = this.GetValue();
            }
        }

        public class ItemText : DropdownAttribute<UnityEngine.UI.Text>
        {
            public ItemText(UnityEngine.UI.Text value): base("itemText", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.itemText = this.GetValue();
            }
        }

        public class ItemImage : DropdownAttribute<UnityEngine.UI.Image>
        {
            public ItemImage(UnityEngine.UI.Image value): base("itemImage", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.itemImage = this.GetValue();
            }
        }

        public class Options : DropdownAttribute<System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData>>
        {
            public Options(System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData> value): base("options", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.options = this.GetValue();
            }
        }

        public class OnValueChanged : DropdownAttribute<UnityEngine.UI.Dropdown.DropdownEvent>
        {
            public OnValueChanged(UnityEngine.UI.Dropdown.DropdownEvent value): base("onValueChanged", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.onValueChanged = this.GetValue();
            }
        }

        public class AlphaFadeSpeed : DropdownAttribute<System.Single>
        {
            public AlphaFadeSpeed(System.Single value): base("alphaFadeSpeed", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.alphaFadeSpeed = this.GetValue();
            }
        }

        public class Value : DropdownAttribute<System.Int32>
        {
            public Value(System.Int32 value): base("value", value) {}
            protected override void Apply(UnityEngine.UI.Dropdown component)
            {
                component.value = this.GetValue();
            }
        }

    }
}