# API Reference

[日本語](ja/api-reference.md)

Complete public API of `com.uzimaru.veauty-ugui` (assemblies `Veauty.uGUI`, `Veauty.uGUI.Editor`), grouped by namespace. See [Widget catalog](widgets.md) and [Attribute system](attributes.md) for narrative documentation.

---

## Namespace `Veauty.uGUI` — core types

### `GUIBase<T>`

```csharp
public abstract class GUIBase<T> :
    Node<UnityEngine.GameObject, T>,
    IHostLifecycle<UnityEngine.GameObject>,
    IHostLifecycleTree<UnityEngine.GameObject>
    where T : UnityEngine.Component
```

Base class of every widget. Node tag = `typeof(T).FullName`.

| Member | Signature | Description |
|---|---|---|
| ctor | `protected GUIBase(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)` | attributes + children/sub-components |
| `Init` | `virtual GameObject Init(GameObject go)` | pre-attribute hook; build internal children here |
| `AfterRenderKids` | `virtual void AfterRenderKids(GameObject go)` | post-children hook |
| `Destroy` | `virtual void Destroy(GameObject go)` | unmount hook |
| `GetHostLifecycles` | `IHostLifecycle<GameObject>[] GetHostLifecycles()` | returns `{ this }` |
| `GetDescendantsCount` | `override int GetDescendantsCount()` | counts `GetKids()` view only |
| `CreateChild` | `protected static GameObject CreateChild(GameObject parent, string name)` | internal child + RectTransform |
| `Stretch` | `protected static void Stretch(RectTransform rt)` | anchors 0..1, sizeDelta 0 |
| `AddVisual<TComp>` | `protected static TComp AddVisual<TComp>(GameObject go, Color color) where TComp : Graphic` | CanvasRenderer + graphic |
| `SetupRect` | `protected static void SetupRect(RectTransform rt, Vector2? anchorMin = null, ..., Vector2? offsetMax = null)` | sets non-null properties only |
| `FindPart<T>` | `protected T FindPart<T>() where T : class` | first kid of type T (raw kids) |

Remarks: internal children must be created in `Init` only (child-offset rule, see [Architecture](architecture.md)).

### `GuiAttributeBase<T1, T2>`

```csharp
public abstract class GuiAttributeBase<T1, T2> : Attribute<UnityEngine.GameObject, T2>
    where T1 : UnityEngine.Component
```

| Member | Signature | Description |
|---|---|---|
| ctor | `protected GuiAttributeBase(string key, T2 value)` | key = diff identity |
| `Apply` (abstract) | `protected abstract void Apply(T1 component)` | write value to component |
| `Apply` (override) | `public override void Apply(GameObject obj)` | GetComponent, whitelist auto-add, dispatch |

Remarks: **silent no-op** when `T1` missing and not in whitelist (`LayoutElement`, `ContentSizeFitter`, `AspectRatioFitter`, `CanvasGroup`, `Shadow`, `Outline`, `PositionAsUV1`).

### `ISubComponent`

```csharp
public interface ISubComponent { }
```

Marker for widget part configurations; filtered out of `GetKids()`, consumed by `Init`. Never rendered.

### `ImageStyle`

```csharp
public struct ImageStyle
{
    public Sprite Sprite;          // applied only when non-null
    public Color Color;            // always applied
    public Image.Type ImageType;   // always applied
    public void ApplyTo(Image image);
}
```

### `Ref<T>`

```csharp
namespace Veauty.uGUI { public class Ref<T> : IAttribute<T> { ... } }
public class Ref<T> : Veauty.uGUI.Ref<T> { ... }   // global-namespace alias
```

| Member | Signature | Description |
|---|---|---|
| `current` | `public T current` | captured object (constructor default until applied) |
| ctor | `Ref(T defaultValue = default)` | |
| `GetKey` | `string GetKey()` | `"ref:" + GetHashCode()` — unique per instance |
| `Apply` | `void Apply(T obj)` | stores `obj` in `current` |

---

## Namespace `Veauty.uGUI` — hand-written widgets

### Canvas

Widget for `UnityEngine.Canvas`. Constructor: `new Canvas(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`. Abstract attribute base: `CanvasAttribute<T>`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Canvas.RenderMode` | `RenderMode` | `Canvas.renderMode` |
| `Canvas.WorldCamera` | `Camera` | `Canvas.worldCamera` |
| `Canvas.PlaneDistance` | `float` | `Canvas.planeDistance` |
| `Canvas.PixelPerfect` | `bool` | `Canvas.pixelPerfect` |
| `Canvas.ScaleFactor` | `float` | `Canvas.scaleFactor` |
| `Canvas.ReferencePixelsPerUnit` | `float` | `Canvas.referencePixelsPerUnit` |
| `Canvas.OverridePixelPerfect` | `bool` | `Canvas.overridePixelPerfect` |
| `Canvas.OverrideSorting` | `bool` | `Canvas.overrideSorting` |
| `Canvas.SortingOrder` | `int` | `Canvas.sortingOrder` |
| `Canvas.TargetDisplay` | `int` | `Canvas.targetDisplay` |
| `Canvas.SortingLayerID` | `int` | `Canvas.sortingLayerID` |
| `Canvas.SortingLayerName` | `string` | `Canvas.sortingLayerName` |
| `Canvas.AdditionalShaderChannels` | `AdditionalCanvasShaderChannels` | `Canvas.additionalShaderChannels` |
| `Canvas.NormalizedSortingGridSize` | `float` | `Canvas.normalizedSortingGridSize` |
| `Canvas.UseReflectionProbes` | `bool` | `Canvas.useReflectionProbes` |
| `Canvas.VertexColorAlwaysGammaSpace` | `bool` | `Canvas.vertexColorAlwaysGammaSpace` |
| `Canvas.UpdateRectTransformForStandalone` | `StandaloneRenderResize` | `Canvas.updateRectTransformForStandalone` |

### CanvasGroup

Widget for `UnityEngine.CanvasGroup`. Constructor as above. Abstract attribute base: `CanvasGroupAttribute<T>` (whitelisted: auto-adds the component).

| Attribute | Value type | Applies to |
|---|---|---|
| `CanvasGroup.Alpha` | `float` | `CanvasGroup.alpha` |
| `CanvasGroup.Interactable` | `bool` | `CanvasGroup.interactable` |
| `CanvasGroup.BlocksRaycasts` | `bool` | `CanvasGroup.blocksRaycasts` |
| `CanvasGroup.IgnoreParentGroups` | `bool` | `CanvasGroup.ignoreParentGroups` |

### RectTransform

Widget for `UnityEngine.RectTransform`. Constructor as above. Abstract attribute base: `RectTransformAttribute<T>`. Attributes usable on any uGUI widget (every node has a RectTransform).

| Attribute | Value type | Applies to |
|---|---|---|
| `RectTransform.AnchorMin` | `Vector2` | `RectTransform.anchorMin` |
| `RectTransform.AnchorMax` | `Vector2` | `RectTransform.anchorMax` |
| `RectTransform.AnchoredPosition` | `Vector2` | `RectTransform.anchoredPosition` |
| `RectTransform.AnchoredPosition3D` | `Vector3` | `RectTransform.anchoredPosition3D` |
| `RectTransform.SizeDelta` | `Vector2` | `RectTransform.sizeDelta` |
| `RectTransform.Pivot` | `Vector2` | `RectTransform.pivot` |
| `RectTransform.OffsetMin` | `Vector2` | `RectTransform.offsetMin` |
| `RectTransform.OffsetMax` | `Vector2` | `RectTransform.offsetMax` |
| `RectTransform.SendChildDimensionsChange` | `bool` | `RectTransform.sendChildDimensionsChange` |

---

## Namespace `Veauty.uGUI` — layout aliases (`LayoutAliases.cs`)

Hand-written subclasses of inherited attributes for the partial layout group widgets:

| Alias | Inherits |
|---|---|
| `HorizontalLayoutGroup.Padding` / `VerticalLayoutGroup.Padding` / `GridLayoutGroup.Padding` | `LayoutGroup.Padding` |
| `HorizontalLayoutGroup.ChildAlignment` / `VerticalLayoutGroup.ChildAlignment` / `GridLayoutGroup.ChildAlignment` | `LayoutGroup.ChildAlignment` |
| `HorizontalLayoutGroup.Spacing` / `VerticalLayoutGroup.Spacing` | `HorizontalOrVerticalLayoutGroup.Spacing` |
| `H/V...ChildForceExpandWidth`, `ChildForceExpandHeight`, `ChildControlWidth`, `ChildControlHeight`, `ChildScaleWidth`, `ChildScaleHeight`, `ReverseArrangement` | corresponding `HorizontalOrVerticalLayoutGroup.*` |

---

## Namespace `Veauty.uGUI` — sub-components (`Lib/Initializers/`)

All are `IVTree, ISubComponent` config carriers with readonly fields; `GetNodeType() => Node`, `GetDescendantsCount() => 0`. Defaults listed in [Sub-components](sub-components.md).

| Type | Factory method | Fields |
|---|---|---|
| `Slider.SliderBackground` | `Slider.Background(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `Slider.SliderFill` | `Slider.Fill(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `Slider.SliderHandle` | `Slider.Handle(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `Toggle.ToggleBackground` | `Toggle.Background(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `Toggle.ToggleCheckmark` | `Toggle.Checkmark(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `Scrollbar.ScrollbarHandlePart` | `Scrollbar.Handle(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `InputField.InputFieldPlaceholderPart` | `InputField.PlaceholderText(string, Color?, int?, TextAnchor?)` | `text`, `color`, `fontSize`, `alignment` |
| `InputField.InputFieldTextPart` | `InputField.TextDisplay(Color?, int?, TextAnchor?)` | `color`, `fontSize`, `alignment` |

Widgets with lifecycle overrides: `Button.Init` (targetGraphic), `Text.Init` (default font), `Slider/Toggle/Scrollbar/InputField` (`GetKids` filter + `Init` structure), `ScrollRect` (`Init` + `AfterRenderKids` content wiring), `Dropdown.Init` (full template).

---

## Namespace `Veauty.uGUI` — generated widgets (`Lib/Generated/`)

Per widget `Xxx`: `public partial class Xxx : GUIBase<UnityEngine.UI.Xxx>` with constructor `(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`, plus abstract `XxxAttribute<T> : GuiAttributeBase<UnityEngine.UI.Xxx, T>`. Attribute semantics: `component.<property> = value`, except `Button.OnClick` (`RemoveAllListeners` + `AddListener`) and `Text.Value` (`text` property).

### AspectRatioFitter

Widget for `UnityEngine.UI.AspectRatioFitter`. Constructor: `new AspectRatioFitter(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `AspectRatioFitter.AspectMode` | `AspectRatioFitter.AspectMode` | `AspectRatioFitter.aspectMode` |
| `AspectRatioFitter.AspectRatio` | `float` | `AspectRatioFitter.aspectRatio` |

### BaseMeshEffect

Widget for `UnityEngine.UI.BaseMeshEffect`. Constructor: `new BaseMeshEffect(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

No own attributes (inherited attribute classes live on the base widget, e.g. `HorizontalOrVerticalLayoutGroup`, or on `LayoutAliases`).

### Button

Widget for `UnityEngine.UI.Button`. Constructor: `new Button(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Button.OnClick` | `Events.UnityAction` | `Button.onClick` |

### CanvasScaler

Widget for `UnityEngine.UI.CanvasScaler`. Constructor: `new CanvasScaler(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `CanvasScaler.UiScaleMode` | `CanvasScaler.ScaleMode` | `CanvasScaler.uiScaleMode` |
| `CanvasScaler.ReferencePixelsPerUnit` | `float` | `CanvasScaler.referencePixelsPerUnit` |
| `CanvasScaler.ScaleFactor` | `float` | `CanvasScaler.scaleFactor` |
| `CanvasScaler.ReferenceResolution` | `Vector2` | `CanvasScaler.referenceResolution` |
| `CanvasScaler.ScreenMatchMode` | `CanvasScaler.ScreenMatchMode` | `CanvasScaler.screenMatchMode` |
| `CanvasScaler.MatchWidthOrHeight` | `float` | `CanvasScaler.matchWidthOrHeight` |
| `CanvasScaler.PhysicalUnit` | `CanvasScaler.Unit` | `CanvasScaler.physicalUnit` |
| `CanvasScaler.FallbackScreenDPI` | `float` | `CanvasScaler.fallbackScreenDPI` |
| `CanvasScaler.DefaultSpriteDPI` | `float` | `CanvasScaler.defaultSpriteDPI` |
| `CanvasScaler.DynamicPixelsPerUnit` | `float` | `CanvasScaler.dynamicPixelsPerUnit` |

### ContentSizeFitter

Widget for `UnityEngine.UI.ContentSizeFitter`. Constructor: `new ContentSizeFitter(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `ContentSizeFitter.HorizontalFit` | `ContentSizeFitter.FitMode` | `ContentSizeFitter.horizontalFit` |
| `ContentSizeFitter.VerticalFit` | `ContentSizeFitter.FitMode` | `ContentSizeFitter.verticalFit` |

### Dropdown

Widget for `UnityEngine.UI.Dropdown`. Constructor: `new Dropdown(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Dropdown.Template` | `RectTransform` | `Dropdown.template` |
| `Dropdown.CaptionText` | `Text` | `Dropdown.captionText` |
| `Dropdown.CaptionImage` | `Image` | `Dropdown.captionImage` |
| `Dropdown.ItemText` | `Text` | `Dropdown.itemText` |
| `Dropdown.ItemImage` | `Image` | `Dropdown.itemImage` |
| `Dropdown.Options` | `List<Dropdown.OptionData>` | `Dropdown.options` |
| `Dropdown.OnValueChanged` | `Dropdown.DropdownEvent` | `Dropdown.onValueChanged` |
| `Dropdown.AlphaFadeSpeed` | `float` | `Dropdown.alphaFadeSpeed` |
| `Dropdown.Value` | `int` | `Dropdown.value` |

### Graphic

Widget for `UnityEngine.UI.Graphic`. Constructor: `new Graphic(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Graphic.Color` | `Color` | `Graphic.color` |
| `Graphic.RaycastTarget` | `bool` | `Graphic.raycastTarget` |
| `Graphic.RaycastPadding` | `Vector4` | `Graphic.raycastPadding` |
| `Graphic.Material` | `Material` | `Graphic.material` |

### GraphicRaycaster

Widget for `UnityEngine.UI.GraphicRaycaster`. Constructor: `new GraphicRaycaster(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `GraphicRaycaster.IgnoreReversedGraphics` | `bool` | `GraphicRaycaster.ignoreReversedGraphics` |
| `GraphicRaycaster.BlockingObjects` | `GraphicRaycaster.BlockingObjects` | `GraphicRaycaster.blockingObjects` |
| `GraphicRaycaster.BlockingMask` | `LayerMask` | `GraphicRaycaster.blockingMask` |

### GridLayoutGroup

Widget for `UnityEngine.UI.GridLayoutGroup`. Constructor: `new GridLayoutGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `GridLayoutGroup.StartCorner` | `GridLayoutGroup.Corner` | `GridLayoutGroup.startCorner` |
| `GridLayoutGroup.StartAxis` | `GridLayoutGroup.Axis` | `GridLayoutGroup.startAxis` |
| `GridLayoutGroup.CellSize` | `Vector2` | `GridLayoutGroup.cellSize` |
| `GridLayoutGroup.Spacing` | `Vector2` | `GridLayoutGroup.spacing` |
| `GridLayoutGroup.Constraint` | `GridLayoutGroup.Constraint` | `GridLayoutGroup.constraint` |
| `GridLayoutGroup.ConstraintCount` | `int` | `GridLayoutGroup.constraintCount` |

### HorizontalLayoutGroup

Widget for `UnityEngine.UI.HorizontalLayoutGroup`. Constructor: `new HorizontalLayoutGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

No own attributes (inherited attribute classes live on the base widget, e.g. `HorizontalOrVerticalLayoutGroup`, or on `LayoutAliases`).

### HorizontalOrVerticalLayoutGroup

Widget for `UnityEngine.UI.HorizontalOrVerticalLayoutGroup`. Constructor: `new HorizontalOrVerticalLayoutGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `HorizontalOrVerticalLayoutGroup.Spacing` | `float` | `HorizontalOrVerticalLayoutGroup.spacing` |
| `HorizontalOrVerticalLayoutGroup.ChildForceExpandWidth` | `bool` | `HorizontalOrVerticalLayoutGroup.childForceExpandWidth` |
| `HorizontalOrVerticalLayoutGroup.ChildForceExpandHeight` | `bool` | `HorizontalOrVerticalLayoutGroup.childForceExpandHeight` |
| `HorizontalOrVerticalLayoutGroup.ChildControlWidth` | `bool` | `HorizontalOrVerticalLayoutGroup.childControlWidth` |
| `HorizontalOrVerticalLayoutGroup.ChildControlHeight` | `bool` | `HorizontalOrVerticalLayoutGroup.childControlHeight` |
| `HorizontalOrVerticalLayoutGroup.ChildScaleWidth` | `bool` | `HorizontalOrVerticalLayoutGroup.childScaleWidth` |
| `HorizontalOrVerticalLayoutGroup.ChildScaleHeight` | `bool` | `HorizontalOrVerticalLayoutGroup.childScaleHeight` |
| `HorizontalOrVerticalLayoutGroup.ReverseArrangement` | `bool` | `HorizontalOrVerticalLayoutGroup.reverseArrangement` |

### Image

Widget for `UnityEngine.UI.Image`. Constructor: `new Image(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Image.Sprite` | `Sprite` | `Image.sprite` |
| `Image.OverrideSprite` | `Sprite` | `Image.overrideSprite` |
| `Image.Type` | `Image.Type` | `Image.type` |
| `Image.PreserveAspect` | `bool` | `Image.preserveAspect` |
| `Image.FillCenter` | `bool` | `Image.fillCenter` |
| `Image.FillMethod` | `Image.FillMethod` | `Image.fillMethod` |
| `Image.FillAmount` | `float` | `Image.fillAmount` |
| `Image.FillClockwise` | `bool` | `Image.fillClockwise` |
| `Image.FillOrigin` | `int` | `Image.fillOrigin` |
| `Image.AlphaHitTestMinimumThreshold` | `float` | `Image.alphaHitTestMinimumThreshold` |
| `Image.UseSpriteMesh` | `bool` | `Image.useSpriteMesh` |
| `Image.PixelsPerUnitMultiplier` | `float` | `Image.pixelsPerUnitMultiplier` |
| `Image.Material` | `Material` | `Image.material` |

### InputField

Widget for `UnityEngine.UI.InputField`. Constructor: `new InputField(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `InputField.ShouldHideMobileInput` | `bool` | `InputField.shouldHideMobileInput` |
| `InputField.ShouldActivateOnSelect` | `bool` | `InputField.shouldActivateOnSelect` |
| `InputField.Text` | `string` | `InputField.text` |
| `InputField.CaretBlinkRate` | `float` | `InputField.caretBlinkRate` |
| `InputField.CaretWidth` | `int` | `InputField.caretWidth` |
| `InputField.TextComponent` | `Text` | `InputField.textComponent` |
| `InputField.Placeholder` | `Graphic` | `InputField.placeholder` |
| `InputField.CaretColor` | `Color` | `InputField.caretColor` |
| `InputField.CustomCaretColor` | `bool` | `InputField.customCaretColor` |
| `InputField.SelectionColor` | `Color` | `InputField.selectionColor` |
| `InputField.OnEndEdit` | `InputField.EndEditEvent` | `InputField.onEndEdit` |
| `InputField.OnSubmit` | `InputField.SubmitEvent` | `InputField.onSubmit` |
| `InputField.OnValueChanged` | `InputField.OnChangeEvent` | `InputField.onValueChanged` |
| `InputField.OnValidateInput` | `InputField.OnValidateInput` | `InputField.onValidateInput` |
| `InputField.CharacterLimit` | `int` | `InputField.characterLimit` |
| `InputField.ContentType` | `InputField.ContentType` | `InputField.contentType` |
| `InputField.LineType` | `InputField.LineType` | `InputField.lineType` |
| `InputField.InputType` | `InputField.InputType` | `InputField.inputType` |
| `InputField.KeyboardType` | `TouchScreenKeyboardType` | `InputField.keyboardType` |
| `InputField.CharacterValidation` | `InputField.CharacterValidation` | `InputField.characterValidation` |
| `InputField.ReadOnly` | `bool` | `InputField.readOnly` |
| `InputField.AsteriskChar` | `char` | `InputField.asteriskChar` |
| `InputField.CaretPosition` | `int` | `InputField.caretPosition` |
| `InputField.SelectionAnchorPosition` | `int` | `InputField.selectionAnchorPosition` |
| `InputField.SelectionFocusPosition` | `int` | `InputField.selectionFocusPosition` |

### LayoutElement

Widget for `UnityEngine.UI.LayoutElement`. Constructor: `new LayoutElement(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `LayoutElement.IgnoreLayout` | `bool` | `LayoutElement.ignoreLayout` |
| `LayoutElement.MinWidth` | `float` | `LayoutElement.minWidth` |
| `LayoutElement.MinHeight` | `float` | `LayoutElement.minHeight` |
| `LayoutElement.PreferredWidth` | `float` | `LayoutElement.preferredWidth` |
| `LayoutElement.PreferredHeight` | `float` | `LayoutElement.preferredHeight` |
| `LayoutElement.FlexibleWidth` | `float` | `LayoutElement.flexibleWidth` |
| `LayoutElement.FlexibleHeight` | `float` | `LayoutElement.flexibleHeight` |
| `LayoutElement.LayoutPriority` | `int` | `LayoutElement.layoutPriority` |

### LayoutGroup

Widget for `UnityEngine.UI.LayoutGroup`. Constructor: `new LayoutGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `LayoutGroup.Padding` | `RectOffset` | `LayoutGroup.padding` |
| `LayoutGroup.ChildAlignment` | `TextAnchor` | `LayoutGroup.childAlignment` |

### Mask

Widget for `UnityEngine.UI.Mask`. Constructor: `new Mask(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Mask.ShowMaskGraphic` | `bool` | `Mask.showMaskGraphic` |

### MaskableGraphic

Widget for `UnityEngine.UI.MaskableGraphic`. Constructor: `new MaskableGraphic(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `MaskableGraphic.OnCullStateChanged` | `MaskableGraphic.CullStateChangedEvent` | `MaskableGraphic.onCullStateChanged` |
| `MaskableGraphic.Maskable` | `bool` | `MaskableGraphic.maskable` |
| `MaskableGraphic.IsMaskingGraphic` | `bool` | `MaskableGraphic.isMaskingGraphic` |

### Outline

Widget for `UnityEngine.UI.Outline`. Constructor: `new Outline(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

No own attributes (inherited attribute classes live on the base widget, e.g. `HorizontalOrVerticalLayoutGroup`, or on `LayoutAliases`).

### PositionAsUV1

Widget for `UnityEngine.UI.PositionAsUV1`. Constructor: `new PositionAsUV1(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

No own attributes (inherited attribute classes live on the base widget, e.g. `HorizontalOrVerticalLayoutGroup`, or on `LayoutAliases`).

### RawImage

Widget for `UnityEngine.UI.RawImage`. Constructor: `new RawImage(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `RawImage.Texture` | `Texture` | `RawImage.texture` |
| `RawImage.UvRect` | `Rect` | `RawImage.uvRect` |

### RaycastReceiver

Widget for `UnityEngine.UI.RaycastReceiver`. Constructor: `new RaycastReceiver(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `RaycastReceiver.Material` | `Material` | `RaycastReceiver.material` |
| `RaycastReceiver.Color` | `Color` | `RaycastReceiver.color` |

### RectMask2D

Widget for `UnityEngine.UI.RectMask2D`. Constructor: `new RectMask2D(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `RectMask2D.Padding` | `Vector4` | `RectMask2D.padding` |
| `RectMask2D.Softness` | `Vector2Int` | `RectMask2D.softness` |

### ScrollRect

Widget for `UnityEngine.UI.ScrollRect`. Constructor: `new ScrollRect(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `ScrollRect.Content` | `RectTransform` | `ScrollRect.content` |
| `ScrollRect.Horizontal` | `bool` | `ScrollRect.horizontal` |
| `ScrollRect.Vertical` | `bool` | `ScrollRect.vertical` |
| `ScrollRect.MovementType` | `ScrollRect.MovementType` | `ScrollRect.movementType` |
| `ScrollRect.Elasticity` | `float` | `ScrollRect.elasticity` |
| `ScrollRect.Inertia` | `bool` | `ScrollRect.inertia` |
| `ScrollRect.DecelerationRate` | `float` | `ScrollRect.decelerationRate` |
| `ScrollRect.ScrollSensitivity` | `float` | `ScrollRect.scrollSensitivity` |
| `ScrollRect.Viewport` | `RectTransform` | `ScrollRect.viewport` |
| `ScrollRect.HorizontalScrollbar` | `Scrollbar` | `ScrollRect.horizontalScrollbar` |
| `ScrollRect.VerticalScrollbar` | `Scrollbar` | `ScrollRect.verticalScrollbar` |
| `ScrollRect.HorizontalScrollbarVisibility` | `ScrollRect.ScrollbarVisibility` | `ScrollRect.horizontalScrollbarVisibility` |
| `ScrollRect.VerticalScrollbarVisibility` | `ScrollRect.ScrollbarVisibility` | `ScrollRect.verticalScrollbarVisibility` |
| `ScrollRect.HorizontalScrollbarSpacing` | `float` | `ScrollRect.horizontalScrollbarSpacing` |
| `ScrollRect.VerticalScrollbarSpacing` | `float` | `ScrollRect.verticalScrollbarSpacing` |
| `ScrollRect.OnValueChanged` | `ScrollRect.ScrollRectEvent` | `ScrollRect.onValueChanged` |
| `ScrollRect.Velocity` | `Vector2` | `ScrollRect.velocity` |
| `ScrollRect.NormalizedPosition` | `Vector2` | `ScrollRect.normalizedPosition` |
| `ScrollRect.HorizontalNormalizedPosition` | `float` | `ScrollRect.horizontalNormalizedPosition` |
| `ScrollRect.VerticalNormalizedPosition` | `float` | `ScrollRect.verticalNormalizedPosition` |

### Scrollbar

Widget for `UnityEngine.UI.Scrollbar`. Constructor: `new Scrollbar(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Scrollbar.HandleRect` | `RectTransform` | `Scrollbar.handleRect` |
| `Scrollbar.Direction` | `Scrollbar.Direction` | `Scrollbar.direction` |
| `Scrollbar.Value` | `float` | `Scrollbar.value` |
| `Scrollbar.Size` | `float` | `Scrollbar.size` |
| `Scrollbar.NumberOfSteps` | `int` | `Scrollbar.numberOfSteps` |
| `Scrollbar.OnValueChanged` | `Scrollbar.ScrollEvent` | `Scrollbar.onValueChanged` |

### Selectable

Widget for `UnityEngine.UI.Selectable`. Constructor: `new Selectable(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Selectable.Navigation` | `Navigation` | `Selectable.navigation` |
| `Selectable.Transition` | `Selectable.Transition` | `Selectable.transition` |
| `Selectable.Colors` | `ColorBlock` | `Selectable.colors` |
| `Selectable.SpriteState` | `SpriteState` | `Selectable.spriteState` |
| `Selectable.AnimationTriggers` | `AnimationTriggers` | `Selectable.animationTriggers` |
| `Selectable.TargetGraphic` | `Graphic` | `Selectable.targetGraphic` |
| `Selectable.Interactable` | `bool` | `Selectable.interactable` |
| `Selectable.Image` | `Image` | `Selectable.image` |

### Shadow

Widget for `UnityEngine.UI.Shadow`. Constructor: `new Shadow(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Shadow.EffectColor` | `Color` | `Shadow.effectColor` |
| `Shadow.EffectDistance` | `Vector2` | `Shadow.effectDistance` |
| `Shadow.UseGraphicAlpha` | `bool` | `Shadow.useGraphicAlpha` |

### Slider

Widget for `UnityEngine.UI.Slider`. Constructor: `new Slider(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Slider.FillRect` | `RectTransform` | `Slider.fillRect` |
| `Slider.HandleRect` | `RectTransform` | `Slider.handleRect` |
| `Slider.Direction` | `Slider.Direction` | `Slider.direction` |
| `Slider.MinValue` | `float` | `Slider.minValue` |
| `Slider.MaxValue` | `float` | `Slider.maxValue` |
| `Slider.WholeNumbers` | `bool` | `Slider.wholeNumbers` |
| `Slider.Value` | `float` | `Slider.value` |
| `Slider.NormalizedValue` | `float` | `Slider.normalizedValue` |
| `Slider.OnValueChanged` | `Slider.SliderEvent` | `Slider.onValueChanged` |

### Text

Widget for `UnityEngine.UI.Text`. Constructor: `new Text(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Text.Value` | `string` | `Text.text` |
| `Text.Font` | `Font` | `Text.font` |
| `Text.SupportRichText` | `bool` | `Text.supportRichText` |
| `Text.ResizeTextForBestFit` | `bool` | `Text.resizeTextForBestFit` |
| `Text.ResizeTextMinSize` | `int` | `Text.resizeTextMinSize` |
| `Text.ResizeTextMaxSize` | `int` | `Text.resizeTextMaxSize` |
| `Text.Alignment` | `TextAnchor` | `Text.alignment` |
| `Text.AlignByGeometry` | `bool` | `Text.alignByGeometry` |
| `Text.FontSize` | `int` | `Text.fontSize` |
| `Text.HorizontalOverflow` | `HorizontalWrapMode` | `Text.horizontalOverflow` |
| `Text.VerticalOverflow` | `VerticalWrapMode` | `Text.verticalOverflow` |
| `Text.LineSpacing` | `float` | `Text.lineSpacing` |
| `Text.FontStyle` | `FontStyle` | `Text.fontStyle` |

### Toggle

Widget for `UnityEngine.UI.Toggle`. Constructor: `new Toggle(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `Toggle.Group` | `ToggleGroup` | `Toggle.group` |
| `Toggle.IsOn` | `bool` | `Toggle.isOn` |

### ToggleGroup

Widget for `UnityEngine.UI.ToggleGroup`. Constructor: `new ToggleGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

| Attribute | Value type | Applies to |
|---|---|---|
| `ToggleGroup.AllowSwitchOff` | `bool` | `ToggleGroup.allowSwitchOff` |

### VerticalLayoutGroup

Widget for `UnityEngine.UI.VerticalLayoutGroup`. Constructor: `new VerticalLayoutGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`.

No own attributes (inherited attribute classes live on the base widget, e.g. `HorizontalOrVerticalLayoutGroup`, or on `LayoutAliases`).

---

## Namespace `Veauty.uGUI.Presets`

### `V` (static class)

Factory with defaults; see [Presets API](presets.md) for parameter tables and auto-injection rules.

| Method | Returns |
|---|---|
| `V.Component(FunctionComponent)` / `(string, FunctionComponent)` / `<TProps>(FunctionComponent<TProps>, TProps)` / `<TProps>(string, FunctionComponent<TProps>, TProps)` | `IVTree` |
| `V.KeyedComponent(string, FunctionComponent)` / `<TProps>(string, FunctionComponent<TProps>, TProps)` | `IVTree` |
| `V.Text(string value, int? fontSize, Color? color, TextAnchor? alignment, FontStyle? fontStyle, float? preferredWidth, float? preferredHeight, float? flexibleWidth, float? flexibleHeight, params IAttribute<GameObject>[] extras)` | `IVTree` |
| `V.Button(UnityAction onClick, Color? color, float? preferredWidth, float? preferredHeight, float? flexibleWidth, float? flexibleHeight, IAttribute<GameObject>[] extras)` | `Element` |
| `V.Image(Color? color, float? preferredWidth, float? preferredHeight, float? flexibleWidth, float? flexibleHeight, IAttribute<GameObject>[] extras)` | `Element` |
| `V.VLayout(float? spacing, RectOffset padding, TextAnchor? childAlignment, IAttribute<GameObject>[] extras)` — forces `ChildControlWidth/Height=true`, `ChildForceExpandHeight=false` | `Element` |
| `V.HLayout(float? spacing, RectOffset padding, TextAnchor? childAlignment, IAttribute<GameObject>[] extras)` — forces `ChildControlWidth/Height=true`, `ChildForceExpandWidth=false` | `Element` |
| `V.Grid(Vector2? cellSize, Vector2? spacing, RectOffset padding, TextAnchor? childAlignment, IAttribute<GameObject>[] extras)` | `Element` |
| `V.RawImage(Texture texture, Rect? uvRect, Color? color, IAttribute<GameObject>[] extras)` | `Element` |
| `V.Toggle(bool? isOn, Color? color, bool? interactable, IAttribute<GameObject>[] extras)` — auto-injects Background/Checkmark | `Element` |
| `V.ToggleGroup(bool? allowSwitchOff, IAttribute<GameObject>[] extras)` | `Element` |
| `V.Slider(float? value, float? minValue, float? maxValue, bool? wholeNumbers, Slider.Direction? direction, bool? interactable, IAttribute<GameObject>[] extras)` — auto-injects Background/Fill/Handle | `Element` |
| `V.Scrollbar(float? value, float? size, int? numberOfSteps, Scrollbar.Direction? direction, IAttribute<GameObject>[] extras)` — auto-injects Handle | `Element` |
| `V.ScrollRect(bool? horizontal, bool? vertical, ScrollRect.MovementType? movementType, float? elasticity, bool? inertia, float? decelerationRate, float? scrollSensitivity, IAttribute<GameObject>[] extras)` | `Element` |
| `V.InputField(string text, InputField.ContentType? contentType, InputField.LineType? lineType, int? characterLimit, bool? readOnly, Color? color, IAttribute<GameObject>[] extras)` — auto-injects Placeholder/Text | `Element` |
| `V.Dropdown(int? value, List<Dropdown.OptionData> options, float? alphaFadeSpeed, IAttribute<GameObject>[] extras)` | `Element` |
| `V.Selectable(bool? interactable, Selectable.Transition? transition, ColorBlock? colors, Navigation? navigation, IAttribute<GameObject>[] extras)` | `Element` |
| `V.Mask(bool? showMaskGraphic, IAttribute<GameObject>[] extras)` | `Element` |
| `V.RectMask2D(Vector4? padding, Vector2Int? softness, IAttribute<GameObject>[] extras)` | `Element` |

### `Element`

```csharp
public class Element : IVTreeWrapper
```

| Member | Signature | Description |
|---|---|---|
| indexer | `IVTree this[params IVTree[] children]` | builds the widget with children; **not cached** |
| `Unwrap` | `IVTree Unwrap()` | childless build; **cached** after first call |
| `GetNodeType` | `VTreeType GetNodeType()` | delegates to `Unwrap()` |
| `GetDescendantsCount` | `int GetDescendantsCount()` | delegates to `Unwrap()` |

Constructor is `internal` — Elements are only created by `V`.

---

## Global namespace

### `Ref<T>` (alias)

```csharp
public class Ref<T> : Veauty.uGUI.Ref<T>
{
    public Ref(T defaultValue = default(T));
}
```

Convenience alias so `new Ref<GameObject>()` compiles without `using Veauty.uGUI;`. Identical behavior.

### `UIClass` (editor-only, assembly `Veauty.uGUI.Editor`)

```csharp
public class UIClass : MonoBehaviour
```

Host of the **Veauty > GenerateUIClass** menu item (the menu method itself is private). See [Code generation](code-generation.md).
