using System.Collections.Generic;
using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;

namespace Veauty.uGUI
{
    public partial class Toggle
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
            var toggle = go.GetComponent<UnityEngine.UI.Toggle>();
            var bgCfg = FindPart<ToggleBackground>();
            var cmCfg = FindPart<ToggleCheckmark>();

            if (bgCfg != null)
            {
                var bg = CreateChild(go, "Background");
                var bgImage = AddVisual<UnityEngine.UI.Image>(bg, bgCfg.color);
                if (bgCfg.sprite != null) bgImage.sprite = bgCfg.sprite;
                bgImage.type = bgCfg.imageType;
                SetupRect(bg.GetComponent<UnityEngine.RectTransform>(),
                    anchorMin: new UnityEngine.Vector2(0f, 0.1f),
                    anchorMax: new UnityEngine.Vector2(0f, 0.9f),
                    pivot: new UnityEngine.Vector2(0f, 0.5f),
                    sizeDelta: new UnityEngine.Vector2(24f, 0f));
                toggle.targetGraphic = bgImage;

                if (cmCfg != null)
                {
                    var cm = CreateChild(bg, "Checkmark");
                    var cmImage = AddVisual<UnityEngine.UI.Image>(cm, cmCfg.color);
                    if (cmCfg.sprite != null) cmImage.sprite = cmCfg.sprite;
                    cmImage.type = cmCfg.imageType;
                    SetupRect(cm.GetComponent<UnityEngine.RectTransform>(),
                        anchorMin: new UnityEngine.Vector2(0.15f, 0.15f),
                        anchorMax: new UnityEngine.Vector2(0.85f, 0.85f),
                        sizeDelta: UnityEngine.Vector2.zero);
                    toggle.graphic = cmImage;
                }
            }

            return go;
        }

        public static IVTree Background(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new ToggleBackground(sprite, color, imageType);
        public static IVTree Checkmark(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new ToggleCheckmark(sprite, color, imageType);

        public class ToggleBackground : IVTree, ISubComponent
        {
            public readonly UnityEngine.Sprite sprite;
            public readonly UnityEngine.Color color;
            public readonly UnityEngine.UI.Image.Type imageType;
            public ToggleBackground(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? new UnityEngine.Color(0.22f, 0.24f, 0.28f); this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            public VTreeType GetNodeType() => VTreeType.Node;
            public int GetDescendantsCount() => 0;
        }
        public class ToggleCheckmark : IVTree, ISubComponent
        {
            public readonly UnityEngine.Sprite sprite;
            public readonly UnityEngine.Color color;
            public readonly UnityEngine.UI.Image.Type imageType;
            public ToggleCheckmark(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? new UnityEngine.Color(0.2f, 0.75f, 0.4f); this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            public VTreeType GetNodeType() => VTreeType.Node;
            public int GetDescendantsCount() => 0;
        }
    }
}
