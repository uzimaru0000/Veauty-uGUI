using System.Collections.Generic;
using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;

namespace Veauty.uGUI
{
    public partial class Slider
    {
        private IVTree[] _contentKids;
        /// <summary>
        /// Returns the content children only: <see cref="ISubComponent"/> configuration kids are
        /// filtered out so the diff/patch pipeline never sees them. The filtered array is computed
        /// once and cached for the lifetime of this node.
        /// </summary>
        /// <returns>The VTree children excluding sub-components.</returns>
        public override IVTree[] GetKids()
        {
            if (_contentKids != null) return _contentKids;
            var list = new List<IVTree>();
            foreach (var kid in kids)
                if (!(kid is ISubComponent)) list.Add(kid);
            _contentKids = list.ToArray();
            return _contentKids;
        }

        /// <summary>
        /// Builds the slider's internal structure from the sub-components present in the kids:
        /// a stretched "Background" image, a "Fill Area"/"Fill" wired to <c>fillRect</c>, and a
        /// "Handle Slide Area"/"Handle" wired to <c>handleRect</c> and <c>targetGraphic</c>.
        /// Parts whose sub-component is absent are not created.
        /// </summary>
        /// <param name="go">The host GameObject (already has the Slider component).</param>
        /// <returns>The same GameObject.</returns>
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

        /// <summary>Creates a <see cref="SliderBackground"/> sub-component (track image).</summary>
        /// <param name="sprite">Optional sprite.</param>
        /// <param name="color">Optional color; defaults to RGB (0.30, 0.32, 0.38).</param>
        /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
        /// <returns>The sub-component to pass as a kid.</returns>
        public static IVTree Background(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new SliderBackground(sprite, color, imageType);
        /// <summary>Creates a <see cref="SliderFill"/> sub-component (fill image).</summary>
        /// <param name="sprite">Optional sprite.</param>
        /// <param name="color">Optional color; defaults to RGB (0.22, 0.55, 0.95).</param>
        /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
        /// <returns>The sub-component to pass as a kid.</returns>
        public static IVTree Fill(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new SliderFill(sprite, color, imageType);
        /// <summary>Creates a <see cref="SliderHandle"/> sub-component (drag handle image).</summary>
        /// <param name="sprite">Optional sprite.</param>
        /// <param name="color">Optional color; defaults to white.</param>
        /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
        /// <returns>The sub-component to pass as a kid.</returns>
        public static IVTree Handle(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new SliderHandle(sprite, color, imageType);

        /// <summary>
        /// Sub-component configuration for the Slider's background track. Implements
        /// <see cref="IVTree"/> only to travel in the kids array; it is filtered out by
        /// <see cref="GetKids"/> and consumed by <see cref="Init"/>.
        /// </summary>
        public class SliderBackground : IVTree, ISubComponent
        {
            /// <summary>Sprite for the internal Image, or <c>null</c> to keep none.</summary>
            public readonly UnityEngine.Sprite sprite;
            /// <summary>Color of the internal Image.</summary>
            public readonly UnityEngine.Color color;
            /// <summary>Draw mode of the internal Image.</summary>
            public readonly UnityEngine.UI.Image.Type imageType;
            /// <summary>Creates the configuration.</summary>
            /// <param name="sprite">Optional sprite; defaults to none.</param>
            /// <param name="color">Optional color; defaults to RGB (0.30, 0.32, 0.38).</param>
            /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
            public SliderBackground(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? new UnityEngine.Color(0.30f, 0.32f, 0.38f); this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            /// <summary>Always <see cref="VTreeType.Node"/> (never actually diffed).</summary>
            public VTreeType GetNodeType() => VTreeType.Node;
            /// <summary>Always 0; sub-components have no descendants.</summary>
            public int GetDescendantsCount() => 0;
        }
        /// <summary>
        /// Sub-component configuration for the Slider's fill graphic. Implements
        /// <see cref="IVTree"/> only to travel in the kids array; it is filtered out by
        /// <see cref="GetKids"/> and consumed by <see cref="Init"/>.
        /// </summary>
        public class SliderFill : IVTree, ISubComponent
        {
            /// <summary>Sprite for the internal Image, or <c>null</c> to keep none.</summary>
            public readonly UnityEngine.Sprite sprite;
            /// <summary>Color of the internal Image.</summary>
            public readonly UnityEngine.Color color;
            /// <summary>Draw mode of the internal Image.</summary>
            public readonly UnityEngine.UI.Image.Type imageType;
            /// <summary>Creates the configuration.</summary>
            /// <param name="sprite">Optional sprite; defaults to none.</param>
            /// <param name="color">Optional color; defaults to RGB (0.22, 0.55, 0.95).</param>
            /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
            public SliderFill(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? new UnityEngine.Color(0.22f, 0.55f, 0.95f); this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            /// <summary>Always <see cref="VTreeType.Node"/> (never actually diffed).</summary>
            public VTreeType GetNodeType() => VTreeType.Node;
            /// <summary>Always 0; sub-components have no descendants.</summary>
            public int GetDescendantsCount() => 0;
        }
        /// <summary>
        /// Sub-component configuration for the Slider's drag handle. Implements
        /// <see cref="IVTree"/> only to travel in the kids array; it is filtered out by
        /// <see cref="GetKids"/> and consumed by <see cref="Init"/>.
        /// </summary>
        public class SliderHandle : IVTree, ISubComponent
        {
            /// <summary>Sprite for the internal Image, or <c>null</c> to keep none.</summary>
            public readonly UnityEngine.Sprite sprite;
            /// <summary>Color of the internal Image.</summary>
            public readonly UnityEngine.Color color;
            /// <summary>Draw mode of the internal Image.</summary>
            public readonly UnityEngine.UI.Image.Type imageType;
            /// <summary>Creates the configuration.</summary>
            /// <param name="sprite">Optional sprite; defaults to none.</param>
            /// <param name="color">Optional color; defaults to white.</param>
            /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
            public SliderHandle(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? UnityEngine.Color.white; this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            /// <summary>Always <see cref="VTreeType.Node"/> (never actually diffed).</summary>
            public VTreeType GetNodeType() => VTreeType.Node;
            /// <summary>Always 0; sub-components have no descendants.</summary>
            public int GetDescendantsCount() => 0;
        }
    }
}
