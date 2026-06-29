namespace Veauty.uGUI
{
    public partial class Text
    {
        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var text = go.GetComponent<UnityEngine.UI.Text>();
            if (text.font == null)
            {
                text.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>("LegacyRuntime.ttf");
            }
            return go;
        }
    }
}
