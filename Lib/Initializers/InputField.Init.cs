using System.Collections.Generic;
using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;

namespace Veauty.uGUI
{
    public partial class InputField
    {
        private IVTree[] _contentKids;
        public override IVTree[] GetKids()
        {
            if (_contentKids != null) return _contentKids;
            var list = new List<IVTree>();
            foreach (var kid in kids)
                if (!(kid is ISubComponent)) list.Add(kid);
            _contentKids = list.ToArray();
            return _contentKids;
        }

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

        public static IVTree PlaceholderText(string text = null, UnityEngine.Color? color = null, int? fontSize = null, UnityEngine.TextAnchor? alignment = null)
            => new InputFieldPlaceholderPart(text, color, fontSize, alignment);
        public static IVTree TextDisplay(UnityEngine.Color? color = null, int? fontSize = null, UnityEngine.TextAnchor? alignment = null)
            => new InputFieldTextPart(color, fontSize, alignment);

        public class InputFieldPlaceholderPart : IVTree, ISubComponent
        {
            public readonly string text;
            public readonly UnityEngine.Color color;
            public readonly int fontSize;
            public readonly UnityEngine.TextAnchor alignment;
            public InputFieldPlaceholderPart(string text = null, UnityEngine.Color? color = null, int? fontSize = null, UnityEngine.TextAnchor? alignment = null)
            {
                this.text = text ?? "Enter text...";
                this.color = color ?? new UnityEngine.Color(0.5f, 0.5f, 0.5f, 0.75f);
                this.fontSize = fontSize ?? 16;
                this.alignment = alignment ?? UnityEngine.TextAnchor.MiddleLeft;
            }
            public VTreeType GetNodeType() => VTreeType.Node;
            public int GetDescendantsCount() => 0;
        }
        public class InputFieldTextPart : IVTree, ISubComponent
        {
            public readonly UnityEngine.Color color;
            public readonly int fontSize;
            public readonly UnityEngine.TextAnchor alignment;
            public InputFieldTextPart(UnityEngine.Color? color = null, int? fontSize = null, UnityEngine.TextAnchor? alignment = null)
            {
                this.color = color ?? UnityEngine.Color.white;
                this.fontSize = fontSize ?? 16;
                this.alignment = alignment ?? UnityEngine.TextAnchor.MiddleLeft;
            }
            public VTreeType GetNodeType() => VTreeType.Node;
            public int GetDescendantsCount() => 0;
        }
    }
}
