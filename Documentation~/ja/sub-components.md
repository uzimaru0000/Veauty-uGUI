# Sub-Components

[English](../sub-components.md)

`ISubComponent` システム: 複合ウィジェット (Slider, Toggle, Scrollbar, InputField) が内部パーツを宣言する仕組み。

## コンセプト

Slider のようなコントロールには、あなたの UI ツリーの一部では*ない*内部構造 (トラック、フィル、ハンドル) が必要です。Veauty-uGUI は各パーツを**サブコンポーネント** — `IVTree` とマーカーインターフェース `ISubComponent` の両方を実装する小さなイミュータブルな設定オブジェクト — としてモデル化します。

```csharp
public interface ISubComponent { }   // マーカーのみ
```

サブコンポーネントは:

- 通常の `kids` としてウィジェットのコンストラクタに渡されます;
- kids 配列に収まるためだけに `IVTree` を実装します (`GetNodeType()` は `Node`、`GetDescendantsCount()` は 0 を返す)。**VTree パイプラインでレンダリングされることはありません**;
- ウィジェットの `Init` で `FindPart<T>()` により読み取られ (最初の一致が使われる — 同じパーツを 2 つ渡すと先頭が有効)、`CreateChild`/`AddVisual` で内部 GameObject に変換されます。

## `GetKids()` フィルタと childOffset

サブコンポーネントを持つウィジェットは `GetKids()` をオーバーライドします:

```csharp
public override IVTree[] GetKids()
{
    // !(kid is ISubComponent) の kids を返す。初回呼び出し後はキャッシュ
}
```

その帰結:

- diff/patch はサブコンポーネントを見ない (ノードではなく設定だから);
- `GetDescendantsCount()` はコンテンツ子のみを数える;
- パッチャーは仮想子 *i* を `transform.GetChild(childOffset + i)` (`childOffset = childCount - kids.Length`) にマッピングし、`Init` が作った内部 GameObject をスキップする。これは `Init` がコンテンツ子のレンダリング前に実行されるから成立します。

レンダリング間でサブコンポーネントの設定を変えても内部オブジェクトは**パッチされません** — サブコンポーネントは `Init` 時に一度だけ消費されます。内部パーツを動的にスタイリングしたい場合は、ウィジェットに key を付けて再マウントさせるか、`Ref<T>` でオブジェクトをキャプチャして自分で変更してください。

## カタログとハードコードされたデフォルト

画像系パーツのデフォルトはすべて `imageType: Image.Type.Simple`、`sprite: null` です。

### Slider (`Slider.Init.cs`)

| パーツクラス | ファクトリ | デフォルト色 | 生成される構造 |
|---|---|---|---|
| `Slider.SliderBackground` | `Slider.Background(sprite, color, imageType)` | RGB (0.30, 0.32, 0.38) | ストレッチされた "Background" 画像 |
| `Slider.SliderFill` | `Slider.Fill(sprite, color, imageType)` | RGB (0.22, 0.55, 0.95) | "Fill Area" (アンカー y 0.25–0.75、x 内側 5px) 内の "Fill"; `fillRect` に配線 |
| `Slider.SliderHandle` | `Slider.Handle(sprite, color, imageType)` | white | "Handle Slide Area" (x 内側 10px) 内の幅 20px の "Handle"; `handleRect` + `targetGraphic` に配線 |

### Toggle (`Toggle.Init.cs`)

| パーツクラス | ファクトリ | デフォルト色 | 生成される構造 |
|---|---|---|---|
| `Toggle.ToggleBackground` | `Toggle.Background(sprite, color, imageType)` | RGB (0.22, 0.24, 0.28) | 左アンカー・幅 24px の "Background"; `targetGraphic` に配線 |
| `Toggle.ToggleCheckmark` | `Toggle.Checkmark(sprite, color, imageType)` | RGB (0.2, 0.75, 0.4) | Background 内の "Checkmark" (15% インセット); `graphic` に配線 |

注: Checkmark は Background パーツもあるときにだけ生成されます (その中にネストするため)。

### Scrollbar (`Scrollbar.Init.cs`)

| パーツクラス | ファクトリ | デフォルト色 | 生成される構造 |
|---|---|---|---|
| `Scrollbar.ScrollbarHandlePart` | `Scrollbar.Handle(sprite, color, imageType)` | RGB (0.5, 0.5, 0.5) | ストレッチされた "Sliding Area" 内の "Handle"; `handleRect` + `targetGraphic` に配線 |

さらに `Scrollbar.Init` はサブコンポーネントに関係なく、Scrollbar 自体に背景 `Image` (RGB 0.22, 0.24, 0.28) がなければ追加します。

### InputField (`InputField.Init.cs`)

| パーツクラス | ファクトリ | デフォルト | 生成される構造 |
|---|---|---|---|
| `InputField.InputFieldPlaceholderPart` | `InputField.PlaceholderText(text, color, fontSize, alignment)` | text "Enter text...", RGBA (0.5, 0.5, 0.5, 0.75), サイズ 16, MiddleLeft | イタリックの "Placeholder" テキスト; `placeholder` に配線 |
| `InputField.InputFieldTextPart` | `InputField.TextDisplay(color, fontSize, alignment)` | white, サイズ 16, MiddleLeft | "Text" (リッチテキスト無効); `textComponent` に配線 |

両者は `RectMask2D` 付きの "Text Area" 子 (インセット 10px/2px) の中に入ります。`InputField.Init` は背景 `Image` (RGB 0.16, 0.18, 0.22) がなければ追加して `targetGraphic` に配線します。両テキストは組み込みの `LegacyRuntime.ttf` を使います。

## Base API と Presets API

| | Base (`Veauty.uGUI`) | Presets (`Veauty.uGUI.Presets`) |
|---|---|---|
| サブコンポーネント | **必須** — 渡さなかったパーツは生成されない (例: `new Slider(attrs)` はビジュアルなしでレンダリングされる) | **任意** — 不足する必須パーツはデフォルトで自動注入 |
| 1 パーツだけカスタム | そのパーツと残りすべてを明示的に渡す | そのパーツだけ渡せば残りはデフォルト |

```csharp
// Base: すべて明示
using Veauty.uGUI;
new Slider(attrs,
    Slider.Background(sprite: trackSprite),
    Slider.Fill(color: Color.red),
    Slider.Handle());

// Presets: Fill だけ上書き
using Veauty.uGUI.Presets;
V.Slider(value: 0.5f)[ Slider.Fill(color: Color.red) ];
```

自動注入アルゴリズム (子を走査 → 不足パーツ追加 → パーツをコンテンツより前に) は [Presets API](presets.md) を参照。

## 自作ウィジェットにサブコンポーネントを追加する

1. readonly な設定フィールドを持つネストクラス `class MyPart : IVTree, ISubComponent` を定義し、`IVTree` メンバーからは `VTreeType.Node` / 0 を返す。
2. 静的ファクトリを追加 (`public static IVTree Part(...) => new MyPart(...)`)。
3. `GetKids()` をオーバーライドして `ISubComponent` を除外 (配列をキャッシュ)。
4. `Init` で `FindPart<MyPart>()` を呼び、`CreateChild` / `AddVisual` / `Stretch` / `SetupRect` で内部 GameObject を構築。
5. 必要ならコンテンツ子に依存する配線のために `AfterRenderKids` をオーバーライド。
