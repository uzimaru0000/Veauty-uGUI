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

Mount a Veauty tree under a Canvas GameObject using function components and hooks.

```csharp
using UnityEngine;
using Veauty;
using Veauty.GameObject;
using Veauty.uGUI;

public class CounterPanel : MonoBehaviour
{
    private VeautyObject app;

    private void Start()
    {
        this.app = new VeautyObject(this.gameObject, Render);
    }

    static IVTree Render()
    {
        var count = Hooks.UseState(0);
        return new Button(
            new IAttribute<GameObject>[] {
                new Button.OnClick(() => count.Set(x => x + 1))
            },
            new Text(new IAttribute<GameObject>[] {
                new Text.Value("Count " + count.Value),
                new Text.FontSize(32),
                new Graphic.Color(Color.white)
            })
        );
    }
}
```

## Runtime behavior

- uGUI elements are Veauty host nodes backed by Unity UI components.
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
- `AspectRatioFitter`
- `RectTransform`
- `Canvas`
- `CanvasGroup`
- `RaycastReceiver`

Most generated attributes map directly to the corresponding Unity UI component property.

Layout attributes can be written on the concrete layout group:

```csharp
new VerticalLayoutGroup(
    new IAttribute<GameObject>[] {
        new VerticalLayoutGroup.Padding(new RectOffset(16, 16, 12, 12)),
        new VerticalLayoutGroup.Spacing(8),
        new VerticalLayoutGroup.ChildAlignment(TextAnchor.UpperLeft),
        new VerticalLayoutGroup.ChildControlWidth(true),
        new VerticalLayoutGroup.ChildForceExpandHeight(false)
    },
    new Text(new IAttribute<GameObject>[] {
        new Text.Value("Hello"),
        new LayoutElement.PreferredHeight(32)
    })
)
```

These component attributes automatically add the backing component when they are applied to another uGUI node:

- `LayoutElement`
- `ContentSizeFitter`
- `AspectRatioFitter`
- `CanvasGroup`
- `Shadow`
- `Outline`
- `PositionAsUV1`

`RectTransform` attributes cover anchors, pivot, offsets, size, and anchored position:

```csharp
new Image(new IAttribute<GameObject>[] {
    new RectTransform.AnchorMin(new Vector2(0, 1)),
    new RectTransform.AnchorMax(new Vector2(0, 1)),
    new RectTransform.Pivot(new Vector2(0, 1)),
    new RectTransform.AnchoredPosition(new Vector2(24, -24)),
    new RectTransform.SizeDelta(new Vector2(120, 48))
})
```

`Canvas` and `CanvasGroup` live in `UnityEngine`, so qualify names when the compiler cannot choose between Unity and Veauty types:

```csharp
new Veauty.uGUI.Canvas(new IAttribute<GameObject>[] {
    new Veauty.uGUI.Canvas.RenderMode(RenderMode.ScreenSpaceOverlay),
    new Veauty.uGUI.Canvas.SortingOrder(10)
})
```

## Notes

uGUI components often require a Canvas, GraphicRaycaster, and EventSystem to be useful. Veauty-uGUI does not create those automatically; create them in the scene or in your own bootstrap code, then mount `VeautyObject<State>` under the Canvas.

I'm happy if you contribute!
