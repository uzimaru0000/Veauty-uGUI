# Veauty-uGUI

Veauty で Unity の uGUI を宣言的に構築するためのウィジェット・属性パッケージ。

## 要件

- Unity 6000.5 以上 (Unity 6)
- `com.uzimaru.veauty`
- `com.uzimaru.veauty-gameobject`

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

## 基本的な使い方

Canvas 配下の GameObject に `VeautyObject` をマウントして uGUI を構築します。

```csharp
using UnityEngine;
using Veauty;
using Veauty.GameObject;
using Veauty.uGUI.Presets;

public class CounterPanel : MonoBehaviour
{
    private VeautyObject app;

    void Start()
    {
        this.app = new VeautyObject(this.gameObject, Render);
    }

    static IVTree Render()
    {
        var count = Hooks.UseState(0);
        return V.VLayout(spacing: 12f)[
            CountDisplay(count.Value),
            V.Button(onClick: () => count.Set(x => x + 1))[
                V.Text("Increment", fontSize: 24, color: Color.white)
            ]
        ];
    }

    [Component]
    static IVTree CountDisplay(int value)
    {
        Hooks.UseEffect(() =>
        {
            Debug.Log($"Count changed to {value}");
            return () => Debug.Log("CountDisplay unmounted");
        }, new object[] { value });

        return V.Text($"Count: {value}", fontSize: 32, color: Color.white);
    }
}
```

## 2 つの API レベル

### Presets API (`Veauty.uGUI.Presets`)

`V` クラスのファクトリメソッドでデフォルト値付きのウィジェットを簡潔に記述できます。`[]` インデクサで子要素を指定します。

```csharp
using Veauty.uGUI.Presets;

V.VLayout(spacing: 8f, padding: new RectOffset(16, 16, 12, 12))[
    V.Text("Hello", fontSize: 24, color: Color.white),
    V.Image(color: Color.gray, preferredHeight: 2f),
    V.Button(onClick: () => { /* ... */ })[
        V.Text("Click me")
    ],
    V.Slider(value: 0.5f),
    V.Toggle(isOn: true)[
        V.Text("Enable")
    ]
]
```

### Base API (`Veauty.uGUI`)

すべてのパラメータを明示的に指定する低レベル API。サブコンポーネント (Slider の Handle, Toggle の Checkmark 等) も明示的に構成します。

```csharp
using Veauty.uGUI;

new Slider(attrs,
    Slider.Background(sprite: trackSprite),
    Slider.Fill(color: Color.red),
    Slider.Handle()
)
```

## ウィジェット一覧

| ウィジェット | サブコンポーネント |
|------------|-------------------|
| `Button` | - |
| `Text` | - |
| `Image` | - |
| `InputField` | `PlaceholderText()`, `TextDisplay()` |
| `Toggle` | `Background()`, `Checkmark()` |
| `Slider` | `Background()`, `Fill()`, `Handle()` |
| `Scrollbar` | `Handle()` |
| `ScrollRect` | - |
| `Dropdown` | - |
| `HorizontalLayoutGroup` | - |
| `VerticalLayoutGroup` | - |
| `GridLayoutGroup` | - |

## 自動追加される属性コンポーネント

以下の属性は、対象の uGUI ノードにコンポーネントが存在しない場合自動的に追加されます:

`LayoutElement`, `ContentSizeFitter`, `AspectRatioFitter`, `CanvasGroup`, `Shadow`, `Outline`, `PositionAsUV1`

## RectTransform

```csharp
V.Image(extras: new IAttribute<GameObject>[] {
    new RectTransform.AnchorMin(Vector2.zero),
    new RectTransform.AnchorMax(Vector2.one),
    new RectTransform.OffsetMin(new Vector2(16f, 16f)),
    new RectTransform.OffsetMax(new Vector2(-16f, -16f))
})
```

## ドキュメント

- [マニュアル](Documentation~/ja/com.uzimaru.veauty-ugui.md) — フルマニュアル (getting started, architecture, presets, widgets, sub-components, attributes, code generation)
- [API リファレンス](Documentation~/ja/api-reference.md) — 公開 API 全体
- [AGENTS.md](AGENTS.md) — LLM コーディングエージェント向けガイド (英語)
- [CHANGELOG.md](CHANGELOG.md) — 更新履歴 (英語)

## 注意事項

uGUI を使うには Canvas, GraphicRaycaster, EventSystem がシーンに必要です。Veauty-uGUI はこれらを自動生成しないので、シーンまたはブートストラップコードで用意してください。
