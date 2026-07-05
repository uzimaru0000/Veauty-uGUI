# Presets API (`Veauty.uGUI.Presets`)

[English](../presets.md)

利便性レイヤー: 静的 `V` ファクトリ、インデクサ構文を持つ `Element` ビルダー、サブコンポーネント自動注入のルール。

```csharp
using Veauty.uGUI.Presets;
```

## `Element` ビルダー

多くの `V` メソッドは完成したツリーではなく `Element` — 遅延ウィジェットファクトリ (`IVTreeWrapper`) — を返します。

```csharp
// 1. インデクサ: 子を渡してツリーを得る
IVTree a = V.Button(onClick: Click)[ V.Text("OK") ];

// 2. 直接使用: Element 自体も有効な IVTree (子なしウィジェット)
IVTree b = V.Slider(value: 0.5f);
```

### キャッシュの注意点

- **インデクサ経路はキャッシュされません** — `element[children]` は呼ぶたびにファクトリを実行します。
- **`Unwrap()` はキャッシュされます** — 最初の子なしビルドが保存され、以後の呼び出し (`Unwrap()` に委譲する `GetNodeType()` / `GetDescendantsCount()` を含む) は*同じ* `IVTree` インスタンスを返します。

実践ルール: `Element` は使い捨てとして扱い、レンダリングごとに新しく作ってください。フィールドに保持してレンダリングをまたいで再利用し、毎回新しいノードが返ると期待してはいけません。

## `V` ファクトリメソッド

すべてのオプション引数は共通の原則に従います: **渡した引数だけが属性になる** (後述のレイアウトの強制デフォルトを除く)。どのメソッドも `extras` (`IAttribute<GameObject>[]`) を受け取り、生成された属性の後ろに追加されます — 同じキーは後勝ちなので、extras で生成属性を上書きできます。

### 関数コンポーネント

| メソッド | 説明 |
|---|---|
| `V.Component(FunctionComponent)` | Hooks が使える関数コンポーネントをラップ |
| `V.Component(string key, FunctionComponent)` | 明示的な identity キー付き |
| `V.Component<TProps>(FunctionComponent<TProps>, TProps)` | props 付き |
| `V.Component<TProps>(string key, FunctionComponent<TProps>, TProps)` | props + キー |
| `V.KeyedComponent(string key, FunctionComponent)` | リスト diff 用のキー付きノード |
| `V.KeyedComponent<TProps>(string key, FunctionComponent<TProps>, TProps)` | キー付き + props |

### 単純ウィジェット

| メソッド | 引数 (注記のない限りすべて省略可) | 自動補完されるデフォルト |
|---|---|---|
| `V.Text(value, ...)` → `IVTree` | `value` (必須), `fontSize`, `color`, `alignment`, `fontStyle`, `preferredWidth/Height`, `flexibleWidth/Height`, `params extras` | `Text.Init` による組み込みフォント |
| `V.Button(...)` → `Element` | `onClick`, `color`, `preferredWidth/Height`, `flexibleWidth/Height`, `extras` | `Button.Init` が `Image` を `targetGraphic` に |
| `V.Image(...)` → `Element` | `color`, `preferredWidth/Height`, `flexibleWidth/Height`, `extras` | — |
| `V.RawImage(...)` → `Element` | `texture`, `uvRect`, `color`, `extras` | — |
| `V.Selectable(...)` → `Element` | `interactable`, `transition`, `colors`, `navigation`, `extras` | — |
| `V.Mask(...)` → `Element` | `showMaskGraphic`, `extras` | — |
| `V.RectMask2D(...)` → `Element` | `padding`, `softness`, `extras` | — |
| `V.ToggleGroup(...)` → `Element` | `allowSwitchOff`, `extras` | — |
| `V.Dropdown(...)` → `Element` | `value`, `options`, `alphaFadeSpeed`, `extras` | `Dropdown.Init` による内部テンプレート一式 |
| `V.ScrollRect(...)` → `Element` | `horizontal`, `vertical`, `movementType`, `elasticity`, `inertia`, `decelerationRate`, `scrollSensitivity`, `extras` | `Init` で `Image`+`RectMask2D`; 最初の子が `content` に |

注: `V.Text` だけは `Element` ではなく `IVTree` を直接返します (Text は子を取りません)。`extras` も配列引数ではなく `params IAttribute<GameObject>[]` です。

### レイアウトウィジェット — 強制デフォルト

| メソッド | 常に適用 | 省略可 |
|---|---|---|
| `V.VLayout(...)` | `Spacing` (引数または **0**), `ChildControlWidth = true`, `ChildControlHeight = true`, `ChildForceExpandHeight = false` | `padding`, `childAlignment`, `extras` |
| `V.HLayout(...)` | `Spacing` (引数または **0**), `ChildControlWidth = true`, `ChildControlHeight = true`, `ChildForceExpandWidth = false` | `padding`, `childAlignment`, `extras` |
| `V.Grid(...)` | *(強制なし)* | `cellSize`, `spacing`, `padding`, `childAlignment`, `extras` |

強制デフォルトを打ち消すには同じ属性を `extras` に渡します — 例: `V.VLayout(extras: new IAttribute<GameObject>[] { new VerticalLayoutGroup.ChildForceExpandHeight(true) })`。

### 複合ウィジェット — サブコンポーネント自動注入

`V.Toggle`, `V.Slider`, `V.Scrollbar`, `V.InputField` はインデクサで渡された子を走査します:

1. `ISubComponent` を実装する子はパーツとして収集、それ以外はコンテンツ;
2. *不足している*必須パーツはデフォルト設定で追加;
3. 最終的な kids の順序 = サブコンポーネントが先、コンテンツ子が後。

| メソッド | 固有引数 | 自動注入されるパーツ (不足時) |
|---|---|---|
| `V.Toggle(...)` | `isOn`, `color`, `interactable`, `extras` | `Toggle.ToggleBackground`, `Toggle.ToggleCheckmark` |
| `V.Slider(...)` | `value`, `minValue`, `maxValue`, `wholeNumbers`, `direction`, `interactable`, `extras` | `Slider.SliderBackground`, `Slider.SliderFill`, `Slider.SliderHandle` |
| `V.Scrollbar(...)` | `value`, `size`, `numberOfSteps`, `direction`, `extras` | `Scrollbar.ScrollbarHandlePart` |
| `V.InputField(...)` | `text`, `contentType`, `lineType`, `characterLimit`, `readOnly`, `color`, `extras` | `InputField.InputFieldPlaceholderPart`, `InputField.InputFieldTextPart` |

```csharp
V.Slider(value: 0.5f)                                    // 3 パーツすべてデフォルト
V.Slider(value: 0.5f)[ Slider.Fill(color: Color.red) ]   // Fill だけカスタム
V.Toggle(isOn: true)[ V.Text("Enable") ]                 // デフォルト bg/checkmark + ラベル
```

パーツのデフォルト色とジオメトリは [Sub-components](sub-components.md) を参照。なお `V.Slider` では `value` は `minValue`/`maxValue`/`direction` の*後*に、`V.Scrollbar` では `value` は最後に適用されるため、最終的なレンジでクランプされます。

## Base API に降りるべきとき

以下の場合は `using Veauty.uGUI;` を直接使います:

- パーツを自動注入したくない (例: Background を*まったく持たない* Slider — Base API は渡したパーツしか作りません);
- すべての属性を明示的に制御したい;
- カスタムウィジェットを作りたい (`GUIBase<T>` を継承)。

[Widget catalog](widgets.md) と [Sub-components](sub-components.md) を参照。
