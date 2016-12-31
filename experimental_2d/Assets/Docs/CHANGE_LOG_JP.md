# リリース1 -> リリース2

https://forum.unity3d.com/threads/2d-experimental-preview-release-2.427253/ より、意訳。

## 改善

* GameObjectのグリッドへのスナッピング
* パレットのショートカット
    * B - ペイント
    * U - 矩形埋め
    * I - ピック
    * D - 消去
    * G - Flood Fill(?)
    * , (Comma) - 左回転
    * . (Period) - 右回転
    * Shift + , (Comma) - 垂直方向反転
    * Shift + . (Period) - 水平方向反転
* タイルマップの多層ペインティング
* パレットからタイルアセット選択のためのトグル

## 破壊的な変更

2D Experimental Preview Release 2のTileMap関連の破壊的変更

* Tile Map APIは、UnityEngine名前空間 -> UnityEngine.TileMap名前空間 に
* 名称変更 VirtualTiles -> EditorPreviewTiles に
* 名称変更 BaseTile -> TileBase に
* 名称変更 TileFlags
   * OverrideColor -> LockColor に
   * OverrideTransform -> LockTransform に
   * OverrideSpawnGameObjectRuntimeOnly -> InstantiateGameObjectRuntimeOnly に
   * OverrideAll -> LockAll に
* TileData
   * TileData.gameobject -> TileData.gameObject に
* TileAnimationData
   * TileAnimationData.animationTimeOffset -> TileAnimationData.animationStartTime に
* TileMap向けのコライダーのPolygonCollider2Dは無くなりました。代わりにTileMapCollider2Dを使います。