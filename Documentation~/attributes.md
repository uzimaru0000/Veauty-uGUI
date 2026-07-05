# Attribute System

[日本語](ja/attributes.md)

How uGUI attributes find and write to components, the auto-add whitelist, the silent no-op gotcha, and how to write custom attributes.

## `GuiAttributeBase<TComponent, TValue>`

Every uGUI attribute derives from:

```csharp
public abstract class GuiAttributeBase<T1, T2> : Attribute<UnityEngine.GameObject, T2>
    where T1 : UnityEngine.Component
{
    protected GuiAttributeBase(string key, T2 value);
    protected abstract void Apply(T1 component);          // implemented per attribute
    public override void Apply(UnityEngine.GameObject obj); // component lookup + dispatch
}
```

Application logic:

```
component = obj.GetComponent<T1>()
if component == null && T1 is whitelisted:  component = obj.AddComponent<T1>()
if component != null:                        Apply(component)
// else: nothing happens
```

## Auto-add whitelist

These component types are added automatically when missing (they are additive helpers that make sense on any node):

- `UnityEngine.UI.LayoutElement`
- `UnityEngine.UI.ContentSizeFitter`
- `UnityEngine.UI.AspectRatioFitter`
- `UnityEngine.CanvasGroup`
- `UnityEngine.UI.Shadow`
- `UnityEngine.UI.Outline`
- `UnityEngine.UI.PositionAsUV1`

So `V.Text("hi", preferredWidth: 100f)` works even though a Text node has no `LayoutElement` — the `LayoutElement.PreferredWidth` attribute adds one.

## GOTCHA: silent no-op for everything else

If the component is missing and **not** whitelisted, `Apply` silently does nothing — no exception, no warning, no log. Typical trap:

```csharp
// WRONG: an Image node has no Slider component -> attribute silently ignored
V.Image(extras: new IAttribute<GameObject>[] { new Slider.Value(0.5f) })

// RIGHT: put Slider attributes on a Slider widget
V.Slider(value: 0.5f)
```

Base-class attributes are fine on derived components (`Selectable.Interactable` works on Button/Toggle/Slider nodes, `Graphic.Color` works on Image/Text/RawImage nodes) because `GetComponent<Selectable>()` matches subclasses.

Also note the reverse direction: when an attribute disappears from the tree on a later render, its previously written component value is **not** reverted (only GameObject-level keys Active/Tag/Position/Rotation/Scale have reset handling in the renderer). Keep an attribute present as long as its value should hold.

## Attribute identity and diffing

`Attribute<T, U>` (core) implements equality as *key + value*. During diff:

- same key, equal value → skipped;
- same key, different value → re-applied;
- new key → applied;
- removed key → reset only if it is one of the GameObject-level keys above.

Duplicate keys in one attribute list: the **last** one wins (`Attributes<T>` builds a dictionary; `V` factory methods put `extras` last so they can override the generated defaults).

## How attribute classes are organized

Attributes are **nested classes of their widget**, one class per component property:

```
Slider.Value(0.5f)          -> slider.value = 0.5f
Graphic.Color(Color.red)    -> graphic.color = red
Text.FontSize(24)           -> text.fontSize = 24
Button.OnClick(action)      -> onClick.RemoveAllListeners(); AddListener(action)
```

Per widget `Xxx` there is also an abstract base `XxxAttribute<T> : GuiAttributeBase<UnityEngine.UI.Xxx, T>` — subclass it to add custom attributes that target the same component.

Special cases:

- `Text.Value` — generated extra attribute for `Text.text` (the property name `text` collides with conventions, so it is named `Value` with key `"Value"`).
- `Button.OnClick` — clears all listeners before adding, so re-renders don't stack handlers.
- Generated `OnValueChanged`-style attributes (Slider, Toggle via extras, InputField, ScrollRect, Scrollbar, Dropdown) assign the whole UnityEvent object: `component.onValueChanged = GetValue()`.

## Layout aliases (`LayoutAliases.cs`)

The code generator emits attribute classes only for properties *declared* on each type. `HorizontalLayoutGroup`, `VerticalLayoutGroup`, and `GridLayoutGroup` declare none — their properties are inherited. `LayoutAliases.cs` fills the gap with hand-written aliases so call sites read naturally:

| Widget | Aliases |
|---|---|
| `HorizontalLayoutGroup` / `VerticalLayoutGroup` | `Padding`, `ChildAlignment` (from `LayoutGroup`), `Spacing`, `ChildForceExpandWidth/Height`, `ChildControlWidth/Height`, `ChildScaleWidth/Height`, `ReverseArrangement` (from `HorizontalOrVerticalLayoutGroup`) |
| `GridLayoutGroup` | `Padding`, `ChildAlignment` (from `LayoutGroup`) |

Each alias just subclasses the base attribute (`VerticalLayoutGroup.Spacing : HorizontalOrVerticalLayoutGroup.Spacing`), so it targets the inherited component property through the base class's `GetComponent`.

## Writing a custom attribute

Target an existing widget's component:

```csharp
// inside your code; targets UnityEngine.UI.Image via the generated base
public class FillAmountPulse : Veauty.uGUI.ImageAttribute<float>
{
    public FillAmountPulse(float value) : base("fillAmountPulse", value) { }
    protected override void Apply(UnityEngine.UI.Image image)
    {
        image.fillAmount = Mathf.PingPong(GetValue(), 1f);
    }
}
```

Target an arbitrary component:

```csharp
public class MyShadowColor : Veauty.uGUI.GuiAttributeBase<UnityEngine.UI.Shadow, Color>
{
    public MyShadowColor(Color value) : base("myShadowColor", value) { }
    protected override void Apply(UnityEngine.UI.Shadow s) => s.effectColor = GetValue();
}
```

Rules:

1. Pick a **unique key** per logical property — attributes with the same key overwrite each other on one node.
2. `Apply` must be idempotent: it re-runs whenever the value changes.
3. Remember the silent no-op: if your `TComponent` may be missing and is not whitelisted, ensure the widget guarantees it (e.g. in `Init`).
4. For capture-only behavior implement `IAttribute<GameObject>` directly (see `Ref<T>` in [Widget catalog](widgets.md)).
