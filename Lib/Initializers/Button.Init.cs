namespace Veauty.uGUI
{
    public partial class Button
    {
        /// <summary>
        /// Ensures the button has a <c>targetGraphic</c>: uses the existing Graphic on the
        /// GameObject or adds an <c>Image</c> when none exists.
        /// </summary>
        /// <param name="go">The host GameObject (already has the Button component).</param>
        /// <returns>The same GameObject.</returns>
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
