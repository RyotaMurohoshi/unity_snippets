# Release1 -> Release2

From https://forum.unity3d.com/threads/2d-experimental-preview-release-2.427253/

## Improvements

* Snapping of GameObjects to Grid
* Hotkeys for Palette
    * B - Paint
    * U - Box Fill
    * I - Pick
    * D - Erase
    * G - Flood Fill
    * , (Comma) - Rotate Tile Left
    * . (Period) - Rotate Tile Right
    * Shift + , (Comma) - Flip Tile Vertical
    * Shift + . (Period) - Flip Tile Horizontal
* Multilayer painting for Tile Map
* Toggle for selecting Tile Asset from palette

## Breaking Changes
Breaking changes for 2D Experimental Preview Release 2 TileMap

* Tile Map APIs have been changed, please do update your existing scripts.
* Tile Map APIs have been moved to its own namespace UnityEngine.TileMap.
* VirtualTiles have been renamed to EditorPreviewTiles.
* BaseTile has been renamed to TileBase.
* TileFlags have been renamed.
   * OverrideColor -> LockColor
   * OverrideTransform -> LockTransform
   * OverrideSpawnGameObjectRuntimeOnly -> InstantiateGameObjectRuntimeOnly
   * OverrideAll -> LockAll
* TileData
   * TileData.gameobject -> TileData.gameObject
* TileAnimationData
   * TileAnimationData.animationTimeOffset -> TileAnimationData.animationStartTime
* PolygonCollider2D no longer generates a collider shape for the TileMap. Please use the new TileMapCollider2D instead.