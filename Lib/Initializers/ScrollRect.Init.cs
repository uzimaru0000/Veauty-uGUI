namespace Veauty.uGUI
{
    public partial class ScrollRect
    {
        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            if (go.GetComponent<UnityEngine.UI.Image>() == null)
                go.AddComponent<UnityEngine.UI.Image>();
            if (go.GetComponent<UnityEngine.UI.RectMask2D>() == null)
                go.AddComponent<UnityEngine.UI.RectMask2D>();
            return go;
        }

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
