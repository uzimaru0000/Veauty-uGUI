using System.Collections.Generic;
using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;

namespace Veauty.uGUI
{
    public partial class Scrollbar
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
        /// Builds the scrollbar's internal structure: adds a background Image with color
        /// RGB (0.22, 0.24, 0.28) when none exists, and — when a handle sub-component is present —
        /// a stretched "Sliding Area" with a "Handle" image wired to <c>handleRect</c> and
        /// <c>targetGraphic</c>.
        /// </summary>
        /// <param name="go">The host GameObject (already has the Scrollbar component).</param>
        /// <returns>The same GameObject.</returns>
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

        /// <summary>Creates a <see cref="ScrollbarHandlePart"/> sub-component (handle image).</summary>
        /// <param name="sprite">Optional sprite.</param>
        /// <param name="color">Optional color; defaults to RGB (0.5, 0.5, 0.5).</param>
        /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
        /// <returns>The sub-component to pass as a kid.</returns>
        public static IVTree Handle(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            => new ScrollbarHandlePart(sprite, color, imageType);

        /// <summary>
        /// Sub-component configuration for the Scrollbar's handle. Implements
        /// <see cref="IVTree"/> only to travel in the kids array; it is filtered out by
        /// <see cref="GetKids"/> and consumed by <see cref="Init"/>.
        /// </summary>
        public class ScrollbarHandlePart : IVTree, ISubComponent
        {
            /// <summary>Sprite for the internal Image, or <c>null</c> to keep none.</summary>
            public readonly UnityEngine.Sprite sprite;
            /// <summary>Color of the internal Image.</summary>
            public readonly UnityEngine.Color color;
            /// <summary>Draw mode of the internal Image.</summary>
            public readonly UnityEngine.UI.Image.Type imageType;
            /// <summary>Creates the configuration.</summary>
            /// <param name="sprite">Optional sprite; defaults to none.</param>
            /// <param name="color">Optional color; defaults to RGB (0.5, 0.5, 0.5).</param>
            /// <param name="imageType">Optional image type; defaults to <c>Simple</c>.</param>
            public ScrollbarHandlePart(UnityEngine.Sprite sprite = null, UnityEngine.Color? color = null, UnityEngine.UI.Image.Type? imageType = null)
            { this.sprite = sprite; this.color = color ?? new UnityEngine.Color(0.5f, 0.5f, 0.5f); this.imageType = imageType ?? UnityEngine.UI.Image.Type.Simple; }
            /// <summary>Always <see cref="VTreeType.Node"/> (never actually diffed).</summary>
            public VTreeType GetNodeType() => VTreeType.Node;
            /// <summary>Always 0; sub-components have no descendants.</summary>
            public int GetDescendantsCount() => 0;
        }
    }
}
