# Attribute System

[English](../attributes.md)

uGUI 属性がコンポーネントを見つけて書き込む仕組み、自動追加ホワイトリスト、サイレント no-op の罠、カスタム属性の書き方。

## `GuiAttributeBase<TComponent, TValue>`

すべての uGUI 属性は次を継承します:

```csharp
public abstract class GuiAttributeBase<T1, T2> : Attribute<UnityEngine.GameObject, T2>
    where T1 : UnityEngine.Component
{
    protected GuiAttributeBase(string key, T2 value);
    protected abstract void Apply(T1 component);            // 属性ごとに実装
    public override void Apply(UnityEngine.GameObject obj); // コンポーネント検索 + ディスパッチ
}
```

適用ロジック:

```
component = obj.GetComponent<T1>()
if component == null かつ T1 がホワイトリスト内: component = obj.AddComponent<T1>()
if component != null:                            Apply(component)
// else: 何も起きない
```

## 自動追加ホワイトリスト

以下のコンポーネント型は、なければ自動的に追加されます (どのノードにも意味を持つ付加系ヘルパーです):

- `UnityEngine.UI.LayoutElement`
- `UnityEngine.UI.ContentSizeFitter`
- `UnityEngine.UI.AspectRatioFitter`
- `UnityEngine.CanvasGroup`
- `UnityEngine.UI.Shadow`
- `UnityEngine.UI.Outline`
- `UnityEngine.UI.PositionAsUV1`

なので `V.Text("hi", preferredWidth: 100f)` は Text ノードに `LayoutElement` がなくても機能します — `LayoutElement.PreferredWidth` 属性が追加するからです。

## 注意: それ以外はサイレント no-op

コンポーネントがなく、かつホワイトリスト外の場合、`Apply` は静かに何もしません — 例外もログも出ません。典型的な罠:

```csharp
// 間違い: Image ノードに Slider コンポーネントはない -> 属性は黙って無視される
V.Image(extras: new IAttribute<GameObject>[] { new Slider.Value(0.5f) })

// 正しい: Slider の属性は Slider ウィジェットに
V.Slider(value: 0.5f)
```

基底クラスの属性は派生コンポーネントで機能します (`Selectable.Interactable` は Button/Toggle/Slider ノードで、`Graphic.Color` は Image/Text/RawImage ノードで動く) — `GetComponent<Selectable>()` はサブクラスにもマッチするためです。

逆方向にも注意: 後のレンダリングで属性がツリーから消えても、書き込まれたコンポーネント値は**戻りません** (レンダラー側でリセット処理があるのは GameObject レベルのキー Active/Tag/Position/Rotation/Scale のみ)。値を維持したい間は属性を残してください。

## 属性の同一性と diff

`Attribute<T, U>` (コア) の等価性は *key + value* です。diff では:

- 同じキー・同じ値 → スキップ;
- 同じキー・違う値 → 再適用;
- 新しいキー → 適用;
- 消えたキー → 上記の GameObject レベルキーのみリセット。

1 つの属性リスト内でキーが重複した場合は**後勝ち**です (`Attributes<T>` は辞書を構築します。`V` ファクトリは `extras` を最後に置くので、生成されたデフォルトを上書きできます)。

## 属性クラスの構成

属性は**ウィジェットのネストクラス**で、コンポーネントのプロパティごとに 1 クラスです:

```
Slider.Value(0.5f)          -> slider.value = 0.5f
Graphic.Color(Color.red)    -> graphic.color = red
Text.FontSize(24)           -> text.fontSize = 24
Button.OnClick(action)      -> onClick.RemoveAllListeners(); AddListener(action)
```

各ウィジェット `Xxx` には抽象基底 `XxxAttribute<T> : GuiAttributeBase<UnityEngine.UI.Xxx, T>` もあり、同じコンポーネントを対象とするカスタム属性はこれを継承します。

特殊ケース:

- `Text.Value` — `Text.text` 用に生成される追加属性 (プロパティ名 `text` の衝突を避けて `Value`、キーは `"Value"`)。
- `Button.OnClick` — 追加前に全リスナーを削除するので、再レンダリングでハンドラが重複しません。
- 生成された `OnValueChanged` 系属性 (Slider, InputField, ScrollRect, Scrollbar, Dropdown など) は UnityEvent オブジェクトごと代入します: `component.onValueChanged = GetValue()`。

## レイアウトエイリアス (`LayoutAliases.cs`)

コードジェネレータは各型に*宣言された*プロパティの属性クラスしか生成しません。`HorizontalLayoutGroup`, `VerticalLayoutGroup`, `GridLayoutGroup` は何も宣言しておらず、プロパティは継承されたものです。`LayoutAliases.cs` が手書きのエイリアスでこのギャップを埋め、呼び出し側が自然に書けるようにしています:

| ウィジェット | エイリアス |
|---|---|
| `HorizontalLayoutGroup` / `VerticalLayoutGroup` | `Padding`, `ChildAlignment` (`LayoutGroup` 由来), `Spacing`, `ChildForceExpandWidth/Height`, `ChildControlWidth/Height`, `ChildScaleWidth/Height`, `ReverseArrangement` (`HorizontalOrVerticalLayoutGroup` 由来) |
| `GridLayoutGroup` | `Padding`, `ChildAlignment` (`LayoutGroup` 由来) |

各エイリアスは基底属性のサブクラスにすぎず (`VerticalLayoutGroup.Spacing : HorizontalOrVerticalLayoutGroup.Spacing`)、基底クラスの `GetComponent` を通じて継承プロパティに書き込みます。

## カスタム属性の書き方

既存ウィジェットのコンポーネントを対象にする:

```csharp
// 生成済みの基底を使って UnityEngine.UI.Image を対象にする
public class FillAmountPulse : Veauty.uGUI.ImageAttribute<float>
{
    public FillAmountPulse(float value) : base("fillAmountPulse", value) { }
    protected override void Apply(UnityEngine.UI.Image image)
    {
        image.fillAmount = Mathf.PingPong(GetValue(), 1f);
    }
}
```

任意のコンポーネントを対象にする:

```csharp
public class MyShadowColor : Veauty.uGUI.GuiAttributeBase<UnityEngine.UI.Shadow, Color>
{
    public MyShadowColor(Color value) : base("myShadowColor", value) { }
    protected override void Apply(UnityEngine.UI.Shadow s) => s.effectColor = GetValue();
}
```

ルール:

1. 論理プロパティごとに**一意なキー**を付ける — 同じキーの属性は同一ノード上で上書きし合います。
2. `Apply` は冪等に: 値が変わるたびに再実行されます。
3. サイレント no-op を忘れずに: `TComponent` が欠けうる型でホワイトリスト外なら、ウィジェット側 (`Init` など) で存在を保証してください。
4. キャプチャ専用の挙動は `IAttribute<GameObject>` を直接実装します ([Widget catalog](widgets.md) の `Ref<T>` を参照)。
