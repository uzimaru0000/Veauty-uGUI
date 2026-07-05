# Getting Started

[日本語](ja/getting-started.md)

Install Veauty-uGUI and build your first declarative uGUI panel.

## 1. Install

Add the three Veauty packages to `Packages/manifest.json` (Unity 6000.5+):

```json
{
  "dependencies": {
    "com.uzimaru.veauty": "https://github.com/uzimaru0000/Veauty.git",
    "com.uzimaru.veauty-gameobject": "https://github.com/uzimaru0000/Veauty-GameObject.git",
    "com.uzimaru.veauty-ugui": "https://github.com/uzimaru0000/Veauty-uGUI.git"
  }
}
```

## 2. Prepare the scene

Veauty-uGUI renders *into* an existing uGUI environment; it never creates one. You need:

1. A **Canvas** (with `CanvasScaler`/`GraphicRaycaster` as usual)
2. An **EventSystem** (for clicks, input, scrolling)
3. A **mount GameObject** under the Canvas — the panel Veauty will control. Its `RectTransform` puts the renderer into uGUI mode automatically.

## 3. Minimal working example

```csharp
using UnityEngine;
using Veauty;                 // IVTree, Hooks, IAttribute
using Veauty.GameObject;      // VeautyObject
using Veauty.uGUI.Presets;    // V, Element

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

        return V.VLayout(spacing: 12f, padding: new RectOffset(16, 16, 16, 16))[
            V.Text($"Count: {count.Value}", fontSize: 32, color: Color.white),
            V.Button(onClick: () => count.Set(x => x + 1), preferredHeight: 48f)[
                V.Text("Increment", fontSize: 24, color: Color.white)
            ],
            V.Slider(value: Mathf.Clamp01(count.Value / 10f), interactable: false)
        ];
    }
}
```

## 4. Line by line

- `new VeautyObject(this.gameObject, Render)` — mounts the render function under `this.gameObject`. Because the mount object has a `RectTransform`, every created GameObject also gets a stretched `RectTransform` (uGUI mode). The first render happens synchronously in the constructor.
- `Hooks.UseState(0)` — hook-based state from the core package. Calling `count.Set(...)` re-runs `Render`, diffs the new tree against the old one, and patches only what changed.
- `V.VLayout(spacing: 12f, ...)` — creates a `VerticalLayoutGroup` widget. `VLayout` always forces `ChildControlWidth/Height = true` and `ChildForceExpandHeight = false` so children size themselves naturally.
- `[...]` — the indexer on the returned `Element` supplies children and produces the final `IVTree`.
- `V.Button(onClick: ...)` — creates a `Button`; its `Init` adds an `Image` as `targetGraphic` if the node has no Graphic. The `OnClick` attribute removes all previous listeners before adding yours, so re-renders never stack handlers.
- `V.Text(...)` — creates a legacy `UnityEngine.UI.Text`; a default font (`LegacyRuntime.ttf`) is assigned automatically.
- `V.Slider(value: ...)` — because no sub-components are passed, default `Slider.Background()`, `Slider.Fill()`, and `Slider.Handle()` are injected automatically with built-in colors.

## 5. Customizing composite controls

Pass sub-components as children to override just one part:

```csharp
V.Slider(value: 0.5f)[
    Slider.Fill(color: Color.red)      // custom fill, default background/handle
]
```

or drop to the base API (`using Veauty.uGUI;`) where all sub-components are explicit:

```csharp
new Slider(attrs,
    Slider.Background(sprite: trackSprite),
    Slider.Fill(color: Color.red),
    Slider.Handle())
```

## Next steps

- [Presets API](presets.md) — everything `V` can do and what it auto-fills
- [Widget catalog](widgets.md) — the full widget list
- [Attribute system](attributes.md) — including the silent no-op gotcha
- [Architecture](architecture.md) — how rendering and patching work
