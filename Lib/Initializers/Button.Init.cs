namespace Veauty.uGUI
{
    public partial class Button
    {
        public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var button = go.GetComponent<UnityEngine.UI.Button>();
            var graphic = go.GetComponent<UnityEngine.UI.Graphic>();
            if (graphic == null)
            {
                graphic = go.AddComponent<UnityEngine.UI.Image>();
            }
            button.targetGraphic = graphic;
            return go;
        }
    }
}
