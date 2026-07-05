# Veauty-uGUI

[English](../com.uzimaru.veauty-ugui.md)

Veauty — Unity 向けの React ライクな Virtual DOM — で Unity uGUI を宣言的に構築するためのウィジェット・属性パッケージ。

`com.uzimaru.veauty-ugui` は Veauty ファミリーの uGUI バインディング層です。`UnityEngine.UI` のすべての公開コンポーネントを型付き属性クラス付きの VTree ウィジェットクラスにマッピングし、複合コントロール (Slider, Toggle, Scrollbar, InputField) 向けのコンポジション型サブコンポーネントを提供し、デフォルト値を自動補完する `V` ファクトリを備えています。

## 要件

- Unity 6000.5 以上 (Unity 6)
- [`com.uzimaru.veauty`](https://github.com/uzimaru0000/Veauty) — VTree / Diff / Patch のコア
- [`com.uzimaru.veauty-gameobject`](https://github.com/uzimaru0000/Veauty-GameObject) — GameObject レンダラーとマウントポイント `VeautyObject`

## インストール

`Packages/manifest.json` に追加:

```json
{
  "dependencies": {
    "com.uzimaru.veauty": "https://github.com/uzimaru0000/Veauty.git",
    "com.uzimaru.veauty-gameobject": "https://github.com/uzimaru0000/Veauty-GameObject.git",
    "com.uzimaru.veauty-ugui": "https://github.com/uzimaru0000/Veauty-uGUI.git"
  }
}
```

## クイックスタート

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

このスクリプトを Canvas 配下の GameObject (シーンに EventSystem があること) にアタッチして Play してください。

## 2 つの API レベル

| 名前空間 | レベル | 説明 |
|---|---|---|
| `Veauty.uGUI` | Base | すべてのウィジェット・属性を明示的に指定。複合コントロールのサブコンポーネントは必須 |
| `Veauty.uGUI.Presets` | Presets | `V` ファクトリ + `Element` のインデクサ構文。デフォルト値とサブコンポーネントを自動補完 |

## マニュアル

- [Getting started](getting-started.md) — インストール、最小構成の例、逐行解説
- [Architecture](architecture.md) — レンダリングサイクル、ウィジェットライフサイクル、childOffset の仕組み
- [Presets API](presets.md) — `V` ファクトリ、`Element` ビルダー、自動注入のルール
- [Widget catalog](widgets.md) — 全ウィジェット (手書き + 生成)、ライフサイクルフック、`Ref<T>`
- [Sub-components](sub-components.md) — `ISubComponent` システム、ファクトリメソッド、デフォルトスタイル
- [Attribute system](attributes.md) — `GuiAttributeBase`、自動追加ホワイトリスト、サイレント no-op の注意点、カスタム属性
- [Code generation](code-generation.md) — `Veauty > GenerateUIClass` メニューと partial クラスパターン
- [API reference](api-reference.md) — 公開 API 全体を 1 ファイルに集約

## 注意事項

uGUI を使うには Canvas, GraphicRaycaster, EventSystem がシーンに必要です。Veauty-uGUI はこれらを**自動生成しません** — シーンまたはブートストラップコードで用意してください。
