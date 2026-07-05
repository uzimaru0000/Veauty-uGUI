# Code Generation

[English](../code-generation.md)

`Veauty > GenerateUIClass` エディタメニュー、生成される内容、生成コードと手書きコードを分離する partial クラスパターン。

## ジェネレータの実行

Unity エディタで **Veauty > GenerateUIClass** (実装は `Lib/Editor/UIClass.cs`、アセンブリ `Veauty.uGUI.Editor`)。`Lib/Generated/` 内の全ファイルを上書きし、AssetDatabase をリフレッシュします。実行後の手動調整は不要です。

現在ロードされている `UnityEngine.UI` アセンブリをリフレクションで走査するため、出力は Unity バージョンに依存します — Unity をアップグレードしたら再生成してください。

## 走査対象

1. 名前空間 `UnityEngine.UI` の、公開・可視な `MonoBehaviour` サブクラス全型 (+ `ExtraTypes` 候補の `Canvas`, `CanvasGroup`, `RectTransform`);
2. そこから **ManualTypes スキップリスト** (`Canvas`, `CanvasGroup`, `RectTransform`) を除外 — これらのウィジェットは `Lib/` に手書きされています (現在のリスト構成では ExtraTypes は実質何も追加しません。意図を示すための記述です);
3. 型ごとに、**宣言された** (継承ではない)、公開・書き込み可能・非 Obsolete・非インデクサのインスタンスプロパティ。PascalCase 名が型名と一致するプロパティは除外。

「宣言のみ」であることが、`Button` の属性が `OnClick` 1 つだけである理由、そしてレイアウトグループの継承プロパティに `LayoutAliases.cs` が必要な理由です。

## 生成される内容 (型ごとに 1 ファイル `Lib/Generated/<Name>.cs`)

```csharp
// THIS CODE IS AUTO GENERATED

/// <summary>Base class for <see cref="Xxx"/> attributes, ...</summary>
public abstract class XxxAttribute<T> : GuiAttributeBase<UnityEngine.UI.Xxx, T> { ... }

/// <summary>Veauty widget for <see cref="UnityEngine.UI.Xxx"/>.</summary>
public partial class Xxx : GUIBase<UnityEngine.UI.Xxx>
{
    public Xxx(IEnumerable<IAttribute<UnityEngine.GameObject>> attrs, params IVTree[] kids)
        : base(attrs, kids) { }

    /// <summary>Sets <see cref="UnityEngine.UI.Xxx.propName"/>.</summary>
    public class PropName : XxxAttribute<PropType>
    {
        public PropName(PropType value) : base("propName", value) { }
        protected override void Apply(UnityEngine.UI.Xxx component)
        {
            component.propName = this.GetValue();
        }
    }
    // ... プロパティごとに 1 クラス
}
```

XML ドキュメントコメント (ウィジェットの summary、属性基底の summary、プロパティごとの `Sets <see cref=.../>` summary、コンストラクタのドキュメント) はジェネレータ自身が出力します。

特殊ケースのテンプレート:

| ケース | 代わりに生成されるもの |
|---|---|
| `Button.onClick` | `OnClick` — `RemoveAllListeners()` してから `AddListener(value)` |
| `InputField.onValueChange` | `OnValueChange` — `onValueChanged` に代入 (レガシーなプロパティ名。`onValueChange` を宣言している Unity バージョンでのみ生成される) |
| `Text` | `Text.text` にマッピングされる追加の `Value` 属性 (先頭に挿入) |

## partial クラス + Initializers パターン

生成されるウィジェットクラスは `partial` です。生成できないものはすべて、ジェネレータが触らない手書きの partial パートにあります:

| 場所 | 内容 |
|---|---|
| `Lib/Generated/*.cs` | コンストラクタ + 属性クラスのみ (丸ごと再生成される) |
| `Lib/Initializers/*.Init.cs` | `Init` / `AfterRenderKids` / `GetKids` オーバーライド、サブコンポーネントクラス、ファクトリメソッド |
| `Lib/LayoutAliases.cs` | partial なレイアウトグループ型の継承属性エイリアス |

この分離により再生成は常に安全です: `Lib/Generated/` を消して作り直しても手書きコードは失われません。

## `Lib/Generated/` を手で編集しない

手動の変更は次回実行時に失われます。カスタマイズは:

- ライフサイクル → `Lib/Initializers/` に partial クラスを追加・拡張;
- 追加属性 → 手書き partial パートに新クラス (`XxxAttribute<T>` を継承);
- 型を生成対象から外す → `ManualTypes` に追加して `Lib/` に手書き。
