# Veauty-uGUI

[日本語](ja/com.uzimaru.veauty-ugui.md)

Widgets and attributes for building Unity uGUI declaratively with Veauty — a React-like Virtual DOM for Unity.

`com.uzimaru.veauty-ugui` is the uGUI binding layer of the Veauty family. It maps every public `UnityEngine.UI` component to a VTree widget class with typed attribute classes, adds composition-based sub-components for complex controls (Slider, Toggle, Scrollbar, InputField), and ships a convenience `V` factory with sensible defaults.

## Requirements

- Unity 6000.5 or later (Unity 6)
- [`com.uzimaru.veauty`](https://github.com/uzimaru0000/Veauty) — core VTree / diff / patch
- [`com.uzimaru.veauty-gameobject`](https://github.com/uzimaru0000/Veauty-GameObject) — GameObject renderer and `VeautyObject` mount point

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

## Quick start

```csharp
using UnityEngine;
using Veauty;
using Veauty.GameObject;
using Veauty.uGUI.Presets;

public class HelloPanel : MonoBehaviour
{
    private VeautyObject app;

    void Start() => this.app = new VeautyObject(this.gameObject, Render);

    static IVTree Render()
    {
        var count = Hooks.UseState(0);
        return V.VLayout(spacing: 12f)[
            V.Text($"Count: {count.Value}", fontSize: 32, color: Color.white),
            V.Button(onClick: () => count.Set(x => x + 1))[
                V.Text("Increment", fontSize: 24)
            ]
        ];
    }
}
```

Attach the script to a GameObject under a Canvas (with an EventSystem in the scene) and press Play.

## Two API levels

| Namespace | Level | Description |
|---|---|---|
| `Veauty.uGUI` | Base | Every widget/attribute explicit; sub-components mandatory for composite controls |
| `Veauty.uGUI.Presets` | Presets | `V` factory + `Element` indexer syntax; defaults and sub-components auto-filled |

## Manual

- [Getting started](getting-started.md) — install, minimal example, line-by-line walkthrough
- [Architecture](architecture.md) — render cycle, widget lifecycle, child-offset mechanism
- [Presets API](presets.md) — the `V` factory, `Element` builder, auto-injection rules
- [Widget catalog](widgets.md) — every widget (hand-written + generated), lifecycle hooks, `Ref<T>`
- [Sub-components](sub-components.md) — `ISubComponent` system, factory methods, default styles
- [Attribute system](attributes.md) — `GuiAttributeBase`, auto-add whitelist, silent no-op gotcha, custom attributes
- [Code generation](code-generation.md) — the `Veauty > GenerateUIClass` menu and the partial-class pattern
- [API reference](api-reference.md) — complete public API in one file

## Notes

uGUI requires a Canvas, GraphicRaycaster, and EventSystem in the scene. Veauty-uGUI does **not** create these automatically — set them up in the scene or in your bootstrap code.
