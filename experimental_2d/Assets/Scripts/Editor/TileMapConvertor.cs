using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TilemapConvertor
{
    [MenuItem("Assets/Convert TileMap to Sprites")]
    public static void Convert()
    {
        foreach (var grid in GameObject.FindObjectsOfType<Grid>())
        {
            foreach (var tilemap in grid.GetComponentsInChildren<Tilemap>())
            {
                CreateTilemap(tilemap);
            }
        }
    }

    static void CreateTilemap(Tilemap tilemap)
    {
        var spritePrefab = Resources.Load<SpriteRenderer>("TileSpriteRenderer");

        var parent = new GameObject("TileParent").transform;
        var tilemapRotation = tilemap.orientationMatrix.rotation;
        var tileAnchor = tilemap.orientationMatrix.MultiplyPoint(tilemap.tileAnchor);

        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(position))
            {
                var matrix = tilemap.orientationMatrix * tilemap.GetTransformMatrix(position);
                var localPosition = tilemap.CellToWorld(position) + tileAnchor;
                var spriteRenderer = GameObject.Instantiate(
                    spritePrefab,
                    localPosition,
                    matrix.rotation,
                    parent);

                spriteRenderer.transform.localScale = matrix.scale;
                spriteRenderer.name = position.ToString();
                spriteRenderer.sprite = tilemap.GetSprite(position);
            }
        }
    }
}
