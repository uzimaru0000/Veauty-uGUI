using System.Collections.Generic;
using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;

namespace Veauty.uGUI
{
    public partial class Slider
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
            var slider = go.GetComponent<UnityEngine.UI.Slider>();
            var bgCfg = FindPart<SliderBackground>();
            var fillCfg = FindPart<SliderFill>();
            var handleCfg = FindPart<SliderHandle>();

            if (bgCfg != null)
            {
                var bg = CreateChild(go, "Background");
                var bgImage = AddVisual<UnityEngine.UI.Image>(bg, bgCfg.color);
                if (bgCfg.sprite != null) bgImage.sprite = bgCfg.sprite;
                bgImage.type = bgCfg.imageType;
                Stretch(bg.GetComponent<UnityEngine.RectTransform>());
            }

            if (fillCfg != null)
            {
                var fillArea = CreateChild(go, "Fill Area");
                SetupRect(fillArea.GetComponent<UnityEngine.RectTransform>(),
                    anchorMin: new UnityEngine.Vector2(0f, 0.25f),
                    anchorMax: new UnityEngine.Vector2(1f, 0.75f),
                    offsetMin: new UnityEngine.Vector2(5f, 0f),
                    offsetMax: new UnityEngine.Vector2(-5f, 0f));
                var fill = CreateChild(fillArea, "Fill");
                var fillImage = AddVisual<UnityEngine.UI.Image>(fill, fillCfg.color);
                if (fillCfg.sprite != null) fillImage.sprite = fillCfg.sprite;
                fillImage.type = fillCfg.imageType;
                fill.GetComponent<UnityEngine.RectTransform>().sizeDelta = UnityEngine.Vector2.zero;
                slider.fillRect = fill.GetComponent<UnityEngine.RectTransform>();
            }

            if (handleCfg != null)
            {
                var handleArea = CreateChild(go, "Handle Slide Area");
                SetupRect(handleArea.GetComponent<UnityEngine.RectTransform>(),
                    anchorMin: UnityEngine.Vector2.zero,
                    anchorMax: UnityEngine.Vector2.one,
                    offsetMin: new UnityEngine.Vector2(10f, 0f),
                    offsetMax: new UnityEngine.Vector2(-10f, 0f));
                var handle = CreateChild(handleArea, "Handle");
                var handleImage = AddVisual<UnityEngine.UI.Image>(handle, handleCfg.color);
                if (handleCfg.sprite != null) handleImage.sprite = handleCfg.sprite;
                handleImage.type = handleCfg.imageType;
                handle.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2(20f, 0f);
                slider.handleRect = handle.GetComponent<UnityEngine.RectTransform>();
                slider.targetGraphic = handleImage;
            }

            return go;
        }

        public static IVTree Background(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new SliderBackground(sprite, color, imageType);
        public static IVTree Fill(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new SliderFill(sprite, color, imageType);
        public static IVTree Handle(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new SliderHandle(sprite, color, imageType);

        public class SliderBackground : IVTree, ISubComponent
        {
            public readonly UnityEngine.Sprite sprite;
            public readonly UnityEngine.Color color;
            public readonly UnityEngine.UI.Image.Type imageType;
            public SliderBackground(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? new UnityEngine.Color(0.30f, 0.32f, 0.38f); this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            public VTreeType GetNodeType() => VTreeType.Node;
            public int GetDescendantsCount() => 0;
        }
        public class SliderFill : IVTree, ISubComponent
        {
            public readonly UnityEngine.Sprite sprite;
            public readonly UnityEngine.Color color;
            public readonly UnityEngine.UI.Image.Type imageType;
            public SliderFill(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? new UnityEngine.Color(0.22f, 0.55f, 0.95f); this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            public VTreeType GetNodeType() => VTreeType.Node;
            public int GetDescendantsCount() => 0;
        }
        public class SliderHandle : IVTree, ISubComponent
        {
            public readonly UnityEngine.Sprite sprite;
            public readonly UnityEngine.Color color;
            public readonly UnityEngine.UI.Image.Type imageType;
            public SliderHandle(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? UnityEngine.Color.white; this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            public VTreeType GetNodeType() => VTreeType.Node;
            public int GetDescendantsCount() => 0;
        }
    }
}
