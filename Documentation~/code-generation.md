# Code Generation

[日本語](ja/code-generation.md)

The `Veauty > GenerateUIClass` editor menu, what it emits, and the partial-class pattern that separates generated from hand-written code.

## Running the generator

In the Unity Editor: **Veauty > GenerateUIClass** (implemented in `Lib/Editor/UIClass.cs`, assembly `Veauty.uGUI.Editor`). It overwrites all files in `Lib/Generated/` and refreshes the AssetDatabase. No manual adjustments are needed afterwards.

Because it reflects over the currently loaded `UnityEngine.UI` assembly, the output depends on the Unity version — regenerate after Unity upgrades.

## What it scans

1. All types in namespace `UnityEngine.UI` that are public, visible subclasses of `MonoBehaviour` (plus the `ExtraTypes` candidates `Canvas`, `CanvasGroup`, `RectTransform`);
2. minus the **ManualTypes skip list**: `Canvas`, `CanvasGroup`, `RectTransform` — these widgets are hand-written in `Lib/` (so with the current lists the extras contribute nothing; they document intent);
3. per type, all **declared** (not inherited), public, writable, non-obsolete, non-indexer instance properties, excluding properties whose PascalCase name equals the type name.

"Declared only" is why `Button` has one attribute (`OnClick`) and why layout groups need `LayoutAliases.cs` for their inherited properties.

## What it emits (per type, one file `Lib/Generated/<Name>.cs`)

```csharp
// THIS CODE IS AUTO GENERATED

/// <summary>Base class for <see cref="Xxx"/> attributes, ...</summary>
public abstract class XxxAttribute<T> : GuiAttributeBase<UnityEngine.UI.Xxx, T> { ... }

/// <summary>Veauty widget for <see cref="UnityEngine.UI.Xxx"/>.</summary>
public partial class Xxx : GUIBase<UnityEngine.UI.Xxx>
{
    public Xxx(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids)
        : base(attrs, kids) { }

    /// <summary>Sets <see cref="UnityEngine.UI.Xxx.propName"/>.</summary>
    public class PropName : XxxAttribute<PropType>
    {
        public PropName(PropType value) : base("propName", value) { }
        protected override void Apply(UnityEngine.UI.Xxx component)
        {
            component.propName = this.GetValue();
        }
    }
    // ... one class per property
}
```

XML doc comments (widget summary, attribute-base summary, per-property `Sets <see cref=.../>` summaries, constructor docs) are emitted by the generator itself.

Special-cased templates:

| Case | Emitted instead |
|---|---|
| `Button.onClick` | `OnClick` — `RemoveAllListeners()` then `AddListener(value)` |
| `InputField.onValueChange` | `OnValueChange` — assigns `onValueChanged` (legacy property name; only emitted on Unity versions that still declare `onValueChange`) |
| `Text` | extra `Value` attribute mapping to `Text.text` (inserted first) |

## The partial-class + Initializers pattern

Generated widget classes are `partial`. Anything that cannot be generated lives in hand-written partial parts that the generator never touches:

| Location | Contains |
|---|---|
| `Lib/Generated/*.cs` | constructor + attribute classes only (regenerated wholesale) |
| `Lib/Initializers/*.Init.cs` | `Init` / `AfterRenderKids` / `GetKids` overrides, sub-component classes, factory methods |
| `Lib/LayoutAliases.cs` | inherited-attribute aliases for the partial layout group types |

This split means regeneration is always safe: delete-and-recreate of `Lib/Generated/` loses nothing hand-written.

## Do not hand-edit `Lib/Generated/`

Any manual change there is lost on the next run. To customize behavior:

- lifecycle → add/extend a partial class in `Lib/Initializers/`;
- extra attributes → new classes in a hand-written partial part (subclass `XxxAttribute<T>`);
- exclude a type from generation → add it to `ManualTypes` and write it by hand in `Lib/`.
