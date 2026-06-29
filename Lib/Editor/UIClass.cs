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

    public partial class {uGUIType.Name} : GUIBase<{TypeString(uGUIType)}>
    {{
        public {uGUIType.Name}(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids) : base(attrs, kids) {{ }}

{PropertyClassesTemplate(uGUIType, propertyTypes)}
    }}
}}";
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
