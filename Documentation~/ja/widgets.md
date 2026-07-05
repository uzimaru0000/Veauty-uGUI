# Widget Catalog

[English](../widgets.md)

`Veauty.uGUI` の全ウィジェットクラス、`GUIBase<T>` のライフサイクル、`Ref<T>`。

## `GUIBase<T>` — ウィジェットの基底クラス

```csharp
public abstract class GUIBase<T> :
    Node<UnityEngine.GameObject, T>,
    IHostLifecycle<UnityEngine.GameObject>,
    IHostLifecycleTree<UnityEngine.GameObject>
    where T : UnityEngine.Component
```

ウィジェットは tag が `typeof(T).FullName` の VTree ノードで、レンダリングされる GameObject はコンポーネント `T` を持ちます。コンストラクタ: `(IEnumerable<IAttribute<GameObject>> attrs, params IVTree[] kids)`。

### ライフサイクルフック

| フック | タイミング | 典型的な用途 |
|---|---|---|
| `Init(go)` | GameObject + コンポーネント生成後、属性適用・子レンダリングの**前** | 内部子の構築 (Slider の fill/handle、InputField の text area、Dropdown のテンプレート) |
| `AfterRenderKids(go)` | すべての VTree 子がレンダリング・親子付けされた後 | 子を必要とする配線 (ScrollRect の `content`) |
| `Destroy(go)` | アンマウント前 | クリーンアップ (デフォルトは no-op) |

順序の全体図は [Architecture](architecture.md)。`Init` が作る内部子は childOffset ルールによりパッチャーからスキップされます — 内部子を `Init` の外で作ってはいけません。

### protected ヘルパー (カスタムウィジェット用)

| ヘルパー | 説明 |
|---|---|
| `CreateChild(parent, name)` | 新 GameObject + `RectTransform`、`worldPositionStays: false` で親子付け |
| `Stretch(rt)` | アンカー 0..1、`sizeDelta = 0` |
| `AddVisual<TComp>(go, color)` | `CanvasRenderer` + グラフィック `TComp` を追加し色を設定 |
| `SetupRect(rt, ...)` | non-null の RectTransform プロパティのみ設定 |
| `FindPart<T>()` | 生の kids から型 `T` の最初の要素 (サブコンポーネント読み取り用) |

## 手書きウィジェット

ジェネレータでは生成されません (ジェネレータの `ManualTypes` スキップリストに入っています):

| ウィジェット | コンポーネント | 属性 |
|---|---|---|
| `Canvas` | `UnityEngine.Canvas` | `RenderMode`, `WorldCamera`, `PlaneDistance`, `PixelPerfect`, `ScaleFactor`, `ReferencePixelsPerUnit`, `OverridePixelPerfect`, `OverrideSorting`, `SortingOrder`, `TargetDisplay`, `SortingLayerID`, `SortingLayerName`, `AdditionalShaderChannels`, `NormalizedSortingGridSize`, `UseReflectionProbes`, `VertexColorAlwaysGammaSpace`, `UpdateRectTransformForStandalone` |
| `CanvasGroup` | `UnityEngine.CanvasGroup` | `Alpha`, `Interactable`, `BlocksRaycasts`, `IgnoreParentGroups` |
| `RectTransform` | `UnityEngine.RectTransform` | `AnchorMin`, `AnchorMax`, `AnchoredPosition`, `AnchoredPosition3D`, `SizeDelta`, `Pivot`, `OffsetMin`, `OffsetMax`, `SendChildDimensionsChange` |

`RectTransform` の属性クラスは通常*他の*ウィジェットに渡します (すべての uGUI ノードは RectTransform を持つため):

```csharp
V.Image(extras: new IAttribute<GameObject>[] {
    new RectTransform.AnchorMin(Vector2.zero),
    new RectTransform.AnchorMax(Vector2.one),
})
```

`Canvas` ウィジェットをレンダリングしても `GraphicRaycaster` の追加や `EventSystem` の生成は**行われません**。

## 生成ウィジェット (`Lib/Generated/`)

`UnityEngine.UI` の公開 MonoBehaviour サブクラスごとに 1 ウィジェット。**Veauty > GenerateUIClass** で再生成されます ([Code generation](code-generation.md))。現在のセット (31 型):

`AspectRatioFitter`, `BaseMeshEffect`, `Button`, `CanvasScaler`, `ContentSizeFitter`, `Dropdown`, `Graphic`, `GraphicRaycaster`, `GridLayoutGroup`, `HorizontalLayoutGroup`, `HorizontalOrVerticalLayoutGroup`, `Image`, `InputField`, `LayoutElement`, `LayoutGroup`, `Mask`, `MaskableGraphic`, `Outline`, `PositionAsUV1`, `RawImage`, `RaycastReceiver`, `RectMask2D`, `Scrollbar`, `ScrollRect`, `Selectable`, `Shadow`, `Slider`, `Text`, `Toggle`, `ToggleGroup`, `VerticalLayoutGroup`

注意:

- 属性クラスは**宣言されたプロパティのみ**から生成されます — `Button` にあるのは `OnClick` だけです。Button の `interactable` は `Selectable.Interactable` を使います (`GetComponent<Selectable>()` は派生型にもマッチするため、基底クラスの属性は派生コンポーネントで機能します)。
- `HorizontalLayoutGroup` / `VerticalLayoutGroup` / `GridLayoutGroup` は自前の書き込み可能プロパティを宣言していないため、使える属性は [LayoutAliases](#レイアウトエイリアス) か `HorizontalOrVerticalLayoutGroup` / `LayoutGroup` にあります。
- 抽象コンポーネントのウィジェット (`Graphic`, `MaskableGraphic`, `LayoutGroup`, `Selectable`, `HorizontalOrVerticalLayoutGroup`, `BaseMeshEffect`) は主に属性の入れ物です。ウィジェットとして実体化すると抽象型の `AddComponent` を試みて失敗します — 属性を具象ウィジェットに使ってください。
- ウィジェットごとの属性一覧表: [API reference](api-reference.md)。

### 手書きライフサイクルを持つウィジェット (`Lib/Initializers/`)

| ウィジェット | `Init` の動作 | その他 |
|---|---|---|
| `Button` | 既存の Graphic (なければ新規 `Image`) を `targetGraphic` に配線 | |
| `Text` | フォント未設定なら組み込み `LegacyRuntime.ttf` を設定 | |
| `Slider` | サブコンポーネントから Background / Fill Area / Handle Slide Area を構築 | `GetKids()` がサブコンポーネントを除外 |
| `Toggle` | Background (とその中の Checkmark) を構築 | `GetKids()` がサブコンポーネントを除外 |
| `Scrollbar` | 背景 `Image` がなければ追加; サブコンポーネントから Sliding Area + Handle | `GetKids()` がサブコンポーネントを除外 |
| `InputField` | 背景 `Image` がなければ追加; Text Area (`RectMask2D`) + Placeholder + Text | `GetKids()` がサブコンポーネントを除外 |
| `ScrollRect` | `Image` + `RectMask2D` がなければ追加 | `AfterRenderKids` が未設定なら最初の子を `content` に配線 |
| `Dropdown` | ドロップダウンのテンプレート一式 (label, arrow, list, item toggle) をハードコードされたダークテーマ色で構築 | サブコンポーネントなし |

## `Ref<T>` — レンダリングされた GameObject のキャプチャ

`Ref<T>` は対象を変更する代わりに、適用された対象を保存する属性です:

```csharp
var panelRef = new Ref<GameObject>();          // グローバル名前空間エイリアス

IVTree Render() =>
    V.Image(color: Color.black, extras: new IAttribute<GameObject>[] { panelRef })[
        ...
    ];

// レンダリング後: panelRef.current は Image の GameObject
var image = panelRef.current.GetComponent<UnityEngine.UI.Image>();
```

- `current` がキャプチャされたオブジェクト (初回レンダリングまではコンストラクタのデフォルト値)。
- 属性キーは `"ref:" + GetHashCode()` でインスタンスごとに一意。
- `Ref<T>` は **2 つ**あります: `Veauty.uGUI.Ref<T>` と、`using` なしで使えるようにしたグローバル名前空間の `Ref<T>` サブクラス。動作は同一で、ライブラリコードでは名前空間付きを推奨します。

## `ImageStyle`

小さな値構造体 (`Sprite`, `Color`, `ImageType`) で `ApplyTo(Image)` を持ちます — Sprite は non-null のときのみ、Color と ImageType は常に適用。カスタムウィジェットのコードで利用できます。
