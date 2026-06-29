using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public abstract class GUIBase<T> : Widget<UnityEngine.GameObject> where T : UnityEngine.Component
    {
        protected GUIBase(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) { }

        public override IVTree Render() => new Node<UnityEngine.GameObject, T>(typeof(T).FullName, attrs, kids);

        protected static UnityEngine.GameObject CreateChild(UnityEngine.GameObject parent, string name)
        {
            var child = new UnityEngine.GameObject(name);
            child.AddComponent<UnityEngine.RectTransform>();
            child.transform.SetParent(parent.transform, false);
            return child;
        }

        protected static void Stretch(UnityEngine.RectTransform rt)
        {
            rt.anchorMin = UnityEngine.Vector2.zero;
            rt.anchorMax = UnityEngine.Vector2.one;
            rt.sizeDelta = UnityEngine.Vector2.zero;
        }
    }

    public abstract class GuiAttributeBase<T1, T2> : Attribute<UnityEngine.GameObject, T2> where T1 : UnityEngine.Component
    {
        protected GuiAttributeBase(string key, T2 value) : base(key, value) { }
        protected abstract void Apply(T1 component);
        public override void Apply(UnityEngine.GameObject obj)
        {
            var component = obj.GetComponent<T1>();
            if (component == null && ShouldAddMissingComponent())
            {
                component = obj.AddComponent(typeof(T1)) as T1;
            }

            if (component)
            {
                Apply(component);
            }
        }

        private static bool ShouldAddMissingComponent()
        {
            var type = typeof(T1);
            return type == typeof(UnityEngine.UI.LayoutElement)
                || type == typeof(UnityEngine.UI.ContentSizeFitter)
                || type == typeof(UnityEngine.UI.AspectRatioFitter)
                || type == typeof(UnityEngine.CanvasGroup)
                || type == typeof(UnityEngine.UI.Shadow)
                || type == typeof(UnityEngine.UI.Outline)
                || type == typeof(UnityEngine.UI.PositionAsUV1);
        }
    }
}
