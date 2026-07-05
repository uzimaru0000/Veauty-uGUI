# Architecture

[English](../architecture.md)

Veauty-uGUI が仮想ツリーをどのように uGUI GameObject に変換し、更新をどのようにその場でパッチするか。

## レイヤー構成

```
+--------------------------------------------------+
| ユーザーコード: V.VLayout(...)[ V.Button(...) ]  |   Veauty.uGUI.Presets
+--------------------------------------------------+
| ウィジェット: GUIBase<T> ノード + 属性クラス      |   Veauty.uGUI (本パッケージ)
+--------------------------------------------------+
| Renderer / Patch / VeautyObject / HostBridge     |   Veauty.GameObject
+--------------------------------------------------+
| IVTree, Diff, Hooks, FunctionComponents          |   Veauty (コア)
+--------------------------------------------------+
```

本パッケージが提供するのは上 2 段 — **ウィジェットノード型**と**属性** — だけです。レンダリング・差分・パッチは依存パッケージにあります。

## ウィジェットとは

各ウィジェット (例: `Button`, `Slider`, `VerticalLayoutGroup`) は `GUIBase<T>` です:

- **tag** が `typeof(T).FullName` の `Node<GameObject, T>` — コンポーネント型が違えば diff は別タグとみなしサブツリーを置き換えます;
- `Init`, `AfterRenderKids`, `Destroy` の 3 フックを持つ `IHostLifecycle<GameObject>`。

## 1 ウィジェットノードのレンダリングサイクル

```
Renderer.Render(tree)
  |
  v
[GameObjectHostBridge.Mount]
  1. CreateGameObject(tag)          -- uGUI モードではストレッチ RectTransform 付き
  2. AttachComponent(typeof(T))     -- 例: UnityEngine.UI.Slider
  3. widget.Init(go)                -- 内部子オブジェクトの生成 (Background, Fill, Handle...)
  4. ApplyProps(attrs)              -- 各 IAttribute<GameObject>.Apply(go)
  |
  v
RenderKids(go, widget.GetKids())    -- コンテンツ子のレンダリング (サブコンポーネント除外)
  |
  v
widget.AfterRenderKids(go)          -- 例: ScrollRect が content を配線
```

アンマウント時は `Destroy` がウィジェット自身と (逆順で再帰的に) 子に対して呼ばれます。

## コンテンツ子と内部子

複合ウィジェットの GameObject には 2 種類の子があります:

- `Init` が生成する**内部子** (Slider の "Background", "Fill Area", "Handle Slide Area"、InputField の "Text Area"、Dropdown のテンプレート全体)。これらは *VTree から見えません*。
- `GetKids()` からレンダリングされる**コンテンツ子** (`[...]` に入れたもの)。

`Init` は `RenderKids` より先に実行されるため、内部子は常に `transform` の先頭に並びます。パッチャーはこの順序を利用します:

```
childOffset = go.transform.childCount - kids.Length
仮想子 i  <->  transform.GetChild(childOffset + i)
```

これが以下の理由です:

1. Slider/Toggle/Scrollbar/InputField の `GetKids()` は `ISubComponent` を除外し (設定であって子ではない)、結果をキャッシュする;
2. `GUIBase<T>` の `GetDescendantsCount()` は `GetKids()` のみを数え、diff の走査インデックスを一貫させる;
3. 内部子をコンテンツ子の後に追加してはならない — `Init` の中でのみ生成する。

## 属性の適用

属性はキー付きの値 (`GuiAttributeBase<TComponent, TValue>`) です。適用時:

```
component = go.GetComponent<TComponent>()
if component == null かつ TComponent がホワイトリスト内: component = go.AddComponent<TComponent>()
if component != null:                                    Apply(component)
else:                                                    (何も起きない)
```

ホワイトリスト: `LayoutElement`, `ContentSizeFitter`, `AspectRatioFitter`, `CanvasGroup`, `Shadow`, `Outline`, `PositionAsUV1`。詳細と注意点は [Attribute system](attributes.md)。

diff では、キー**と**値が等しい属性は等価 (`Attribute<T,U>.Equals`) とみなされ、変更された属性だけ再適用されます。旧ツリーにあって新ツリーにない属性は、GameObject レベルの固定キー (Active, Tag, Position, Rotation, Scale) のみリセットされます — uGUI 属性が書いたコンポーネント値は**自動では戻りません**。値を維持したい間は属性をツリーに残してください。

## 更新サイクル

```
状態変更 (Hooks / setState)
  -> render 関数の実行          -> 新しい IVTree
  -> Diff.Calc(old, new)        -> IPatch[]
  -> Patch.Apply(root, patches) -> 最小限の GameObject 変更
```

`VeautyObject` は再入更新をまとめます: レンダリング中の状態変更はフラグを立てるだけで、完了後に 1 回だけ再レンダリングします。

## Presets 層

`V.Xxx(...)` はオプション引数から属性配列を組み立てて `Element` — `IVTreeWrapper` を実装する遅延ファクトリ — を返します。レンダラーは Element を透過的に unwrap します:

- `element[child1, child2]` → 子付きでファクトリを呼ぶ (毎回実行、キャッシュなし);
- `element` を直接 `IVTree` として使用 → `Unwrap()` が子なしで呼ばれる (Element インスタンスごとに**キャッシュ**)。

[Presets API](presets.md) を参照。

## ファイルレイアウト

```
Lib/
  GUIBase.cs             GUIBase<T>, ISubComponent, ImageStyle, GuiAttributeBase
  Element.cs, V.cs       Veauty.uGUI.Presets 名前空間
  Canvas.cs, CanvasGroup.cs, RectTransform.cs   手書きウィジェット
  Ref.cs                 Ref<T> キャプチャ属性 (+ グローバル名前空間エイリアス)
  LayoutAliases.cs       partial なレイアウトグループの継承属性エイリアス
  Generated/             自動生成ウィジェット (編集禁止)
  Initializers/          手書きの Init/AfterRenderKids + サブコンポーネント型
  Editor/UIClass.cs      コードジェネレータ (Veauty > GenerateUIClass)
```
