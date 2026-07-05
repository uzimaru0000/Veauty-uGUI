# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.5.1] - 2026-07-06

### Added
- Package documentation under `Documentation~/` (manual, getting started, architecture, presets, widgets, sub-components, attributes, code generation, API reference) with Japanese translations under `Documentation~/ja/`.
- XML documentation comments (`///`) on all public APIs in hand-written `Lib/` files.
- `AGENTS.md`, `CLAUDE.md`, and `llms.txt` for coding agents.
- This changelog.
- `license` field (MIT) in `package.json`.

### Changed
- `UIClass.cs` code generator now emits XML documentation comments; `Lib/Generated/` regenerated (nested attribute classes are no longer `partial`, matching the current generator template).
- README: added Documentation section.
- Dependencies `com.uzimaru.veauty` / `com.uzimaru.veauty-gameobject` now reference `v0.5.1`.

## [0.5.0] - 2025

### Added
- Composition-based sub-components (`ISubComponent`) for Slider, Toggle, Scrollbar, and InputField, with factory methods (`Slider.Background/Fill/Handle`, `Toggle.Background/Checkmark`, `Scrollbar.Handle`, `InputField.PlaceholderText/TextDisplay`) and Base/Presets namespace separation (`Veauty.uGUI` vs `Veauty.uGUI.Presets`).
- Presets DSL: static `V` factory (`V.Text/Button/Image/VLayout/HLayout/Grid/Toggle/Slider/Scrollbar/ScrollRect/InputField/Dropdown/...`) and `Element` builder with a single `params` indexer for children (replacing earlier indexer overloads and `Of()`).
- Sub-component auto-injection with default styles in `V.Toggle`, `V.Slider`, `V.Scrollbar`, `V.InputField`.
- Hand-written widgets and attributes for `Canvas`, `CanvasGroup`, `RectTransform`; layout attribute aliases (`Padding`, `ChildAlignment`, `Spacing`, etc.) for `HorizontalLayoutGroup`/`VerticalLayoutGroup`/`GridLayoutGroup`; Editor asmdef.
- Visual `Init` for interactive controls (Button targetGraphic, Scrollbar/InputField backgrounds, Dropdown full template) and `Text` default font (`LegacyRuntime.ttf`).
- Layout element attribute application (`LayoutElement` auto-add) and uGUI API coverage tests.
- Hook setter and event cleanup tests.

### Changed
- `GUIBase<T>` ported to `Node` + `IHostLifecycle` (from the old Widget base).
- Minimum Unity version raised to 6000.5 (Unity 6).
- `ScrollRect.Init` sets up `Image`, `RectMask2D`, and the `content` reference in `AfterRenderKids`.
- README rewritten in English with a Japanese `README.ja.md`.
- InputField supports the Unity 6000 API.

### Fixed
- Dropdown items invisible due to Mask viewport alpha = 0.
- Dropdown template layout and color contrast.
- Slider track visibility (lighter background color).

## [0.4.0]

### Added
- Generated uGUI widget classes for the full `UnityEngine.UI` surface via the `Veauty > GenerateUIClass` code generator (`Lib/Generated/`).

## [0.1.0]

### Added
- Initial release: `GUIBase` widget base class, `GuiAttributeBase` attribute base, `Text`/`Button` components, `Graphic` attributes, `Image`/`RawImage` widgets and attributes.
