# API Reference

[English](../api-reference.md)

`com.uzimaru.veauty-ugui` (アセンブリ `Veauty.uGUI`, `Veauty.uGUI.Editor`) の公開 API 全体を名前空間別にまとめたリファレンス。解説は [Widget catalog](widgets.md) と [Attribute system](attributes.md) を参照。

---

## 名前空間 `Veauty.uGUI` — コア型

### `GUIBase<T>`

```csharp
public abstract class GUIBase<T> :
    Node<UnityEngine.GameObject, T>,
    IHostLifecycle<UnityEngine.GameObject>,
    IHostLifecycleTree<UnityEngine.GameObject>
    where T : UnityEngine.Component
```

すべてのウィジェットの基底クラス。ノードの tag = `typeof(T).FullName`。

| メンバー | シグネチャ | 説明 |
|---|---|---|
| ctor | `protected GUIBase(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)` | 属性 + 子/サブコンポーネント |
| `Init` | `virtual GameObject Init(GameObject go)` | 属性適用前のフック。内部子はここで構築 |
| `AfterRenderKids` | `virtual void AfterRenderKids(GameObject go)` | 子レンダリング後のフック |
| `Destroy` | `virtual void Destroy(GameObject go)` | アンマウント時のフック |
| `GetHostLifecycles` | `IHostLifecycle<GameObject>[] GetHostLifecycles()` | `{ this }` を返す |
| `GetDescendantsCount` | `override int GetDescendantsCount()` | `GetKids()` ビューのみを数える |
| `CreateChild` | `protected static GameObject CreateChild(GameObject parent, string name)` | 内部子 + RectTransform |
| `Stretch` | `protected static void Stretch(RectTransform rt)` | アンカー 0..1、sizeDelta 0 |
| `AddVisual<TComp>` | `protected static TComp AddVisual<TComp>(GameObject go, Color color) where TComp : Graphic` | CanvasRenderer + グラフィック |
| `SetupRect` | `protected static void SetupRect(RectTransform rt, Vector2? anchorMin = null, ..., Vector2? offsetMax = null)` | non-null のプロパティのみ設定 |
| `FindPart<T>` | `protected T FindPart<T>() where T : class` | 生の kids から型 T の最初の要素 |

備考: 内部子は `Init` でのみ生成すること (childOffset ルール、[Architecture](architecture.md) 参照)。

### `GuiAttributeBase<T1, T2>`

```csharp
public abstract class GuiAttributeBase<T1, T2> : Attribute<UnityEngine.GameObject, T2>
    where T1 : UnityEngine.Component
```

| メンバー | シグネチャ | 説明 |
|---|---|---|
| ctor | `protected GuiAttributeBase(string key, T2 value)` | key = diff の同一性 |
| `Apply` (abstract) | `protected abstract void Apply(T1 component)` | コンポーネントに値を書く |
| `Apply` (override) | `public override void Apply(GameObject obj)` | GetComponent、ホワイトリスト自動追加、ディスパッチ |

備考: `T1` がなくホワイトリスト (`LayoutElement`, `ContentSizeFitter`, `AspectRatioFitter`, `CanvasGroup`, `Shadow`, `Outline`, `PositionAsUV1`) 外なら**サイレント no-op**。

### `ISubComponent`

```csharp
public interface ISubComponent { }
```

ウィジェットパーツ設定のマーカー。`GetKids()` から除外され、`Init` で消費されます。レンダリングされません。

### `ImageStyle`

```csharp
public struct ImageStyle
{
    public Sprite Sprite;          // non-null のときのみ適用
    public Color Color;            // 常に適用
    public Image.Type ImageType;   // 常に適用
    public void ApplyTo(Image image);
}
```

### `Ref<T>`

```csharp
namespace Veauty.uGUI { public class Ref<T> : IAttribute<T> { ... } }
public class Ref<T> : Veauty.uGUI.Ref<T> { ... }   // グローバル名前空間エイリアス
```

| メンバー | シグネチャ | 説明 |
|---|---|---|
| `current` | `public T current` | キャプチャされたオブジェクト (適用まではコンストラクタのデフォルト) |
| ctor | `Ref(T defaultValue = default)` | |
| `GetKey` | `string GetKey()` | `"ref:" + GetHashCode()` — インスタンスごとに一意 |
| `Apply` | `void Apply(T obj)` | `obj` を `current` に保存 |

---

## 名前空間 `Veauty.uGUI` — 手書きウィジェット

### Canvas

`UnityEngine.Canvas` に対応するウィジェット。コンストラクタ: `new Canvas(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`。抽象属性基底: `CanvasAttribute<T>`。

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.CanvasGroup` に対応するウィジェット。コンストラクタは同上。抽象属性基底: `CanvasGroupAttribute<T>` (ホワイトリスト対象: コンポーネントを自動追加)。

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `CanvasGroup.Alpha` | `float` | `CanvasGroup.alpha` |
| `CanvasGroup.Interactable` | `bool` | `CanvasGroup.interactable` |
| `CanvasGroup.BlocksRaycasts` | `bool` | `CanvasGroup.blocksRaycasts` |
| `CanvasGroup.IgnoreParentGroups` | `bool` | `CanvasGroup.ignoreParentGroups` |

### RectTransform

`UnityEngine.RectTransform` に対応するウィジェット。コンストラクタは同上。抽象属性基底: `RectTransformAttribute<T>`。属性はどの uGUI ウィジェットにも使えます (すべてのノードが RectTransform を持つため)。

| 属性 | 値の型 | 適用先 |
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

## 名前空間 `Veauty.uGUI` — レイアウトエイリアス (`LayoutAliases.cs`)

partial なレイアウトグループウィジェット向けの、継承属性の手書きサブクラス:

| エイリアス | 継承元 |
|---|---|
| `HorizontalLayoutGroup.Padding` / `VerticalLayoutGroup.Padding` / `GridLayoutGroup.Padding` | `LayoutGroup.Padding` |
| `HorizontalLayoutGroup.ChildAlignment` / `VerticalLayoutGroup.ChildAlignment` / `GridLayoutGroup.ChildAlignment` | `LayoutGroup.ChildAlignment` |
| `HorizontalLayoutGroup.Spacing` / `VerticalLayoutGroup.Spacing` | `HorizontalOrVerticalLayoutGroup.Spacing` |
| `H/V...ChildForceExpandWidth`, `ChildForceExpandHeight`, `ChildControlWidth`, `ChildControlHeight`, `ChildScaleWidth`, `ChildScaleHeight`, `ReverseArrangement` | 対応する `HorizontalOrVerticalLayoutGroup.*` |

---

## 名前空間 `Veauty.uGUI` — サブコンポーネント (`Lib/Initializers/`)

すべて readonly フィールドを持つ `IVTree, ISubComponent` の設定キャリアで、`GetNodeType() => Node`、`GetDescendantsCount() => 0`。デフォルト値は [Sub-components](sub-components.md) を参照。

| 型 | ファクトリメソッド | フィールド |
|---|---|---|
| `Slider.SliderBackground` | `Slider.Background(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `Slider.SliderFill` | `Slider.Fill(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `Slider.SliderHandle` | `Slider.Handle(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `Toggle.ToggleBackground` | `Toggle.Background(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `Toggle.ToggleCheckmark` | `Toggle.Checkmark(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `Scrollbar.ScrollbarHandlePart` | `Scrollbar.Handle(Sprite, Color?, Image.Type?)` | `sprite`, `color`, `imageType` |
| `InputField.InputFieldPlaceholderPart` | `InputField.PlaceholderText(string, Color?, int?, TextAnchor?)` | `text`, `color`, `fontSize`, `alignment` |
| `InputField.InputFieldTextPart` | `InputField.TextDisplay(Color?, int?, TextAnchor?)` | `color`, `fontSize`, `alignment` |

ライフサイクルオーバーライドを持つウィジェット: `Button.Init` (targetGraphic)、`Text.Init` (デフォルトフォント)、`Slider/Toggle/Scrollbar/InputField` (`GetKids` フィルタ + `Init` 構造)、`ScrollRect` (`Init` + `AfterRenderKids` の content 配線)、`Dropdown.Init` (テンプレート一式)。

---

## 名前空間 `Veauty.uGUI` — 生成ウィジェット (`Lib/Generated/`)

各ウィジェット `Xxx` につき: `public partial class Xxx : GUIBase<UnityEngine.UI.Xxx>`、コンストラクタ `(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`、および抽象 `XxxAttribute<T> : GuiAttributeBase<UnityEngine.UI.Xxx, T>`。属性のセマンティクスは `component.<property> = value`。例外は `Button.OnClick` (`RemoveAllListeners` + `AddListener`) と `Text.Value` (`text` プロパティ)。

### AspectRatioFitter

`UnityEngine.UI.AspectRatioFitter` に対応するウィジェット。コンストラクタ: `new AspectRatioFitter(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `AspectRatioFitter.AspectMode` | `AspectRatioFitter.AspectMode` | `AspectRatioFitter.aspectMode` |
| `AspectRatioFitter.AspectRatio` | `float` | `AspectRatioFitter.aspectRatio` |

### BaseMeshEffect

`UnityEngine.UI.BaseMeshEffect` に対応するウィジェット。コンストラクタ: `new BaseMeshEffect(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

固有の属性はありません（継承元ウィジェット (`HorizontalOrVerticalLayoutGroup` など) または `LayoutAliases` の属性を使用します）。

### Button

`UnityEngine.UI.Button` に対応するウィジェット。コンストラクタ: `new Button(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `Button.OnClick` | `Events.UnityAction` | `Button.onClick` |

### CanvasScaler

`UnityEngine.UI.CanvasScaler` に対応するウィジェット。コンストラクタ: `new CanvasScaler(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.UI.ContentSizeFitter` に対応するウィジェット。コンストラクタ: `new ContentSizeFitter(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `ContentSizeFitter.HorizontalFit` | `ContentSizeFitter.FitMode` | `ContentSizeFitter.horizontalFit` |
| `ContentSizeFitter.VerticalFit` | `ContentSizeFitter.FitMode` | `ContentSizeFitter.verticalFit` |

### Dropdown

`UnityEngine.UI.Dropdown` に対応するウィジェット。コンストラクタ: `new Dropdown(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.UI.Graphic` に対応するウィジェット。コンストラクタ: `new Graphic(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `Graphic.Color` | `Color` | `Graphic.color` |
| `Graphic.RaycastTarget` | `bool` | `Graphic.raycastTarget` |
| `Graphic.RaycastPadding` | `Vector4` | `Graphic.raycastPadding` |
| `Graphic.Material` | `Material` | `Graphic.material` |

### GraphicRaycaster

`UnityEngine.UI.GraphicRaycaster` に対応するウィジェット。コンストラクタ: `new GraphicRaycaster(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `GraphicRaycaster.IgnoreReversedGraphics` | `bool` | `GraphicRaycaster.ignoreReversedGraphics` |
| `GraphicRaycaster.BlockingObjects` | `GraphicRaycaster.BlockingObjects` | `GraphicRaycaster.blockingObjects` |
| `GraphicRaycaster.BlockingMask` | `LayerMask` | `GraphicRaycaster.blockingMask` |

### GridLayoutGroup

`UnityEngine.UI.GridLayoutGroup` に対応するウィジェット。コンストラクタ: `new GridLayoutGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `GridLayoutGroup.StartCorner` | `GridLayoutGroup.Corner` | `GridLayoutGroup.startCorner` |
| `GridLayoutGroup.StartAxis` | `GridLayoutGroup.Axis` | `GridLayoutGroup.startAxis` |
| `GridLayoutGroup.CellSize` | `Vector2` | `GridLayoutGroup.cellSize` |
| `GridLayoutGroup.Spacing` | `Vector2` | `GridLayoutGroup.spacing` |
| `GridLayoutGroup.Constraint` | `GridLayoutGroup.Constraint` | `GridLayoutGroup.constraint` |
| `GridLayoutGroup.ConstraintCount` | `int` | `GridLayoutGroup.constraintCount` |

### HorizontalLayoutGroup

`UnityEngine.UI.HorizontalLayoutGroup` に対応するウィジェット。コンストラクタ: `new HorizontalLayoutGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

固有の属性はありません（継承元ウィジェット (`HorizontalOrVerticalLayoutGroup` など) または `LayoutAliases` の属性を使用します）。

### HorizontalOrVerticalLayoutGroup

`UnityEngine.UI.HorizontalOrVerticalLayoutGroup` に対応するウィジェット。コンストラクタ: `new HorizontalOrVerticalLayoutGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.UI.Image` に対応するウィジェット。コンストラクタ: `new Image(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.UI.InputField` に対応するウィジェット。コンストラクタ: `new InputField(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.UI.LayoutElement` に対応するウィジェット。コンストラクタ: `new LayoutElement(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.UI.LayoutGroup` に対応するウィジェット。コンストラクタ: `new LayoutGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `LayoutGroup.Padding` | `RectOffset` | `LayoutGroup.padding` |
| `LayoutGroup.ChildAlignment` | `TextAnchor` | `LayoutGroup.childAlignment` |

### Mask

`UnityEngine.UI.Mask` に対応するウィジェット。コンストラクタ: `new Mask(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `Mask.ShowMaskGraphic` | `bool` | `Mask.showMaskGraphic` |

### MaskableGraphic

`UnityEngine.UI.MaskableGraphic` に対応するウィジェット。コンストラクタ: `new MaskableGraphic(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `MaskableGraphic.OnCullStateChanged` | `MaskableGraphic.CullStateChangedEvent` | `MaskableGraphic.onCullStateChanged` |
| `MaskableGraphic.Maskable` | `bool` | `MaskableGraphic.maskable` |
| `MaskableGraphic.IsMaskingGraphic` | `bool` | `MaskableGraphic.isMaskingGraphic` |

### Outline

`UnityEngine.UI.Outline` に対応するウィジェット。コンストラクタ: `new Outline(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

固有の属性はありません（継承元ウィジェット (`HorizontalOrVerticalLayoutGroup` など) または `LayoutAliases` の属性を使用します）。

### PositionAsUV1

`UnityEngine.UI.PositionAsUV1` に対応するウィジェット。コンストラクタ: `new PositionAsUV1(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

固有の属性はありません（継承元ウィジェット (`HorizontalOrVerticalLayoutGroup` など) または `LayoutAliases` の属性を使用します）。

### RawImage

`UnityEngine.UI.RawImage` に対応するウィジェット。コンストラクタ: `new RawImage(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `RawImage.Texture` | `Texture` | `RawImage.texture` |
| `RawImage.UvRect` | `Rect` | `RawImage.uvRect` |

### RaycastReceiver

`UnityEngine.UI.RaycastReceiver` に対応するウィジェット。コンストラクタ: `new RaycastReceiver(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `RaycastReceiver.Material` | `Material` | `RaycastReceiver.material` |
| `RaycastReceiver.Color` | `Color` | `RaycastReceiver.color` |

### RectMask2D

`UnityEngine.UI.RectMask2D` に対応するウィジェット。コンストラクタ: `new RectMask2D(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `RectMask2D.Padding` | `Vector4` | `RectMask2D.padding` |
| `RectMask2D.Softness` | `Vector2Int` | `RectMask2D.softness` |

### ScrollRect

`UnityEngine.UI.ScrollRect` に対応するウィジェット。コンストラクタ: `new ScrollRect(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.UI.Scrollbar` に対応するウィジェット。コンストラクタ: `new Scrollbar(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `Scrollbar.HandleRect` | `RectTransform` | `Scrollbar.handleRect` |
| `Scrollbar.Direction` | `Scrollbar.Direction` | `Scrollbar.direction` |
| `Scrollbar.Value` | `float` | `Scrollbar.value` |
| `Scrollbar.Size` | `float` | `Scrollbar.size` |
| `Scrollbar.NumberOfSteps` | `int` | `Scrollbar.numberOfSteps` |
| `Scrollbar.OnValueChanged` | `Scrollbar.ScrollEvent` | `Scrollbar.onValueChanged` |

### Selectable

`UnityEngine.UI.Selectable` に対応するウィジェット。コンストラクタ: `new Selectable(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.UI.Shadow` に対応するウィジェット。コンストラクタ: `new Shadow(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `Shadow.EffectColor` | `Color` | `Shadow.effectColor` |
| `Shadow.EffectDistance` | `Vector2` | `Shadow.effectDistance` |
| `Shadow.UseGraphicAlpha` | `bool` | `Shadow.useGraphicAlpha` |

### Slider

`UnityEngine.UI.Slider` に対応するウィジェット。コンストラクタ: `new Slider(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.UI.Text` に対応するウィジェット。コンストラクタ: `new Text(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
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

`UnityEngine.UI.Toggle` に対応するウィジェット。コンストラクタ: `new Toggle(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `Toggle.Group` | `ToggleGroup` | `Toggle.group` |
| `Toggle.IsOn` | `bool` | `Toggle.isOn` |

### ToggleGroup

`UnityEngine.UI.ToggleGroup` に対応するウィジェット。コンストラクタ: `new ToggleGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

| 属性 | 値の型 | 適用先 |
|---|---|---|
| `ToggleGroup.AllowSwitchOff` | `bool` | `ToggleGroup.allowSwitchOff` |

### VerticalLayoutGroup

`UnityEngine.UI.VerticalLayoutGroup` に対応するウィジェット。コンストラクタ: `new VerticalLayoutGroup(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`

固有の属性はありません（継承元ウィジェット (`HorizontalOrVerticalLayoutGroup` など) または `LayoutAliases` の属性を使用します）。

---

## 名前空間 `Veauty.uGUI.Presets`

### `V` (静的クラス)

デフォルト値付きファクトリ。引数の一覧と自動注入のルールは [Presets API](presets.md) を参照。

| メソッド | 戻り値 |
|---|---|
| `V.Component(FunctionComponent)` / `(string, FunctionComponent)` / `<TProps>(FunctionComponent<TProps>, TProps)` / `<TProps>(string, FunctionComponent<TProps>, TProps)` | `IVTree` |
| `V.KeyedComponent(string, FunctionComponent)` / `<TProps>(string, FunctionComponent<TProps>, TProps)` | `IVTree` |
| `V.Text(string value, int? fontSize, Color? color, TextAnchor? alignment, FontStyle? fontStyle, float? preferredWidth, float? preferredHeight, float? flexibleWidth, float? flexibleHeight, params IAttribute<GameObject>[] extras)` | `IVTree` |
| `V.Button(UnityAction onClick, Color? color, float? preferredWidth, float? preferredHeight, float? flexibleWidth, float? flexibleHeight, IAttribute<GameObject>[] extras)` | `Element` |
| `V.Image(Color? color, float? preferredWidth, float? preferredHeight, float? flexibleWidth, float? flexibleHeight, IAttribute<GameObject>[] extras)` | `Element` |
| `V.VLayout(float? spacing, RectOffset padding, TextAnchor? childAlignment, IAttribute<GameObject>[] extras)` — `ChildControlWidth/Height=true`, `ChildForceExpandHeight=false` を強制 | `Element` |
| `V.HLayout(float? spacing, RectOffset padding, TextAnchor? childAlignment, IAttribute<GameObject>[] extras)` — `ChildControlWidth/Height=true`, `ChildForceExpandWidth=false` を強制 | `Element` |
| `V.Grid(Vector2? cellSize, Vector2? spacing, RectOffset padding, TextAnchor? childAlignment, IAttribute<GameObject>[] extras)` | `Element` |
| `V.RawImage(Texture texture, Rect? uvRect, Color? color, IAttribute<GameObject>[] extras)` | `Element` |
| `V.Toggle(bool? isOn, Color? color, bool? interactable, IAttribute<GameObject>[] extras)` — Background/Checkmark を自動注入 | `Element` |
| `V.ToggleGroup(bool? allowSwitchOff, IAttribute<GameObject>[] extras)` | `Element` |
| `V.Slider(float? value, float? minValue, float? maxValue, bool? wholeNumbers, Slider.Direction? direction, bool? interactable, IAttribute<GameObject>[] extras)` — Background/Fill/Handle を自動注入 | `Element` |
| `V.Scrollbar(float? value, float? size, int? numberOfSteps, Scrollbar.Direction? direction, IAttribute<GameObject>[] extras)` — Handle を自動注入 | `Element` |
| `V.ScrollRect(bool? horizontal, bool? vertical, ScrollRect.MovementType? movementType, float? elasticity, bool? inertia, float? decelerationRate, float? scrollSensitivity, IAttribute<GameObject>[] extras)` | `Element` |
| `V.InputField(string text, InputField.ContentType? contentType, InputField.LineType? lineType, int? characterLimit, bool? readOnly, Color? color, IAttribute<GameObject>[] extras)` — Placeholder/Text を自動注入 | `Element` |
| `V.Dropdown(int? value, List<Dropdown.OptionData> options, float? alphaFadeSpeed, IAttribute<GameObject>[] extras)` | `Element` |
| `V.Selectable(bool? interactable, Selectable.Transition? transition, ColorBlock? colors, Navigation? navigation, IAttribute<GameObject>[] extras)` | `Element` |
| `V.Mask(bool? showMaskGraphic, IAttribute<GameObject>[] extras)` | `Element` |
| `V.RectMask2D(Vector4? padding, Vector2Int? softness, IAttribute<GameObject>[] extras)` | `Element` |

### `Element`

```csharp
public class Element : IVTreeWrapper
```

| メンバー | シグネチャ | 説明 |
|---|---|---|
| インデクサ | `IVTree this[params IVTree[] children]` | 子付きでウィジェットを構築; **キャッシュなし** |
| `Unwrap` | `IVTree Unwrap()` | 子なしビルド; 初回以降**キャッシュ** |
| `GetNodeType` | `VTreeType GetNodeType()` | `Unwrap()` に委譲 |
| `GetDescendantsCount` | `int GetDescendantsCount()` | `Unwrap()` に委譲 |

コンストラクタは `internal` — Element は `V` からのみ生成されます。

---

## グローバル名前空間

### `Ref<T>` (エイリアス)

```csharp
public class Ref<T> : Veauty.uGUI.Ref<T>
{
    public Ref(T defaultValue = default(T));
}
```

`using Veauty.uGUI;` なしで `new Ref<GameObject>()` と書けるようにする利便エイリアス。動作は同一です。

### `UIClass` (エディタ専用、アセンブリ `Veauty.uGUI.Editor`)

```csharp
public class UIClass : MonoBehaviour
```

**Veauty > GenerateUIClass** メニューのホスト (メニューメソッド自体は private)。[Code generation](code-generation.md) を参照。
