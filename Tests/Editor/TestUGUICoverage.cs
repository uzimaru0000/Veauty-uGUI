using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Veauty.uGUI.Tests
{
    public class TestUGUICoverage
    {
        private static readonly Type[] ExtraTypes =
        {
            typeof(Canvas),
            typeof(CanvasGroup),
            typeof(RectTransform)
        };

        private static IEnumerable<Type> GetTargetTypes()
        {
            var uiAssembly = Assembly.GetAssembly(typeof(Button));
            var uiTypes = uiAssembly.GetTypes()
                .Where(t => t.Namespace == "UnityEngine.UI")
                .Where(t => t.IsSubclassOf(typeof(MonoBehaviour)))
                .Where(t => t.IsVisible);

            return uiTypes
                .Concat(ExtraTypes)
                .Distinct()
                .OrderBy(t => t.Name);
        }

        private static IEnumerable<PropertyInfo> GetWritableProperties(Type type)
        {
            return type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.SetMethod != null && p.SetMethod.IsPublic)
                .Where(p => p.GetIndexParameters().Length == 0)
                .Where(p => !IsObsolete(p));
        }

        private static bool IsObsolete(PropertyInfo property)
        {
            return property.GetCustomAttribute<ObsoleteAttribute>() != null
                || property.GetMethod?.GetCustomAttribute<ObsoleteAttribute>() != null
                || property.SetMethod?.GetCustomAttribute<ObsoleteAttribute>() != null;
        }

        private static string ToPascalCase(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        private static Assembly GetVeautyUGUIAssembly()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .First(a => a.GetName().Name == "Veauty.uGUI");
        }

        [Test]
        public void AllUGUITypesHaveWrapperClass()
        {
            var veautyAssembly = GetVeautyUGUIAssembly();
            var veautyTypes = veautyAssembly.GetTypes()
                .Where(t => t.Namespace == "Veauty.uGUI" && !t.IsNested)
                .Select(t => t.Name)
                .ToHashSet();

            var missing = new List<string>();
            foreach (var unityType in GetTargetTypes())
            {
                if (!veautyTypes.Contains(unityType.Name))
                {
                    missing.Add(unityType.FullName);
                }
            }

            Assert.IsEmpty(missing,
                $"Missing Veauty wrapper classes for:\n  {string.Join("\n  ", missing)}");
        }

        [Test]
        public void AllWritablePropertiesHaveAttributeClass()
        {
            var veautyAssembly = GetVeautyUGUIAssembly();
            var missing = new List<string>();

            foreach (var unityType in GetTargetTypes())
            {
                var wrapperType = veautyAssembly.GetTypes()
                    .FirstOrDefault(t => t.Namespace == "Veauty.uGUI"
                                        && !t.IsNested
                                        && t.Name == unityType.Name);
                if (wrapperType == null) continue;

                var nestedNames = wrapperType.GetNestedTypes(BindingFlags.Public)
                    .Select(n => n.Name)
                    .ToHashSet();

                foreach (var prop in GetWritableProperties(unityType))
                {
                    var expected = ToPascalCase(prop.Name);
                    if (!nestedNames.Contains(expected))
                    {
                        missing.Add($"{unityType.Name}.{prop.Name} (expected nested class: {expected})");
                    }
                }
            }

            Assert.IsEmpty(missing,
                $"Missing Veauty attribute classes for:\n  {string.Join("\n  ", missing)}");
        }
    }
}
