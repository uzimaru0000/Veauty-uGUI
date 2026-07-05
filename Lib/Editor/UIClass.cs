using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Editor-only code generator behind the <b>Veauty &gt; GenerateUIClass</b> menu item. Reflects
/// over the public <c>UnityEngine.UI</c> component types and writes one widget file per type into
/// <c>Lib/Generated/</c>: a <c>partial</c> widget class deriving from <c>GUIBase&lt;T&gt;</c>, an
/// abstract <c>&lt;Name&gt;Attribute&lt;T&gt;</c> base, and one attribute class per public
/// writable, non-obsolete instance property.
/// </summary>
/// <remarks>
/// Types listed in <c>ManualTypes</c> (Canvas, CanvasGroup, RectTransform) are skipped — they are
/// hand-written in <c>Lib/</c>. Lifecycle code (<c>Init</c>/<c>AfterRenderKids</c>) is never
/// generated; it lives in hand-written partial classes under <c>Lib/Initializers/</c>.
/// The output depends on the Unity version's UI assembly, so regenerate after Unity upgrades.
/// </remarks>
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
    /// <summary>Base class for <see cref=""{uGUIType.Name}""/> attributes, targeting <see cref=""{TypeString(uGUIType)}""/>.</summary>
    /// <typeparam name=""T"">The attribute value type.</typeparam>
    public abstract class {uGUIType.Name}Attribute<T> : GuiAttributeBase<{TypeString(uGUIType)}, T>
    {{
        /// <summary>Creates the attribute with its diff key and value.</summary>
        /// <param name=""key"">The attribute key.</param>
        /// <param name=""value"">The value to apply.</param>
        protected {uGUIType.Name}Attribute(string key, T value) : base(key, value) {{ }}
    }}

    /// <summary>Veauty widget for <see cref=""{TypeString(uGUIType)}""/>.</summary>
    public partial class {uGUIType.Name} : GUIBase<{TypeString(uGUIType)}>
    {{
        /// <summary>Creates the widget node.</summary>
        /// <param name=""attrs"">Attributes applied to the rendered GameObject.</param>
        /// <param name=""kids"">VTree children.</param>
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
        /// <summary>Sets the click handler: removes all existing listeners from <see cref=""UnityEngine.UI.Button.onClick""/> and adds the given one.</summary>
        public class OnClick : ButtonAttribute<UnityEngine.Events.UnityAction>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name=""value"">The listener invoked on click.</param>
            public OnClick(UnityEngine.Events.UnityAction value): base(""onClick"", value) {}
            /// <inheritdoc />
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
        /// <summary>Sets <see cref=""UnityEngine.UI.InputField.onValueChanged""/> (replaces the whole event).</summary>
        public class OnValueChange : InputFieldAttribute<UnityEngine.UI.InputField.OnChangeEvent>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name=""value"">The event assigned to <c>onValueChanged</c>.</param>
            public OnValueChange(UnityEngine.UI.InputField.OnChangeEvent value): base(""onValueChange"", value) {}
            /// <inheritdoc />
            protected override void Apply(UnityEngine.UI.InputField component)
            {
                component.onValueChanged = this.GetValue();
            }
        }";
        }

        return $@"
        /// <summary>Sets <see cref=""{TypeString(baseClass)}.{property.Name}""/>.</summary>
        public class {ToPascalCase(property.Name)} : {baseClass.Name}Attribute<{TypeString(property.PropertyType)}>
        {{
            /// <summary>Creates the attribute.</summary>
            /// <param name=""value"">The value assigned to <c>{property.Name}</c>.</param>
            public {ToPascalCase(property.Name)}({TypeString(property.PropertyType)} value): base(""{property.Name}"", value) {{}}
            /// <inheritdoc />
            protected override void Apply({TypeString(baseClass)} component)
            {{
                component.{property.Name} = this.GetValue();
            }}
        }}";
    }

    private static string TextValueTemplate()
    {
        return @"
        /// <summary>Sets <see cref=""UnityEngine.UI.Text.text""/>.</summary>
        public class Value : TextAttribute<System.String>
        {
            /// <summary>Creates the attribute.</summary>
            /// <param name=""value"">The string assigned to <c>text</c>.</param>
            public Value(System.String value): base(""Value"", value) {}
            /// <inheritdoc />
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
