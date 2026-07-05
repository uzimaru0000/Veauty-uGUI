# Getting Started

[English](../getting-started.md)

Veauty-uGUI をインストールし、最初の宣言的 uGUI パネルを作ります。

## 1. インストール

`Packages/manifest.json` に 3 つの Veauty パッケージを追加します (Unity 6000.5+):

```json
{
  "dependencies": {
    "com.uzimaru.veauty": "https://github.com/uzimaru0000/Veauty.git",
    "com.uzimaru.veauty-gameobject": "https://github.com/uzimaru0000/Veauty-GameObject.git",
    "com.uzimaru.veauty-ugui": "https://github.com/uzimaru0000/Veauty-uGUI.git"
  }
}
```

## 2. シーンの準備

Veauty-uGUI は既存の uGUI 環境の*中に*レンダリングします。環境自体は作りません。必要なもの:

1. **Canvas** (通常どおり `CanvasScaler`/`GraphicRaycaster` 付き)
2. **EventSystem** (クリック・入力・スクロール用)
3. Canvas 配下の**マウント用 GameObject** — Veauty が管理するパネル。`RectTransform` があると自動的に uGUI モードになります。

## 3. 最小構成の例

```csharp
using UnityEngine;
using Veauty;                 // IVTree, Hooks, IAttribute
using Veauty.GameObject;      // VeautyObject
using Veauty.uGUI.Presets;    // V, Element

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

        return V.VLayout(spacing: 12f, padding: new RectOffset(16, 16, 16, 16))[
            V.Text($"Count: {count.Value}", fontSize: 32, color: Color.white),
            V.Button(onClick: () => count.Set(x => x + 1), preferredHeight: 48f)[
                V.Text("Increment", fontSize: 24, color: Color.white)
            ],
            V.Slider(value: Mathf.Clamp01(count.Value / 10f), interactable: false)
        ];
    }
}
```

## 4. 逐行解説

- `new VeautyObject(this.gameObject, Render)` — `this.gameObject` 配下に render 関数をマウントします。マウント対象が `RectTransform` を持つため、生成される GameObject にもストレッチされた `RectTransform` が付きます (uGUI モード)。初回レンダリングはコンストラクタ内で同期的に行われます。
- `Hooks.UseState(0)` — コアパッケージの Hooks による状態。`count.Set(...)` を呼ぶと `Render` が再実行され、新旧ツリーの差分だけがパッチされます。
- `V.VLayout(spacing: 12f, ...)` — `VerticalLayoutGroup` ウィジェットを生成。`VLayout` は常に `ChildControlWidth/Height = true` と `ChildForceExpandHeight = false` を強制するため、子は自然なサイズになります。
- `[...]` — 返された `Element` のインデクサで子要素を渡し、最終的な `IVTree` を得ます。
- `V.Button(onClick: ...)` — `Button` を生成。`Init` が Graphic のないノードに `Image` を追加して `targetGraphic` に設定します。`OnClick` 属性は追加前に既存リスナーをすべて削除するので、再レンダリングでハンドラが重複しません。
- `V.Text(...)` — レガシー `UnityEngine.UI.Text` を生成。デフォルトフォント (`LegacyRuntime.ttf`) が自動設定されます。
- `V.Slider(value: ...)` — サブコンポーネントを渡していないので、デフォルトの `Slider.Background()`, `Slider.Fill()`, `Slider.Handle()` が組み込み色で自動注入されます。

## 5. 複合コントロールのカスタマイズ

一部だけ変えたい場合はサブコンポーネントを子として渡します:

```csharp
V.Slider(value: 0.5f)[
    Slider.Fill(color: Color.red)      // Fill だけカスタム、Background/Handle はデフォルト
]
```

または Base API (`using Veauty.uGUI;`) に降りて、すべてを明示します:

```csharp
new Slider(attrs,
    Slider.Background(sprite: trackSprite),
    Slider.Fill(color: Color.red),
    Slider.Handle())
```

## 次のステップ

- [Presets API](presets.md) — `V` でできることと自動補完の内容
- [Widget catalog](widgets.md) — ウィジェット一覧
- [Attribute system](attributes.md) — サイレント no-op の注意点を含む
- [Architecture](architecture.md) — レンダリングとパッチの仕組み
