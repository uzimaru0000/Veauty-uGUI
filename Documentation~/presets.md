# Presets API (`Veauty.uGUI.Presets`)

[日本語](ja/presets.md)

The convenience layer: the static `V` factory, the `Element` builder with indexer syntax, and the sub-component auto-injection rules.

```csharp
using Veauty.uGUI.Presets;
```

## The `Element` builder

Most `V` methods return an `Element` — a deferred widget factory (`IVTreeWrapper`), not a finished tree.

```csharp
// 1. Indexer: supply children, get the tree
IVTree a = V.Button(onClick: Click)[ V.Text("OK") ];

// 2. Direct use: an Element itself is a valid IVTree (childless widget)
IVTree b = V.Slider(value: 0.5f);
```

### Caching subtlety

- **Indexer path is NOT cached** — `element[children]` invokes the factory every call.
- **`Unwrap()` IS cached** — the first childless build is stored and every later call (including `GetNodeType()` / `GetDescendantsCount()`, which delegate to `Unwrap()`) returns the *same* `IVTree` instance.

Practical rule: treat an `Element` as single-use. Build a fresh one in every render; don't stash one in a field and reuse it across renders expecting fresh nodes.

## `V` factory methods

All optional parameters follow the same principle: **only parameters you pass become attributes** (except the forced layout defaults below). Every method also takes `extras` (`IAttribute<GameObject>[]`) appended after the generated attributes — since later attributes with the same key win, extras can override the generated ones.

### Function components

| Method | Notes |
|---|---|
| `V.Component(FunctionComponent)` | wraps a hook-capable function component |
| `V.Component(string key, FunctionComponent)` | with explicit identity key |
| `V.Component<TProps>(FunctionComponent<TProps>, TProps)` | with props |
| `V.Component<TProps>(string key, FunctionComponent<TProps>, TProps)` | props + key |
| `V.KeyedComponent(string key, FunctionComponent)` | keyed node for list diffing |
| `V.KeyedComponent<TProps>(string key, FunctionComponent<TProps>, TProps)` | keyed + props |

### Simple widgets

| Method | Parameters (all optional unless noted) | Auto-filled defaults |
|---|---|---|
| `V.Text(value, ...)` → `IVTree` | `value` (required), `fontSize`, `color`, `alignment`, `fontStyle`, `preferredWidth/Height`, `flexibleWidth/Height`, `params extras` | built-in font via `Text.Init` |
| `V.Button(...)` → `Element` | `onClick`, `color`, `preferredWidth/Height`, `flexibleWidth/Height`, `extras` | `Image` as `targetGraphic` via `Button.Init` |
| `V.Image(...)` → `Element` | `color`, `preferredWidth/Height`, `flexibleWidth/Height`, `extras` | — |
| `V.RawImage(...)` → `Element` | `texture`, `uvRect`, `color`, `extras` | — |
| `V.Selectable(...)` → `Element` | `interactable`, `transition`, `colors`, `navigation`, `extras` | — |
| `V.Mask(...)` → `Element` | `showMaskGraphic`, `extras` | — |
| `V.RectMask2D(...)` → `Element` | `padding`, `softness`, `extras` | — |
| `V.ToggleGroup(...)` → `Element` | `allowSwitchOff`, `extras` | — |
| `V.Dropdown(...)` → `Element` | `value`, `options`, `alphaFadeSpeed`, `extras` | full internal template via `Dropdown.Init` |
| `V.ScrollRect(...)` → `Element` | `horizontal`, `vertical`, `movementType`, `elasticity`, `inertia`, `decelerationRate`, `scrollSensitivity`, `extras` | `Image`+`RectMask2D` via `Init`; first child wired as `content` |

Note: `V.Text` is the only method returning a plain `IVTree` (Text takes no children); it takes `params IAttribute<GameObject>[] extras` rather than an array parameter.

### Layout widgets — forced defaults

| Method | Always applied | Optional |
|---|---|---|
| `V.VLayout(...)` | `Spacing` (param or **0**), `ChildControlWidth = true`, `ChildControlHeight = true`, `ChildForceExpandHeight = false` | `padding`, `childAlignment`, `extras` |
| `V.HLayout(...)` | `Spacing` (param or **0**), `ChildControlWidth = true`, `ChildControlHeight = true`, `ChildForceExpandWidth = false` | `padding`, `childAlignment`, `extras` |
| `V.Grid(...)` | *(nothing forced)* | `cellSize`, `spacing`, `padding`, `childAlignment`, `extras` |

To undo a forced default, pass the same attribute in `extras` — e.g. `V.VLayout(extras: new IAttribute<GameObject>[] { new VerticalLayoutGroup.ChildForceExpandHeight(true) })`.

### Composite widgets — sub-component auto-injection

`V.Toggle`, `V.Slider`, `V.Scrollbar`, `V.InputField` scan the children you pass through the indexer:

1. children implementing `ISubComponent` are collected as parts; others are content;
2. any *missing* required part is appended with its default configuration;
3. final kid order = sub-components first, then content children.

| Method | Own parameters | Auto-injected parts (when absent) |
|---|---|---|
| `V.Toggle(...)` | `isOn`, `color`, `interactable`, `extras` | `Toggle.ToggleBackground`, `Toggle.ToggleCheckmark` |
| `V.Slider(...)` | `value`, `minValue`, `maxValue`, `wholeNumbers`, `direction`, `interactable`, `extras` | `Slider.SliderBackground`, `Slider.SliderFill`, `Slider.SliderHandle` |
| `V.Scrollbar(...)` | `value`, `size`, `numberOfSteps`, `direction`, `extras` | `Scrollbar.ScrollbarHandlePart` |
| `V.InputField(...)` | `text`, `contentType`, `lineType`, `characterLimit`, `readOnly`, `color`, `extras` | `InputField.InputFieldPlaceholderPart`, `InputField.InputFieldTextPart` |

```csharp
V.Slider(value: 0.5f)                                    // all three parts defaulted
V.Slider(value: 0.5f)[ Slider.Fill(color: Color.red) ]   // custom fill, default bg/handle
V.Toggle(isOn: true)[ V.Text("Enable") ]                 // default bg/checkmark + label content
```

Default part colors and geometry are listed in [Sub-components](sub-components.md). Note that in `V.Slider`, `value` is applied *after* `minValue`/`maxValue`/`direction`, and in `V.Scrollbar`, `value` is applied last, so the value is clamped against the final range.

## When to drop to the base API

Use `using Veauty.uGUI;` directly when you want:

- no auto-injected parts (a Slider with *no* background at all, for example — base API only creates the parts you pass);
- explicit control over every attribute;
- to build custom widgets (subclass `GUIBase<T>`).

See [Widget catalog](widgets.md) and [Sub-components](sub-components.md).
