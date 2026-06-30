using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{
    public interface ISubComponent { }

    public struct ImageStyle
    {
        public UnityEngine.Sprite Sprite;
        public UnityEngine.Color Color;
        public UnityEngine.UI.Image.Type ImageType;

        public void ApplyTo(UnityEngine.UI.Image image)
        {
            if (Sprite != null) image.sprite = Sprite;
            image.color = Color;
            image.type = ImageType;
        }
    }

    public abstract class GUIBase<T> :
        Node<UnityEngine.GameObject, T>,
        IHostLifecycle<UnityEngine.GameObject>,
        IHostLifecycleTree<UnityEngine.GameObject>
        where T : UnityEngine.Component
    {
        protected GUIBase(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids)
            : base(typeof(T).FullName, attrs, kids)
        {
        }

        public virtual UnityEngine.GameObject Init(UnityEngine.GameObject go) => go;
        public virtual void Destroy(UnityEngine.GameObject go) { }
        public virtual void AfterRenderKids(UnityEngine.GameObject go) { }
        public IHostLifecycle<UnityEngine.GameObject>[] GetHostLifecycles()
            => new IHostLifecycle<UnityEngine.GameObject>[] { this };

        public override int GetDescendantsCount()
        {
            var count = 0;
            var contentKids = GetKids();
            foreach (var kid in contentKids)
            {
                count += kid.GetDescendantsCount();
            }

            return count + contentKids.Length;
        }

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

        protected static TComp AddVisual<TComp>(UnityEngine.GameObject go, UnityEngine.Color color)
            where TComp : UnityEngine.UI.Graphic
        {
            go.AddComponent<UnityEngine.CanvasRenderer>();
            var comp = go.AddComponent<TComp>();
            comp.color = color;
            return comp;
        }

        protected static void SetupRect(
            UnityEngine.RectTransform rt,
            UnityEngine.Vector2? anchorMin = null,
            UnityEngine.Vector2? anchorMax = null,
            UnityEngine.Vector2? pivot = null,
            UnityEngine.Vector2? sizeDelta = null,
            UnityEngine.Vector2? offsetMin = null,
            UnityEngine.Vector2? offsetMax = null)
        {
            if (anchorMin.HasValue) rt.anchorMin = anchorMin.Value;
            if (anchorMax.HasValue) rt.anchorMax = anchorMax.Value;
            if (pivot.HasValue) rt.pivot = pivot.Value;
            if (sizeDelta.HasValue) rt.sizeDelta = sizeDelta.Value;
            if (offsetMin.HasValue) rt.offsetMin = offsetMin.Value;
            if (offsetMax.HasValue) rt.offsetMax = offsetMax.Value;
        }

        protected T FindPart<T>() where T : class
        {
            foreach (var kid in this.kids)
                if (kid is T part) return part;
            return null;
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
