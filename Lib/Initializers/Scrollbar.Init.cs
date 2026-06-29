using System.Collections.Generic;
using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;

namespace Veauty.uGUI
{
    public partial class Scrollbar
    {
        private IVTree[] _contentKids;
        public override IVTree[] GetKids()
        {
            if (_contentKids != null) return _contentKids;
            var list = new List<IVTree>();
            foreach (var kid in kids)
                if (!(kid is ISubComponent)) list.Add(kid);
            _contentKids = list.ToArray();
            return _contentKids;
        }

        public override UnityGameObject Init(UnityGameObject go)
        {
            var scrollbar = go.GetComponent<UnityEngine.UI.Scrollbar>();
            var handleCfg = FindPart<ScrollbarHandlePart>();

            var bgImage = go.GetComponent<UnityEngine.UI.Image>();
            if (bgImage == null)
                bgImage = AddVisual<UnityEngine.UI.Image>(go, new UnityEngine.Color(0.22f, 0.24f, 0.28f));

            if (handleCfg != null)
            {
                var slideArea = CreateChild(go, "Sliding Area");
                Stretch(slideArea.GetComponent<UnityEngine.RectTransform>());
                var handle = CreateChild(slideArea, "Handle");
                var handleImage = AddVisual<UnityEngine.UI.Image>(handle, handleCfg.color);
                if (handleCfg.sprite != null) handleImage.sprite = handleCfg.sprite;
                handleImage.type = handleCfg.imageType;
                handle.GetComponent<UnityEngine.RectTransform>().sizeDelta = UnityEngine.Vector2.zero;
                scrollbar.handleRect = handle.GetComponent<UnityEngine.RectTransform>();
                scrollbar.targetGraphic = handleImage;
            }

            return go;
        }

        public static IVTree Handle(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new ScrollbarHandlePart(sprite, color, imageType);

        public class ScrollbarHandlePart : IVTree, ISubComponent
        {
            public readonly UnityEngine.Sprite sprite;
            public readonly UnityEngine.Color color;
            public readonly UnityEngine.UI.Image.Type imageType;
            public ScrollbarHandlePart(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? new UnityEngine.Color(0.5f, 0.5f, 0.5f); this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            public VTreeType GetNodeType() => VTreeType.Node;
            public int GetDescendantsCount() => 0;
        }
    }
}
