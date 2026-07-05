using System.Collections.Generic;
using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;

namespace Veauty.uGUI
{
    public partial class Toggle
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
        /// Builds the toggle's internal structure: a left-anchored 24px-wide "Background" image
        /// wired to <c>targetGraphic</c> and, when a checkmark sub-component is present, a
        /// "Checkmark" image inside it wired to <c>graphic</c>. The checkmark is only created when
        /// a background is also present.
        /// </summary>
        /// <param name="go">The host GameObject (already has the Toggle component).</param>
        /// <returns>The same GameObject.</returns>
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

        /// <summary>Creates a <see cref="ToggleBackground"/> sub-component (box image).</summary>
        /// <param name="sprite">Optional sprite.</param>
        /// <param name="color">Optional color; defaults to RGB (0.22, 0.24, 0.28).</param>
        /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
        /// <returns>The sub-component to pass as a kid.</returns>
        public static IVTree Background(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new ToggleBackground(sprite, color, imageType);
        /// <summary>Creates a <see cref="ToggleCheckmark"/> sub-component (check image).</summary>
        /// <param name="sprite">Optional sprite.</param>
        /// <param name="color">Optional color; defaults to RGB (0.2, 0.75, 0.4).</param>
        /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
        /// <returns>The sub-component to pass as a kid.</returns>
        public static IVTree Checkmark(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new ToggleCheckmark(sprite, color, imageType);

        /// <summary>
        /// Sub-component configuration for the Toggle's background box. Implements
        /// <see cref="IVTree"/> only to travel in the kids array; it is filtered out by
        /// <see cref="GetKids"/> and consumed by <see cref="Init"/>.
        /// </summary>
        public class ToggleBackground : IVTree, ISubComponent
        {
            /// <summary>Sprite for the internal Image, or <c>null</c> to keep none.</summary>
            public readonly UnityEngine.Sprite sprite;
            /// <summary>Color of the internal Image.</summary>
            public readonly UnityEngine.Color color;
            /// <summary>Draw mode of the internal Image.</summary>
            public readonly UnityEngine.UI.Image.Type imageType;
            /// <summary>Creates the configuration.</summary>
            /// <param name="sprite">Optional sprite; defaults to none.</param>
            /// <param name="color">Optional color; defaults to RGB (0.22, 0.24, 0.28).</param>
            /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
            public ToggleBackground(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? new UnityEngine.Color(0.22f, 0.24f, 0.28f); this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            /// <summary>Always <see cref="VTreeType.Node"/> (never actually diffed).</summary>
            public VTreeType GetNodeType() => VTreeType.Node;
            /// <summary>Always 0; sub-components have no descendants.</summary>
            public int GetDescendantsCount() => 0;
        }
        /// <summary>
        /// Sub-component configuration for the Toggle's checkmark. Implements
        /// <see cref="IVTree"/> only to travel in the kids array; it is filtered out by
        /// <see cref="GetKids"/> and consumed by <see cref="Init"/>.
        /// </summary>
        public class ToggleCheckmark : IVTree, ISubComponent
        {
            /// <summary>Sprite for the internal Image, or <c>null</c> to keep none.</summary>
            public readonly UnityEngine.Sprite sprite;
            /// <summary>Color of the internal Image.</summary>
            public readonly UnityEngine.Color color;
            /// <summary>Draw mode of the internal Image.</summary>
            public readonly UnityEngine.UI.Image.Type imageType;
            /// <summary>Creates the configuration.</summary>
            /// <param name="sprite">Optional sprite; defaults to none.</param>
            /// <param name="color">Optional color; defaults to RGB (0.2, 0.75, 0.4).</param>
            /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
            public ToggleCheckmark(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? new UnityEngine.Color(0.2f, 0.75f, 0.4f); this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            /// <summary>Always <see cref="VTreeType.Node"/> (never actually diffed).</summary>
            public VTreeType GetNodeType() => VTreeType.Node;
            /// <summary>Always 0; sub-components have no descendants.</summary>
            public int GetDescendantsCount() => 0;
        }
    }
}
