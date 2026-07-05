using System.Collections.Generic;
using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;

namespace Veauty.uGUI
{
    public partial class InputField
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
        /// Builds the input field's internal structure: adds a background Image with color
        /// RGB (0.16, 0.18, 0.22) when none exists (wired to <c>targetGraphic</c>), then a
        /// "Text Area" with <c>RectMask2D</c> containing an italic "Placeholder" text (wired to
        /// <c>placeholder</c>) and a "Text" component with rich text disabled (wired to
        /// <c>textComponent</c>). Both texts use the built-in <c>LegacyRuntime.ttf</c> font.
        /// </summary>
        /// <param name="go">The host GameObject (already has the InputField component).</param>
        /// <returns>The same GameObject.</returns>
        public override UnityGameObject Init(UnityGameObject go)
        {
            var input = go.GetComponent<UnityEngine.UI.InputField>();
            var phCfg = FindPart<InputFieldPlaceholderPart>();
            var txtCfg = FindPart<InputFieldTextPart>();

            var bgImage = go.GetComponent<UnityEngine.UI.Image>();
            if (bgImage == null)
                bgImage = AddVisual<UnityEngine.UI.Image>(go, new UnityEngine.Color(0.16f, 0.18f, 0.22f));
            input.targetGraphic = bgImage;

            if (phCfg != null || txtCfg != null)
            {
                var textArea = CreateChild(go, "Text Area");
                SetupRect(textArea.GetComponent<UnityEngine.RectTransform>(),
                    anchorMin: UnityEngine.Vector2.zero,
                    anchorMax: UnityEngine.Vector2.one,
                    offsetMin: new UnityEngine.Vector2(10f, 2f),
                    offsetMax: new UnityEngine.Vector2(-10f, -2f));
                textArea.AddComponent<UnityEngine.UI.RectMask2D>();

                if (phCfg != null)
                {
                    var ph = CreateChild(textArea, "Placeholder");
                    var phText = AddVisual<UnityEngine.UI.Text>(ph, phCfg.color);
                    phText.text = phCfg.text;
                    phText.fontStyle = UnityEngine.FontStyle.Italic;
                    phText.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>("LegacyRuntime.ttf");
                    phText.fontSize = phCfg.fontSize;
                    phText.alignment = phCfg.alignment;
                    Stretch(ph.GetComponent<UnityEngine.RectTransform>());
                    input.placeholder = phText;
                }

                if (txtCfg != null)
                {
                    var txt = CreateChild(textArea, "Text");
                    var textComp = AddVisual<UnityEngine.UI.Text>(txt, txtCfg.color);
                    textComp.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>("LegacyRuntime.ttf");
                    textComp.fontSize = txtCfg.fontSize;
                    textComp.alignment = txtCfg.alignment;
                    textComp.supportRichText = false;
                    Stretch(txt.GetComponent<UnityEngine.RectTransform>());
                    input.textComponent = textComp;
                }
            }

            return go;
        }

        /// <summary>Creates an <see cref="InputFieldPlaceholderPart"/> sub-component.</summary>
        /// <param name="text">Optional placeholder string; defaults to "Enter text...".</param>
        /// <param name="color">Optional color; defaults to RGBA (0.5, 0.5, 0.5, 0.75).</param>
        /// <param name="fontSize">Optional font size; defaults to 16.</param>
        /// <param name="alignment">Optional anchor; defaults to <c>MiddleLeft</c>.</param>
        /// <returns>The sub-component to pass as a kid.</returns>
        public static IVTree PlaceholderText(string text = null, UnityEngine.Color? color = null, int? fontSize = null, UnityEngine.TextAnchor? alignment = null)
            => new InputFieldPlaceholderPart(text, color, fontSize, alignment);
        /// <summary>Creates an <see cref="InputFieldTextPart"/> sub-component.</summary>
        /// <param name="color">Optional color; defaults to white.</param>
        /// <param name="fontSize">Optional font size; defaults to 16.</param>
        /// <param name="alignment">Optional anchor; defaults to <c>MiddleLeft</c>.</param>
        /// <returns>The sub-component to pass as a kid.</returns>
        public static IVTree TextDisplay(UnityEngine.Color? color = null, int? fontSize = null, UnityEngine.TextAnchor? alignment = null)
            => new InputFieldTextPart(color, fontSize, alignment);

        /// <summary>
        /// Sub-component configuration for the InputField's placeholder text. Implements
        /// <see cref="IVTree"/> only to travel in the kids array; it is filtered out by
        /// <see cref="GetKids"/> and consumed by <see cref="Init"/>.
        /// </summary>
        public class InputFieldPlaceholderPart : IVTree, ISubComponent
        {
            /// <summary>Placeholder string shown while the field is empty.</summary>
            public readonly string text;
            /// <summary>Text color of the internal Text component.</summary>
            public readonly UnityEngine.Color color;
            /// <summary>Font size of the internal Text component.</summary>
            public readonly int fontSize;
            /// <summary>Alignment of the internal Text component.</summary>
            public readonly UnityEngine.TextAnchor alignment;
            /// <summary>Creates the configuration.</summary>
            /// <param name="text">Optional placeholder string; defaults to "Enter text...".</param>
            /// <param name="color">Optional color; defaults to RGBA (0.5, 0.5, 0.5, 0.75).</param>
            /// <param name="fontSize">Optional font size; defaults to 16.</param>
            /// <param name="alignment">Optional anchor; defaults to <c>MiddleLeft</c>.</param>
            public InputFieldPlaceholderPart(string text = null, UnityEngine.Color? color = null, int? fontSize = null, UnityEngine.TextAnchor? alignment = null)
            {
                this.text = text ?? "Enter text...";
                this.color = color ?? new UnityEngine.Color(0.5f, 0.5f, 0.5f, 0.75f);
                this.fontSize = fontSize ?? 16;
                this.alignment = alignment ?? UnityEngine.TextAnchor.MiddleLeft;
            }
            /// <summary>Always <see cref="VTreeType.Node"/> (never actually diffed).</summary>
            public VTreeType GetNodeType() => VTreeType.Node;
            /// <summary>Always 0; sub-components have no descendants.</summary>
            public int GetDescendantsCount() => 0;
        }
        /// <summary>
        /// Sub-component configuration for the InputField's editable text display. Implements
        /// <see cref="IVTree"/> only to travel in the kids array; it is filtered out by
        /// <see cref="GetKids"/> and consumed by <see cref="Init"/>.
        /// </summary>
        public class InputFieldTextPart : IVTree, ISubComponent
        {
            /// <summary>Text color of the internal Text component.</summary>
            public readonly UnityEngine.Color color;
            /// <summary>Font size of the internal Text component.</summary>
            public readonly int fontSize;
            /// <summary>Alignment of the internal Text component.</summary>
            public readonly UnityEngine.TextAnchor alignment;
            /// <summary>Creates the configuration.</summary>
            /// <param name="color">Optional color; defaults to white.</param>
            /// <param name="fontSize">Optional font size; defaults to 16.</param>
            /// <param name="alignment">Optional anchor; defaults to <c>MiddleLeft</c>.</param>
            public InputFieldTextPart(UnityEngine.Color? color = null, int? fontSize = null, UnityEngine.TextAnchor? alignment = null)
            {
                this.color = color ?? UnityEngine.Color.white;
                this.fontSize = fontSize ?? 16;
                this.alignment = alignment ?? UnityEngine.TextAnchor.MiddleLeft;
            }
            /// <summary>Always <see cref="VTreeType.Node"/> (never actually diffed).</summary>
            public VTreeType GetNodeType() => VTreeType.Node;
            /// <summary>Always 0; sub-components have no descendants.</summary>
            public int GetDescendantsCount() => 0;
        }
    }
}
