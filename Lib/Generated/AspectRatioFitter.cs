
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class AspectRatioFitterAttribute<T> : GuiAttributeBase<UnityEngine.UI.AspectRatioFitter, T>
    {
        protected AspectRatioFitterAttribute(string key, T value) : base(key, value) { }
    }

    public partial class AspectRatioFitter : GUIBase<UnityEngine.UI.AspectRatioFitter>
    {
        public AspectRatioFitter(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public partial class AspectMode : AspectRatioFitterAttribute<UnityEngine.UI.AspectRatioFitter.AspectMode>
        {
            public AspectMode(UnityEngine.UI.AspectRatioFitter.AspectMode value): base("aspectMode", value) {}
            protected override void Apply(UnityEngine.UI.AspectRatioFitter component)
            {
                component.aspectMode = this.GetValue();
            }
        }

        public partial class AspectRatio : AspectRatioFitterAttribute<System.Single>
        {
            public AspectRatio(System.Single value): base("aspectRatio", value) {}
            protected override void Apply(UnityEngine.UI.AspectRatioFitter component)
            {
                component.aspectRatio = this.GetValue();
            }
        }
    }
}