namespace Veauty.uGUI
{
    public partial class Text
    {
        /// <summary>
        /// Assigns the built-in <c>LegacyRuntime.ttf</c> font when the Text component has no font,
        /// so text renders without explicit font setup.
        /// </summary>
        /// <param name="go">The host GameObject (already has the Text component).</param>
        /// <returns>The same GameObject.</returns>
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
