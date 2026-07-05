# Veauty-uGUI — Agent Guide

Widgets and typed attributes for building Unity uGUI declaratively with Veauty (Virtual DOM for Unity). This package maps every public `UnityEngine.UI` component to a `GUIBase<T>` VTree widget with nested attribute classes, adds composition sub-components for composite controls (Slider, Toggle, Scrollbar, InputField), and ships a `V` factory (`Veauty.uGUI.Presets`) with auto-filled defaults. Depends on `com.uzimaru.veauty` (core) and `com.uzimaru.veauty-gameobject` (renderer).

## Package map

| Path | Role |
|---|---|
| `Lib/GUIBase.cs` | `GUIBase<T>` widget base, `GuiAttributeBase<T1,T2>` attribute base, `ISubComponent`, `ImageStyle` |
| `Lib/V.cs` | `V` static factory (Presets namespace) |
| `Lib/Element.cs` | `Element` deferred builder with `[...]` indexer (Presets namespace) |
| `Lib/Ref.cs` | `Ref<T>` capture attribute + global-namespace alias |
| `Lib/Canvas.cs`, `Lib/CanvasGroup.cs`, `Lib/RectTransform.cs` | hand-written widgets (in the generator's skip list) |
| `Lib/LayoutAliases.cs` | inherited attribute aliases for `H/V/GridLayoutGroup` |
| `Lib/Generated/*.cs` | AUTO-GENERATED widgets — never hand-edit |
| `Lib/Initializers/*.Init.cs` | hand-written partial parts: `Init`/`AfterRenderKids`/`GetKids`, sub-component classes |
| `Lib/Editor/UIClass.cs` | code generator behind **Veauty > GenerateUIClass** |
| `Tests/Editor`, `Tests/Runtime` | NUnit tests (`Veauty.uGUI.Editor.Test`, `Veauty.uGUI.Runtime.Test`) |
| `Documentation~/` | manual (`com.uzimaru.veauty-ugui.md` entry) |

## Public API surface

```csharp
using Veauty;                // IVTree, IAttribute<T>, Hooks
using Veauty.GameObject;     // VeautyObject (mount point, from dependency)
using Veauty.uGUI;           // base API: widgets, attributes, sub-components, Ref<T>
using Veauty.uGUI.Presets;   // V factory, Element
```

- `Veauty.uGUI.Presets.V` — `V.Text/Button/Image/RawImage/VLayout/HLayout/Grid/Toggle/ToggleGroup/Slider/Scrollbar/ScrollRect/InputField/Dropdown/Selectable/Mask/RectMask2D/Component/KeyedComponent`
- `Veauty.uGUI.Presets.Element` — `element[child1, child2]` builds the tree
- `Veauty.uGUI.<Widget>` — one class per uGUI component (`Button`, `Text`, `Image`, `Slider`, ... 31 generated + `Canvas`, `CanvasGroup`, `RectTransform`)
- `Veauty.uGUI.<Widget>.<Attribute>` — nested attribute classes (`Slider.Value`, `Graphic.Color`, `Text.FontSize`, `Button.OnClick`, ...)
- `Veauty.uGUI.GUIBase<T>` / `GuiAttributeBase<TComponent,TValue>` — extension points
- `Veauty.uGUI.Ref<T>` (also global `Ref<T>`) — captures the rendered GameObject

## Usage rules

1. Mount with `new VeautyObject(gameObject, renderFunc)` on a GameObject **under a Canvas**; the scene must already contain Canvas + GraphicRaycaster + EventSystem — this package never creates them.
2. Supply children to an `Element` with the indexer: `V.Button(...)[ V.Text("OK") ]`. A childless `Element` may be used directly as an `IVTree`.
3. Treat `Element` as single-use per render: `Unwrap()` caches the childless build, so a stored `Element` returns the same node instance forever.
4. Put attributes only on widgets whose component matches (or is a base class of) the attribute's target component; otherwise the attribute is a **silent no-op** (exception: the auto-add whitelist `LayoutElement`, `ContentSizeFitter`, `AspectRatioFitter`, `CanvasGroup`, `Shadow`, `Outline`, `PositionAsUV1`).
5. Sub-components are mandatory in the base API (`new Slider(attrs)` renders no visuals) and auto-injected in the Presets API (`V.Slider()` gets Background/Fill/Handle defaults).
6. Never hand-edit `Lib/Generated/` — change `Lib/Editor/UIClass.cs` and re-run **Veauty > GenerateUIClass** instead.
7. Create internal (non-VTree) children only inside `Init`, never in `AfterRenderKids` — the patcher maps virtual children by `childOffset = childCount - kids.Length`, assuming internal children come first.
8. Do not instantiate abstract-component widgets (`Graphic`, `Selectable`, `LayoutGroup`, `MaskableGraphic`, `HorizontalOrVerticalLayoutGroup`, `BaseMeshEffect`) as nodes; use their nested attributes on concrete widgets.
9. Keep an attribute in the tree for as long as its value should hold — removing it does not revert the component property.
10. `[Component]`-annotated function components and Hooks come from the core package; use `V.KeyedComponent(key, ...)` for list items.

## Common patterns

Mount:

```csharp
public class Panel : MonoBehaviour
{
    private VeautyObject app;
    void Start() => app = new VeautyObject(gameObject, Render);
    static IVTree Render() => V.Text("hello");
}
```

State + button:

```csharp
static IVTree Render()
{
    var count = Hooks.UseState(0);
    return V.VLayout(spacing: 8f)[
        V.Text($"Count: {count.Value}", fontSize: 24),
        V.Button(onClick: () => count.Set(x => x + 1))[ V.Text("+1") ]
    ];
}
```

List rendering with keys:

```csharp
V.VLayout()[
    items.Select(item =>
        V.KeyedComponent(item.Id, () => ItemRow(item))).ToArray()
]
```

Composite control, one part customized:

```csharp
V.Slider(value: 0.5f)[ Slider.Fill(color: Color.red) ]   // default bg/handle injected
```

Attribute override via extras (later same-key attributes win):

```csharp
V.VLayout(extras: new IAttribute<GameObject>[] {
    new VerticalLayoutGroup.ChildForceExpandHeight(true)   // undo the forced default
})
```

Capture the rendered GameObject:

```csharp
var r = new Ref<GameObject>();
V.Image(extras: new IAttribute<GameObject>[] { r });
// after render: r.current
```

## Pitfalls

- **Silent no-op attributes.** Wrong: `V.Image(extras: ...{ new Slider.Value(0.5f) })` — Image has no Slider, nothing happens, no log. Right: put the attribute on the matching widget (`V.Slider(value: 0.5f)`); base-class attributes (`Selectable.Interactable`, `Graphic.Color`) do work on derived components.
- **No scene bootstrap.** Wrong: mounting on a bare GameObject and expecting UI to show/click. Right: ensure Canvas + GraphicRaycaster + EventSystem exist first; mount object needs a RectTransform for uGUI mode.
- **Element caching.** Wrong: `field = V.Button(...)` once, `field[...]`/`field` reused across renders — `Unwrap()` returns the same cached node. Right: call `V.Xxx(...)` inside the render function each time.
- **Hardcoded sub-component defaults.** `V.Slider()`/`V.Toggle()`/etc. inject parts with fixed colors (e.g. SliderFill RGB 0.22/0.55/0.95, ToggleCheckmark RGB 0.2/0.75/0.4) and fixed geometry; pass your own part (e.g. `Slider.Fill(color: ...)`) to change them. Changing part config on re-render does NOT restyle already-built internals (consumed once at `Init`).
- **Removed attribute ≠ reset.** Only GameObject-level keys (Active/Tag/Position/Rotation/Scale) reset when an attribute disappears; component values persist.
- **Layout group attributes.** `VerticalLayoutGroup` etc. declare no own properties; use the aliases from `LayoutAliases.cs` (`VerticalLayoutGroup.Spacing`, `.Padding`, ...) or the `HorizontalOrVerticalLayoutGroup`/`LayoutGroup` attributes.
- **`V.VLayout`/`V.HLayout` force layout flags** (`ChildControlWidth/Height=true`, `ChildForceExpand*=false`); override via `extras`, not by editing V.cs.
- **Sub-components are not nodes.** They implement `IVTree` but are filtered out by `GetKids()`; don't expect them to diff/patch or accept attributes.

## Extending

- **New attribute for an existing widget**: subclass the widget's abstract base, e.g. `class MyAttr : Veauty.uGUI.ImageAttribute<float> { public MyAttr(float v) : base("myAttr", v) {} protected override void Apply(UnityEngine.UI.Image c) { ... } }`. Unique key required; `Apply` must be idempotent.
- **New widget for a custom component**: `class MyWidget : GUIBase<MyComponent>`, override `Init`/`AfterRenderKids`/`Destroy` as needed; use `CreateChild`/`AddVisual`/`Stretch`/`SetupRect` helpers.
- **New sub-component**: nested `class MyPart : IVTree, ISubComponent` (return `VTreeType.Node`, count 0) + static factory + `GetKids()` override filtering `ISubComponent` (cache it) + read via `FindPart<MyPart>()` in `Init`.
- **Generator changes**: edit `Lib/Editor/UIClass.cs`, then run **Veauty > GenerateUIClass** in the Unity Editor. To hand-write a type instead, add it to `ManualTypes`.
- **Lifecycle for a generated widget**: add a `partial class` file under `Lib/Initializers/` — never edit `Lib/Generated/`.

## Build & test

Requires a running Unity Editor with uloop:

```bash
# compile
npx --yes uloop-cli@2.2.0 compile --force-recompile true --wait-for-domain-reload true

# this package's tests
npx --yes uloop-cli@2.2.0 run-tests --test-mode EditMode   # Veauty.uGUI.Editor.Test
npx --yes uloop-cli@2.2.0 run-tests --test-mode PlayMode   # Veauty.uGUI.Runtime.Test
```

Regenerate widgets from the Editor menu **Veauty > GenerateUIClass** after changing `UIClass.cs` or upgrading Unity.
