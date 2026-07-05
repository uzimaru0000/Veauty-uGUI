# Veauty-uGUI

Widgets and attributes for building Unity uGUI declaratively with Veauty.

## Requirements

- Unity 6000.5 or later (Unity 6)
- `com.uzimaru.veauty`
- `com.uzimaru.veauty-gameobject`

## Install

Add to `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.uzimaru.veauty": "https://github.com/uzimaru0000/Veauty.git",
    "com.uzimaru.veauty-gameobject": "https://github.com/uzimaru0000/Veauty-GameObject.git",
    "com.uzimaru.veauty-ugui": "https://github.com/uzimaru0000/Veauty-uGUI.git"
  }
}
```

## Usage

Mount a `VeautyObject` under a Canvas GameObject to build uGUI.

```csharp
using UnityEngine;
using Veauty;
using Veauty.GameObject;
using Veauty.uGUI.Presets;

public class CounterPanel : MonoBehaviour
{
    private VeautyObject app;

    void Start()
    {
        this.app = new VeautyObject(this.gameObject, Render);
    }

    static IVTree Render()
    {
        var count = Hooks.UseState(0);
        return V.VLayout(spacing: 12f)[
            CountDisplay(count.Value),
            V.Button(onClick: () => count.Set(x => x + 1))[
                V.Text("Increment", fontSize: 24, color: Color.white)
            ]
        ];
    }

    [Component]
    static IVTree CountDisplay(int value)
    {
        Hooks.UseEffect(() =>
        {
            Debug.Log($"Count changed to {value}");
            return () => Debug.Log("CountDisplay unmounted");
        }, new object[] { value });

        return V.Text($"Count: {value}", fontSize: 32, color: Color.white);
    }
}
```

## Two API levels

### Presets API (`Veauty.uGUI.Presets`)

Factory methods on `V` create widgets with sensible defaults. Use `[]` indexer for children.

```csharp
using Veauty.uGUI.Presets;

V.VLayout(spacing: 8f, padding: new RectOffset(16, 16, 12, 12))[
    V.Text("Hello", fontSize: 24, color: Color.white),
    V.Image(color: Color.gray, preferredHeight: 2f),
    V.Button(onClick: () => { /* ... */ })[
        V.Text("Click me")
    ],
    V.Slider(value: 0.5f),
    V.Toggle(isOn: true)[
        V.Text("Enable")
    ]
]
```

### Base API (`Veauty.uGUI`)

Low-level API where every parameter is explicit. Sub-components (Slider handle, Toggle checkmark, etc.) are also specified explicitly.

```csharp
using Veauty.uGUI;

new Slider(attrs,
    Slider.Background(sprite: trackSprite),
    Slider.Fill(color: Color.red),
    Slider.Handle()
)
```

## Widget list

| Widget | Sub-components |
|--------|---------------|
| `Button` | - |
| `Text` | - |
| `Image` | - |
| `InputField` | `PlaceholderText()`, `TextDisplay()` |
| `Toggle` | `Background()`, `Checkmark()` |
| `Slider` | `Background()`, `Fill()`, `Handle()` |
| `Scrollbar` | `Handle()` |
| `ScrollRect` | - |
| `Dropdown` | - |
| `HorizontalLayoutGroup` | - |
| `VerticalLayoutGroup` | - |
| `GridLayoutGroup` | - |

## Auto-added component attributes

These attributes automatically add the backing component if it is missing on the target uGUI node:

`LayoutElement`, `ContentSizeFitter`, `AspectRatioFitter`, `CanvasGroup`, `Shadow`, `Outline`, `PositionAsUV1`

## RectTransform

```csharp
V.Image(extras: new IAttribute<GameObject>[] {
    new RectTransform.AnchorMin(Vector2.zero),
    new RectTransform.AnchorMax(Vector2.one),
    new RectTransform.OffsetMin(new Vector2(16f, 16f)),
    new RectTransform.OffsetMax(new Vector2(-16f, -16f))
})
```

## Documentation

- [Manual](Documentation~/com.uzimaru.veauty-ugui.md) — full manual (getting started, architecture, presets, widgets, sub-components, attributes, code generation)
- [API reference](Documentation~/api-reference.md) — complete public API
- [AGENTS.md](AGENTS.md) — guide for LLM coding agents
- [CHANGELOG.md](CHANGELOG.md) — version history

## Notes

uGUI requires a Canvas, GraphicRaycaster, and EventSystem in the scene. Veauty-uGUI does not create these automatically — set them up in the scene or in your bootstrap code.
