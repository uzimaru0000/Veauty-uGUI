# Veauty-uGUI

uGUI widgets and attributes for Veauty.

## Environment

- Unity 2020.3 or higher
- C# 7.0
- `com.unity.ugui`

## Install

Add Veauty, Veauty-GameObject, and Veauty-uGUI to `Packages/manifest.json`.

```json
{
  "dependencies": {
    "com.uzimaru.veauty": "https://github.com/uzimaru0000/Veauty.git",
    "com.uzimaru.veauty-gameobject": "https://github.com/uzimaru0000/Veauty-GameObject.git",
    "com.uzimaru.veauty-ugui": "https://github.com/uzimaru0000/Veauty-uGUI.git"
  }
}
```

## Example

Mount a Veauty tree under a Canvas GameObject.

```csharp
using UnityEngine;
using Veauty;
using Veauty.GameObject;
using Veauty.uGUI;

public struct CounterState
{
    public int Count;
}

public class CounterPanel : MonoBehaviour
{
    private VeautyObject<CounterState> app;

    private void Start()
    {
        this.app = new VeautyObject<CounterState>(
            this.gameObject,
            (state, setState) => new Button(
                new IAttribute<GameObject>[] {
                    new Button.OnClick(() => setState(new CounterState {
                        Count = state.Count + 1
                    }))
                },
                new Text(new IAttribute<GameObject>[] {
                    new Text.Value("Count " + state.Count),
                    new Text.FontSize(32),
                    new Graphic.Color(Color.white)
                })
            ),
            new CounterState { Count = 0 }
        );
    }
}
```

## Runtime behavior

- uGUI elements are Veauty widgets backed by Unity UI components.
- Rendering is delegated to Veauty-GameObject, so keyed child moves, redraws, and typed component replacement use the same patch semantics.
- When mounted under a `RectTransform`, rendered nodes receive `RectTransform` and are parented without keeping world transform.
- Event attributes such as `Button.OnClick` replace existing listeners when applied.
- `Ref<GameObject>` captures the rendered GameObject and can be used for wiring component references.

## Common widgets

- `Button`
- `Text`
- `Image`
- `InputField`
- `Toggle`
- `Slider`
- `Dropdown`
- `ScrollRect`
- `HorizontalLayoutGroup`
- `VerticalLayoutGroup`
- `GridLayoutGroup`
- `LayoutElement`
- `ContentSizeFitter`

Most generated attributes map directly to the corresponding Unity UI component property.

## Notes

uGUI components often require a Canvas, GraphicRaycaster, and EventSystem to be useful. Veauty-uGUI does not create those automatically; create them in the scene or in your own bootstrap code, then mount `VeautyObject<State>` under the Canvas.

I'm happy if you contribute!
