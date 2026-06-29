using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIClass : MonoBehaviour
{
    private const string GeneratedDirectory = "Packages/com.uzimaru.veauty-ugui/Lib/Generated";

    private static readonly Type[] ExtraTypes = {
        typeof(Canvas),
        typeof(CanvasGroup),
        typeof(RectTransform)
    };

    private static readonly HashSet<string> ManualTypes = new HashSet<string> {
        nameof(Canvas),
        nameof(CanvasGroup),
        nameof(RectTransform)
    };

    private static readonly HashSet<string> PartialTypes = new HashSet<string> {
        nameof(GridLayoutGroup),
        nameof(HorizontalLayoutGroup),
        nameof(VerticalLayoutGroup)
    };

    [MenuItem("Veauty/GenerateUIClass")]
    private static void GenerateUIClass()
    {
        Directory.CreateDirectory(GeneratedDirectory);

        GetTargetTypes()
            .Where(type => !ManualTypes.Contains(type.Name))
            .ToList()
            .ForEach(type => {
                var properties = GetWritableProperties(type);
                var code = GUIScriptTemplate(type, properties);
                CreateScript(type.Name, code);
            });

        AssetDatabase.Refresh();
    }

    private static IEnumerable<Type> GetTargetTypes()
    {
        var uiAssembly = Assembly.GetAssembly(typeof(Button));
        var uiTypes = uiAssembly.GetTypes()
            .Where(type => type.Namespace == "UnityEngine.UI")
            .Where(type => type.IsSubclassOf(typeof(MonoBehaviour)))
            .Where(type => type.IsVisible);

        return uiTypes
            .Concat(ExtraTypes)
            .Distinct()
            .OrderBy(type => type.Name);
    }

    private static IEnumerable<PropertyInfo> GetWritableProperties(Type type)
    {
        return type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
            .Where(property => property.SetMethod != null && property.SetMethod.IsPublic)
            .Where(property => property.GetIndexParameters().Length == 0)
            .Where(property => !IsObsolete(property))
            .Where(property => ToPascalCase(property.Name) != type.Name);
    }

    private static bool IsObsolete(PropertyInfo property)
    {
        return property.GetCustomAttribute<ObsoleteAttribute>() != null
            || property.GetMethod?.GetCustomAttribute<ObsoleteAttribute>() != null
            || property.SetMethod?.GetCustomAttribute<ObsoleteAttribute>() != null;
    }

    private static void CreateScript(string name, string code)
    {
        var filePath = Path.Combine(GeneratedDirectory, name + ".cs");
        File.WriteAllText(filePath, code);
    }

    private static string GUIScriptTemplate(Type uGUIType, IEnumerable<PropertyInfo> propertyTypes)
    {
        var classModifier = PartialTypes.Contains(uGUIType.Name) ? "partial " : "";

        return $@"
// THIS CODE IS AUTO GENERATED

using System.Collections.Generic;
using Veauty.VTree;

namespace Veauty.uGUI
{{
    public abstract class {uGUIType.Name}Attribute<T> : GuiAttributeBase<{TypeString(uGUIType)}, T>
    {{
        protected {uGUIType.Name}Attribute(string key, T value) : base(key, value) {{ }}
    }}

    public {classModifier}class {uGUIType.Name} : GUIBase<{TypeString(uGUIType)}>
    {{
        public {uGUIType.Name}(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) {{ }}

        {InitTemplate(uGUIType)}
        public override void Destroy(UnityEngine.GameObject go) {{ }}

{PropertyClassesTemplate(uGUIType, propertyTypes)}
    }}
}}";
    }

    private static string InitTemplate(Type uGUIType)
    {
        if (uGUIType == typeof(Button))
        {
            return @"public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var button = go.GetComponent<UnityEngine.UI.Button>();
            var graphic = go.GetComponent<UnityEngine.UI.Graphic>();
            if (graphic == null)
            {
                graphic = go.AddComponent<UnityEngine.UI.Image>();
            }

            button.targetGraphic = graphic;
            return go;
        }";
        }

        if (uGUIType == typeof(Text))
        {
            return @"public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var text = go.GetComponent<UnityEngine.UI.Text>();
            if (text.font == null)
            {
                text.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>(""LegacyRuntime.ttf"");
            }

            return go;
        }";
        }

        if (uGUIType == typeof(Toggle))
        {
            return @"public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var toggle = go.GetComponent<UnityEngine.UI.Toggle>();
            var bg = CreateChild(go, ""Background"");
            bg.AddComponent<UnityEngine.CanvasRenderer>();
            var bgImage = bg.AddComponent<UnityEngine.UI.Image>();
            bgImage.color = new UnityEngine.Color(0.22f, 0.24f, 0.28f);
            var bgRect = bg.GetComponent<UnityEngine.RectTransform>();
            bgRect.anchorMin = new UnityEngine.Vector2(0f, 0.1f);
            bgRect.anchorMax = new UnityEngine.Vector2(0f, 0.9f);
            bgRect.pivot = new UnityEngine.Vector2(0f, 0.5f);
            bgRect.sizeDelta = new UnityEngine.Vector2(24f, 0f);
            toggle.targetGraphic = bgImage;
            var cm = CreateChild(bg, ""Checkmark"");
            cm.AddComponent<UnityEngine.CanvasRenderer>();
            var cmImage = cm.AddComponent<UnityEngine.UI.Image>();
            cmImage.color = new UnityEngine.Color(0.2f, 0.75f, 0.4f);
            var cmRect = cm.GetComponent<UnityEngine.RectTransform>();
            cmRect.anchorMin = new UnityEngine.Vector2(0.15f, 0.15f);
            cmRect.anchorMax = new UnityEngine.Vector2(0.85f, 0.85f);
            cmRect.sizeDelta = UnityEngine.Vector2.zero;
            toggle.graphic = cmImage;
            return go;
        }";
        }

        if (uGUIType == typeof(Slider))
        {
            return @"public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var slider = go.GetComponent<UnityEngine.UI.Slider>();
            var bg = CreateChild(go, ""Background"");
            bg.AddComponent<UnityEngine.CanvasRenderer>();
            var bgImage = bg.AddComponent<UnityEngine.UI.Image>();
            bgImage.color = new UnityEngine.Color(0.22f, 0.24f, 0.28f);
            Stretch(bg.GetComponent<UnityEngine.RectTransform>());
            var fillArea = CreateChild(go, ""Fill Area"");
            var fillAreaRect = fillArea.GetComponent<UnityEngine.RectTransform>();
            fillAreaRect.anchorMin = new UnityEngine.Vector2(0f, 0.25f);
            fillAreaRect.anchorMax = new UnityEngine.Vector2(1f, 0.75f);
            fillAreaRect.offsetMin = new UnityEngine.Vector2(5f, 0f);
            fillAreaRect.offsetMax = new UnityEngine.Vector2(-5f, 0f);
            var fill = CreateChild(fillArea, ""Fill"");
            fill.AddComponent<UnityEngine.CanvasRenderer>();
            var fillImage = fill.AddComponent<UnityEngine.UI.Image>();
            fillImage.color = new UnityEngine.Color(0.22f, 0.55f, 0.95f);
            fill.GetComponent<UnityEngine.RectTransform>().sizeDelta = UnityEngine.Vector2.zero;
            slider.fillRect = fill.GetComponent<UnityEngine.RectTransform>();
            var handleArea = CreateChild(go, ""Handle Slide Area"");
            var handleAreaRect = handleArea.GetComponent<UnityEngine.RectTransform>();
            handleAreaRect.anchorMin = UnityEngine.Vector2.zero;
            handleAreaRect.anchorMax = UnityEngine.Vector2.one;
            handleAreaRect.offsetMin = new UnityEngine.Vector2(10f, 0f);
            handleAreaRect.offsetMax = new UnityEngine.Vector2(-10f, 0f);
            var handle = CreateChild(handleArea, ""Handle"");
            handle.AddComponent<UnityEngine.CanvasRenderer>();
            var handleImage = handle.AddComponent<UnityEngine.UI.Image>();
            handleImage.color = UnityEngine.Color.white;
            handle.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2(20f, 0f);
            slider.handleRect = handle.GetComponent<UnityEngine.RectTransform>();
            slider.targetGraphic = handleImage;
            return go;
        }";
        }

        if (uGUIType == typeof(Scrollbar))
        {
            return @"public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var scrollbar = go.GetComponent<UnityEngine.UI.Scrollbar>();
            var bgImage = go.GetComponent<UnityEngine.UI.Image>();
            if (bgImage == null) { go.AddComponent<UnityEngine.CanvasRenderer>(); bgImage = go.AddComponent<UnityEngine.UI.Image>(); }
            bgImage.color = new UnityEngine.Color(0.22f, 0.24f, 0.28f);
            var slideArea = CreateChild(go, ""Sliding Area"");
            Stretch(slideArea.GetComponent<UnityEngine.RectTransform>());
            var handle = CreateChild(slideArea, ""Handle"");
            handle.AddComponent<UnityEngine.CanvasRenderer>();
            var handleImage = handle.AddComponent<UnityEngine.UI.Image>();
            handleImage.color = new UnityEngine.Color(0.5f, 0.5f, 0.5f);
            handle.GetComponent<UnityEngine.RectTransform>().sizeDelta = UnityEngine.Vector2.zero;
            scrollbar.handleRect = handle.GetComponent<UnityEngine.RectTransform>();
            scrollbar.targetGraphic = handleImage;
            return go;
        }";
        }

        if (uGUIType == typeof(InputField))
        {
            return @"public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var input = go.GetComponent<UnityEngine.UI.InputField>();
            var bgImage = go.GetComponent<UnityEngine.UI.Image>();
            if (bgImage == null) { go.AddComponent<UnityEngine.CanvasRenderer>(); bgImage = go.AddComponent<UnityEngine.UI.Image>(); }
            bgImage.color = new UnityEngine.Color(0.16f, 0.18f, 0.22f);
            input.targetGraphic = bgImage;
            var textArea = CreateChild(go, ""Text Area"");
            var textAreaRect = textArea.GetComponent<UnityEngine.RectTransform>();
            textAreaRect.anchorMin = UnityEngine.Vector2.zero;
            textAreaRect.anchorMax = UnityEngine.Vector2.one;
            textAreaRect.offsetMin = new UnityEngine.Vector2(10f, 2f);
            textAreaRect.offsetMax = new UnityEngine.Vector2(-10f, -2f);
            textArea.AddComponent<UnityEngine.UI.RectMask2D>();
            var ph = CreateChild(textArea, ""Placeholder"");
            ph.AddComponent<UnityEngine.CanvasRenderer>();
            var phText = ph.AddComponent<UnityEngine.UI.Text>();
            phText.text = ""Enter text..."";
            phText.fontStyle = UnityEngine.FontStyle.Italic;
            phText.color = new UnityEngine.Color(0.5f, 0.5f, 0.5f, 0.75f);
            phText.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>(""LegacyRuntime.ttf"");
            phText.fontSize = 16;
            phText.alignment = UnityEngine.TextAnchor.MiddleLeft;
            Stretch(ph.GetComponent<UnityEngine.RectTransform>());
            input.placeholder = phText;
            var txt = CreateChild(textArea, ""Text"");
            txt.AddComponent<UnityEngine.CanvasRenderer>();
            var textComp = txt.AddComponent<UnityEngine.UI.Text>();
            textComp.color = UnityEngine.Color.white;
            textComp.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>(""LegacyRuntime.ttf"");
            textComp.fontSize = 16;
            textComp.alignment = UnityEngine.TextAnchor.MiddleLeft;
            textComp.supportRichText = false;
            Stretch(txt.GetComponent<UnityEngine.RectTransform>());
            input.textComponent = textComp;
            return go;
        }";
        }

        if (uGUIType == typeof(Dropdown))
        {
            return @"public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            var dropdown = go.GetComponent<UnityEngine.UI.Dropdown>();
            var bgImage = go.GetComponent<UnityEngine.UI.Image>();
            if (bgImage == null) { go.AddComponent<UnityEngine.CanvasRenderer>(); bgImage = go.AddComponent<UnityEngine.UI.Image>(); }
            bgImage.color = new UnityEngine.Color(0.22f, 0.24f, 0.28f);
            dropdown.targetGraphic = bgImage;
            var label = CreateChild(go, ""Label"");
            label.AddComponent<UnityEngine.CanvasRenderer>();
            var labelText = label.AddComponent<UnityEngine.UI.Text>();
            labelText.alignment = UnityEngine.TextAnchor.MiddleLeft;
            labelText.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>(""LegacyRuntime.ttf"");
            labelText.fontSize = 16;
            labelText.color = UnityEngine.Color.white;
            var labelRect = label.GetComponent<UnityEngine.RectTransform>();
            labelRect.anchorMin = UnityEngine.Vector2.zero;
            labelRect.anchorMax = UnityEngine.Vector2.one;
            labelRect.offsetMin = new UnityEngine.Vector2(10f, 0f);
            labelRect.offsetMax = new UnityEngine.Vector2(-30f, 0f);
            dropdown.captionText = labelText;
            var arrow = CreateChild(go, ""Arrow"");
            arrow.AddComponent<UnityEngine.CanvasRenderer>();
            var arrowText = arrow.AddComponent<UnityEngine.UI.Text>();
            arrowText.text = ""▼"";
            arrowText.alignment = UnityEngine.TextAnchor.MiddleCenter;
            arrowText.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>(""LegacyRuntime.ttf"");
            arrowText.fontSize = 14;
            arrowText.color = UnityEngine.Color.white;
            var arrowRect = arrow.GetComponent<UnityEngine.RectTransform>();
            arrowRect.anchorMin = new UnityEngine.Vector2(1f, 0f);
            arrowRect.anchorMax = new UnityEngine.Vector2(1f, 1f);
            arrowRect.pivot = new UnityEngine.Vector2(1f, 0.5f);
            arrowRect.sizeDelta = new UnityEngine.Vector2(28f, 0f);
            var template = CreateChild(go, ""Template"");
            template.AddComponent<UnityEngine.CanvasRenderer>();
            var templateImage = template.AddComponent<UnityEngine.UI.Image>();
            templateImage.color = new UnityEngine.Color(0.16f, 0.18f, 0.22f);
            var scrollRect = template.AddComponent<UnityEngine.UI.ScrollRect>();
            scrollRect.horizontal = false;
            scrollRect.movementType = UnityEngine.UI.ScrollRect.MovementType.Clamped;
            var templateRect = template.GetComponent<UnityEngine.RectTransform>();
            templateRect.anchorMin = new UnityEngine.Vector2(0f, 0f);
            templateRect.anchorMax = new UnityEngine.Vector2(1f, 0f);
            templateRect.pivot = new UnityEngine.Vector2(0.5f, 1f);
            templateRect.sizeDelta = new UnityEngine.Vector2(0f, 200f);
            var viewport = CreateChild(template, ""Viewport"");
            viewport.AddComponent<UnityEngine.CanvasRenderer>();
            viewport.AddComponent<UnityEngine.UI.Image>().color = UnityEngine.Color.white;
            viewport.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = false;
            Stretch(viewport.GetComponent<UnityEngine.RectTransform>());
            scrollRect.viewport = viewport.GetComponent<UnityEngine.RectTransform>();
            var content = CreateChild(viewport, ""Content"");
            var contentRect = content.GetComponent<UnityEngine.RectTransform>();
            contentRect.anchorMin = new UnityEngine.Vector2(0f, 1f);
            contentRect.anchorMax = new UnityEngine.Vector2(1f, 1f);
            contentRect.pivot = new UnityEngine.Vector2(0.5f, 1f);
            contentRect.sizeDelta = new UnityEngine.Vector2(0f, 36f);
            scrollRect.content = contentRect;
            var csf = content.AddComponent<UnityEngine.UI.ContentSizeFitter>();
            csf.verticalFit = UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize;
            var vlg = content.AddComponent<UnityEngine.UI.VerticalLayoutGroup>();
            vlg.childControlWidth = true;
            vlg.childControlHeight = true;
            vlg.childForceExpandWidth = true;
            vlg.childForceExpandHeight = false;
            var item = CreateChild(content, ""Item"");
            var itemToggle = item.AddComponent<UnityEngine.UI.Toggle>();
            item.AddComponent<UnityEngine.UI.LayoutElement>().preferredHeight = 36f;
            var itemRect = item.GetComponent<UnityEngine.RectTransform>();
            itemRect.anchorMin = new UnityEngine.Vector2(0f, 0.5f);
            itemRect.anchorMax = new UnityEngine.Vector2(1f, 0.5f);
            itemRect.sizeDelta = new UnityEngine.Vector2(0f, 36f);
            var itemBg = CreateChild(item, ""Item Background"");
            itemBg.AddComponent<UnityEngine.CanvasRenderer>();
            var itemBgImage = itemBg.AddComponent<UnityEngine.UI.Image>();
            itemBgImage.color = UnityEngine.Color.white;
            Stretch(itemBg.GetComponent<UnityEngine.RectTransform>());
            itemToggle.targetGraphic = itemBgImage;
            var cb = itemToggle.colors;
            cb.normalColor = new UnityEngine.Color(0.22f, 0.24f, 0.30f);
            cb.highlightedColor = new UnityEngine.Color(0.32f, 0.40f, 0.58f);
            cb.pressedColor = new UnityEngine.Color(0.22f, 0.55f, 0.95f);
            cb.selectedColor = new UnityEngine.Color(0.26f, 0.32f, 0.45f);
            cb.colorMultiplier = 1f;
            itemToggle.colors = cb;
            var itemCheckmark = CreateChild(item, ""Item Checkmark"");
            itemCheckmark.AddComponent<UnityEngine.CanvasRenderer>();
            var cmImage = itemCheckmark.AddComponent<UnityEngine.UI.Image>();
            cmImage.color = new UnityEngine.Color(0.22f, 0.55f, 0.95f);
            var cmRect = itemCheckmark.GetComponent<UnityEngine.RectTransform>();
            cmRect.anchorMin = new UnityEngine.Vector2(0f, 0f);
            cmRect.anchorMax = new UnityEngine.Vector2(0f, 1f);
            cmRect.pivot = new UnityEngine.Vector2(0f, 0.5f);
            cmRect.sizeDelta = new UnityEngine.Vector2(4f, 0f);
            itemToggle.graphic = cmImage;
            var itemLabel = CreateChild(item, ""Item Label"");
            itemLabel.AddComponent<UnityEngine.CanvasRenderer>();
            var itemLabelText = itemLabel.AddComponent<UnityEngine.UI.Text>();
            itemLabelText.alignment = UnityEngine.TextAnchor.MiddleLeft;
            itemLabelText.font = UnityEngine.Resources.GetBuiltinResource<UnityEngine.Font>(""LegacyRuntime.ttf"");
            itemLabelText.fontSize = 18;
            itemLabelText.color = UnityEngine.Color.white;
            var itemLabelRect = itemLabel.GetComponent<UnityEngine.RectTransform>();
            itemLabelRect.anchorMin = UnityEngine.Vector2.zero;
            itemLabelRect.anchorMax = UnityEngine.Vector2.one;
            itemLabelRect.offsetMin = new UnityEngine.Vector2(12f, 0f);
            itemLabelRect.offsetMax = UnityEngine.Vector2.zero;
            dropdown.itemText = itemLabelText;
            dropdown.template = templateRect;
            template.SetActive(false);
            return go;
        }";
        }

        return @"public override UnityEngine.GameObject Init(UnityEngine.GameObject go)
        {
            return go;
        }";
    }

    private static string PropertyClassesTemplate(Type uGUIType, IEnumerable<PropertyInfo> propertyTypes)
    {
        var templates = propertyTypes.Select(property => UIPropertyClassTemplate(uGUIType, property)).ToList();

        if (uGUIType == typeof(Text))
        {
            templates.Insert(0, TextValueTemplate());
        }

        return string.Join("\n", templates);
    }

    private static string UIPropertyClassTemplate(Type baseClass, PropertyInfo property)
    {
        if (baseClass == typeof(Button) && property.Name == "onClick")
        {
            return @"
        public class OnClick : ButtonAttribute<UnityEngine.Events.UnityAction>
        {
            public OnClick(UnityEngine.Events.UnityAction value): base(""onClick"", value) {}
            protected override void Apply(UnityEngine.UI.Button component)
            {
                component.onClick.RemoveAllListeners();
                component.onClick.AddListener(GetValue());
            }
        }";
        }

        if (baseClass == typeof(InputField) && property.Name == "onValueChange")
        {
            return @"
        public class OnValueChange : InputFieldAttribute<UnityEngine.UI.InputField.OnChangeEvent>
        {
            public OnValueChange(UnityEngine.UI.InputField.OnChangeEvent value): base(""onValueChange"", value) {}
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onValueChanged = this.GetValue();
            }
        }";
        }

        return $@"
        public class {ToPascalCase(property.Name)} : {baseClass.Name}Attribute<{TypeString(property.PropertyType)}>
        {{
            public {ToPascalCase(property.Name)}({TypeString(property.PropertyType)} value): base(""{property.Name}"", value) {{}}
            protected override void Apply({TypeString(baseClass)} component)
            {{
                component.{property.Name} = this.GetValue();
            }}
        }}";
    }

    private static string TextValueTemplate()
    {
        return @"
        public class Value : TextAttribute<System.String>
        {
            public Value(System.String value): base(""Value"", value) {}
            protected override void Apply(UnityEngine.UI.Text component)
            {
                component.text = this.GetValue();
            }
        }";
    }

    private static string ToPascalCase(string str)
    {
        var regex = new System.Text.RegularExpressions.Regex("(.)(.*)");
        return regex.Replace(str, s => $"{s.Groups[1].Value.ToUpper()}{s.Groups[2].Value}");
    }

    private static string TypeString(Type type)
    {
        if (type.IsGenericType)
        {
            var genericTypes = type.GetGenericArguments().Select(TypeString).Aggregate((acc, x) => acc + $", {x}");
            var regex = new System.Text.RegularExpressions.Regex("(.+)(`[0-9])(.*)");
            return regex.Replace(type.FullName.Replace('+', '.'), s => $"{s.Groups[1].Value}<{genericTypes}>");
        }

        return type.FullName.Replace('+', '.');
    }
}
