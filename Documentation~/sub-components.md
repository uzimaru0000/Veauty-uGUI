# Sub-Components

[日本語](ja/sub-components.md)

The `ISubComponent` system: how composite widgets (Slider, Toggle, Scrollbar, InputField) declare their internal parts.

## Concept

Controls like Slider need internal structure (track, fill, handle) that is *not* part of your UI tree. Veauty-uGUI models each part as a **sub-component**: a tiny immutable configuration object implementing both `IVTree` and the marker interface `ISubComponent`.

```csharp
public interface ISubComponent { }   // marker only
```

Sub-components:

- are passed as ordinary `kids` to the widget constructor;
- implement `IVTree` only so they fit in the kids array (`GetNodeType()` returns `Node`, `GetDescendantsCount()` returns 0); they **never render through the VTree pipeline**;
- are read in the widget's `Init` via `FindPart<T>()` (first match wins — passing two of the same part uses the first) and turned into internal GameObjects with `CreateChild`/`AddVisual`.

## The `GetKids()` filter and childOffset

Widgets with sub-components override `GetKids()`:

```csharp
public override IVTree[] GetKids()
{
    // returns kids where !(kid is ISubComponent), cached after first call
}
```

Consequences:

- diff/patch never sees sub-components (they are configuration, not nodes);
- `GetDescendantsCount()` counts content children only;
- the patcher maps virtual child *i* to `transform.GetChild(childOffset + i)` where `childOffset = childCount - kids.Length`, which skips the internal GameObjects `Init` created. This works because `Init` runs before any content child is rendered.

Changing a sub-component's configuration between renders does **not** patch the internal objects — sub-components are consumed once at `Init`. To restyle internal parts dynamically, key the widget so it remounts, or capture objects with `Ref<T>` and mutate them yourself.

## Catalog and hardcoded defaults

All image-style parts default to `imageType: Image.Type.Simple` and `sprite: null`.

### Slider (`Slider.Init.cs`)

| Part class | Factory | Default color | Created structure |
|---|---|---|---|
| `Slider.SliderBackground` | `Slider.Background(sprite, color, imageType)` | RGB (0.30, 0.32, 0.38) | "Background" image, stretched |
| `Slider.SliderFill` | `Slider.Fill(sprite, color, imageType)` | RGB (0.22, 0.55, 0.95) | "Fill Area" (anchors y 0.25–0.75, x-inset 5px) containing "Fill"; wired to `fillRect` |
| `Slider.SliderHandle` | `Slider.Handle(sprite, color, imageType)` | white | "Handle Slide Area" (x-inset 10px) containing 20px-wide "Handle"; wired to `handleRect` + `targetGraphic` |

### Toggle (`Toggle.Init.cs`)

| Part class | Factory | Default color | Created structure |
|---|---|---|---|
| `Toggle.ToggleBackground` | `Toggle.Background(sprite, color, imageType)` | RGB (0.22, 0.24, 0.28) | left-anchored 24px-wide "Background"; wired to `targetGraphic` |
| `Toggle.ToggleCheckmark` | `Toggle.Checkmark(sprite, color, imageType)` | RGB (0.2, 0.75, 0.4) | "Checkmark" inside Background (15% inset); wired to `graphic` |

Note: the checkmark is only created when a background part is also present (it nests inside it).

### Scrollbar (`Scrollbar.Init.cs`)

| Part class | Factory | Default color | Created structure |
|---|---|---|---|
| `Scrollbar.ScrollbarHandlePart` | `Scrollbar.Handle(sprite, color, imageType)` | RGB (0.5, 0.5, 0.5) | "Sliding Area" (stretched) containing "Handle"; wired to `handleRect` + `targetGraphic` |

`Scrollbar.Init` additionally adds a background `Image` (RGB 0.22, 0.24, 0.28) to the scrollbar itself when none exists — regardless of sub-components.

### InputField (`InputField.Init.cs`)

| Part class | Factory | Defaults | Created structure |
|---|---|---|---|
| `InputField.InputFieldPlaceholderPart` | `InputField.PlaceholderText(text, color, fontSize, alignment)` | text "Enter text...", RGBA (0.5, 0.5, 0.5, 0.75), size 16, MiddleLeft | italic "Placeholder" text; wired to `placeholder` |
| `InputField.InputFieldTextPart` | `InputField.TextDisplay(color, fontSize, alignment)` | white, size 16, MiddleLeft | "Text" (rich text off); wired to `textComponent` |

Both live inside a "Text Area" child (10px/2px insets) with `RectMask2D`. `InputField.Init` also adds a background `Image` (RGB 0.16, 0.18, 0.22) when none exists and wires it to `targetGraphic`. Both texts use the built-in `LegacyRuntime.ttf`.

## Base API vs Presets API

| | Base (`Veauty.uGUI`) | Presets (`Veauty.uGUI.Presets`) |
|---|---|---|
| Sub-components | **mandatory** — a part you don't pass is not created (e.g. `new Slider(attrs)` renders with no visuals at all) | **optional** — missing required parts are auto-injected with defaults |
| Customize one part | pass just that part plus the others explicitly | pass just that part; the rest is defaulted |

```csharp
// Base: everything explicit
using Veauty.uGUI;
new Slider(attrs,
    Slider.Background(sprite: trackSprite),
    Slider.Fill(color: Color.red),
    Slider.Handle());

// Presets: override only the fill
using Veauty.uGUI.Presets;
V.Slider(value: 0.5f)[ Slider.Fill(color: Color.red) ];
```

The auto-injection algorithm (scan children → add missing parts → parts before content) is described in [Presets API](presets.md).

## Adding a sub-component to your own widget

1. Define a nested `class MyPart : IVTree, ISubComponent` holding readonly config fields; return `VTreeType.Node` / 0 from the `IVTree` members.
2. Add a static factory (`public static IVTree Part(...) => new MyPart(...)`).
3. Override `GetKids()` to filter `ISubComponent` (cache the array).
4. In `Init`, call `FindPart<MyPart>()` and build the internal GameObjects with `CreateChild` / `AddVisual` / `Stretch` / `SetupRect`.
5. If needed, override `AfterRenderKids` for wiring that depends on content children.
