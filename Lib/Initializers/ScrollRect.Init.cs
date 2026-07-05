namespace Veauty.uGUI
{
    public partial class ScrollRect
    {
        /// <summary>
        /// Adds an <c>Image</c> (viewport background/raycast target) and a <c>RectMask2D</c>
        /// (content clipping) when they are missing.
        /// </summary>
        /// <param name="go">The host GameObject (already has the ScrollRect component).</param>
        /// <returns>The same GameObject.</returns>
        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            if (go.GetComponent<UnityEngine.UI.Image>() == null)
                go.AddComponent<UnityEngine.UI.Image>();
            if (go.GetComponent<UnityEngine.UI.RectMask2D>() == null)
                go.AddComponent<UnityEngine.UI.RectMask2D>();
            return go;
        }

        /// <summary>
        /// After the VTree children are rendered, wires the first child as the scroll
        /// <c>content</c> (anchored to stretch across the top) — but only when <c>content</c> has
        /// not been set already (e.g. via the <c>ScrollRect.Content</c> attribute).
        /// </summary>
        /// <param name="go">The host GameObject with all children attached.</param>
        public override void AfterRenderKids(UnityEngine.GameObject go)
        {
            var scrollRect = go.GetComponent<UnityEngine.UI.ScrollRect>();
            if (scrollRect != null && scrollRect.content == null && go.transform.childCount > 0)
            {
                var contentRT = go.transform.GetChild(0).GetComponent<UnityEngine.RectTransform>();
                SetupRect(contentRT,
                    anchorMin: new UnityEngine.Vector2(0f, 1f),
                    anchorMax: UnityEngine.Vector2.one,
                    pivot: new UnityEngine.Vector2(0.5f, 1f));
                scrollRect.content = contentRT;
            }
        }
    }
}
