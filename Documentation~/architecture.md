# Architecture

[日本語](ja/architecture.md)

How Veauty-uGUI turns a virtual tree into live uGUI GameObjects, and how updates are patched in place.

## Layer stack

```
+--------------------------------------------------+
| Your code:  V.VLayout(...)[ V.Button(...)[...] ] |   Veauty.uGUI.Presets
+--------------------------------------------------+
| Widgets:    GUIBase<T> nodes + attribute classes |   Veauty.uGUI  (this package)
+--------------------------------------------------+
| Renderer / Patch / VeautyObject / HostBridge     |   Veauty.GameObject
+--------------------------------------------------+
| IVTree, Diff, Hooks, FunctionComponents          |   Veauty (core)
+--------------------------------------------------+
```

This package contributes only the top two rows: **widget node types** and **attributes**. Rendering, diffing, and patching live in the dependency packages.

## What a widget is

Every widget (e.g. `Button`, `Slider`, `VerticalLayoutGroup`) is a `GUIBase<T>`:

- a `Node<GameObject, T>` whose **tag** is `typeof(T).FullName` — so the diff treats two widgets of different component types as different tags and replaces the subtree;
- an `IHostLifecycle<GameObject>` with three hooks: `Init`, `AfterRenderKids`, `Destroy`.

## Render cycle of one widget node

```
Renderer.Render(tree)
  |
  v
[GameObjectHostBridge.Mount]
  1. CreateGameObject(tag)          -- + stretched RectTransform in uGUI mode
  2. AttachComponent(typeof(T))     -- e.g. UnityEngine.UI.Slider
  3. widget.Init(go)                -- build INTERNAL children (Background, Fill, Handle...)
  4. ApplyProps(attrs)              -- each IAttribute<GameObject>.Apply(go)
  |
  v
RenderKids(go, widget.GetKids())    -- render CONTENT children (sub-components filtered out)
  |
  v
widget.AfterRenderKids(go)          -- e.g. ScrollRect wires content = first child
```

On unmount, `Destroy` is called on the widget and (recursively, in reverse order) on its children.

## Content children vs internal children

A composite widget's GameObject has two kinds of children:

- **Internal children** created by `Init` (Slider's "Background", "Fill Area", "Handle Slide Area"; InputField's "Text Area"; Dropdown's whole template). These are *invisible to the VTree*.
- **Content children** rendered from `GetKids()` (what you put inside `[...]`).

Because `Init` runs *before* `RenderKids`, internal children always come first in `transform`. The patcher exploits this ordering:

```
childOffset = go.transform.childCount - kids.Length
virtual child i  <->  transform.GetChild(childOffset + i)
```

This is why:

1. `GetKids()` on Slider/Toggle/Scrollbar/InputField filters out `ISubComponent` entries (they are configuration, not children) and caches the result;
2. `GetDescendantsCount()` on `GUIBase<T>` counts only `GetKids()` so diff traversal indices stay consistent;
3. internal children must never be added after content children — only in `Init`.

## Attribute application

Attributes are keyed values (`GuiAttributeBase<TComponent, TValue>`). On apply:

```
component = go.GetComponent<TComponent>()
if component == null and TComponent in whitelist:  component = go.AddComponent<TComponent>()
if component != null:                              Apply(component)
else:                                              (silently nothing)
```

The whitelist is: `LayoutElement`, `ContentSizeFitter`, `AspectRatioFitter`, `CanvasGroup`, `Shadow`, `Outline`, `PositionAsUV1`. Details and gotchas in [Attribute system](attributes.md).

On diff, two attributes are equal when key **and** value are equal (`Attribute<T,U>.Equals`); only changed attributes are re-applied. An attribute present in the old tree but absent in the new one is *reset only for a fixed set of GameObject-level keys* (Active, Tag, Position, Rotation, Scale) — component values written by uGUI attributes are **not** automatically reverted; keep an attribute in the tree for as long as its value should hold.

## Update cycle

```
state change (Hooks / setState)
  -> render function runs        -> new IVTree
  -> Diff.Calc(oldTree, newTree) -> IPatch[]
  -> Patch.Apply(root, patches)  -> minimal GameObject mutations
```

`VeautyObject` coalesces re-entrant updates: state changes during a render set a flag and one re-render runs afterwards.

## Presets layer

`V.Xxx(...)` methods build attribute arrays from optional parameters and return an `Element` — a deferred factory implementing `IVTreeWrapper`. The renderer unwraps Elements transparently:

- `element[child1, child2]` → factory invoked with children (invoked anew each time, not cached);
- `element` used directly as `IVTree` → `Unwrap()` invoked with zero children (result **cached** per Element instance).

See [Presets API](presets.md).

## File layout

```
Lib/
  GUIBase.cs             GUIBase<T>, ISubComponent, ImageStyle, GuiAttributeBase
  Element.cs, V.cs       Veauty.uGUI.Presets namespace
  Canvas.cs, CanvasGroup.cs, RectTransform.cs   hand-written widgets
  Ref.cs                 Ref<T> capture attribute (+ global-namespace alias)
  LayoutAliases.cs       inherited attribute aliases for partial layout groups
  Generated/             auto-generated widgets (do not edit)
  Initializers/          hand-written Init/AfterRenderKids + sub-component types
  Editor/UIClass.cs      code generator (Veauty > GenerateUIClass)
```
