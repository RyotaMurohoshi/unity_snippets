using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using System.Collections.Generic;

public class TilemapConvertor
{
    [MenuItem("Assets/Convert TileMap to Sprites")]
    public static void Convert()
    {
        var grid = Selection.objects.OfType<GameObject>().Select(it => it.GetComponent<Grid>()).First();

        foreach (var tilemap in grid.GetComponentsInChildren<Tilemap>())
        {
            Update(tilemap);
        }
    }

    static void Update(Tilemap tilemap)
    {
        var spritePrefab = Resources.Load<SpriteRenderer>("TileSpriteRenderer");

        var parent = new GameObject("TileParent").transform;
        var tileAnchor = tilemap.tileAnchor;
        var tilemapRotation = tilemap.orientationMatrix.rotation;

        foreach (var position in Positions(tilemap.cellBounds))
        {
            if (tilemap.HasTile(position))
            {
                var tile = tilemap.GetTile(position);
                var spriteRotation = tilemap.GetTransformMatrix(position).rotation;
                var rotation = tilemapRotation * spriteRotation;
                var localPosition = tilemap.CellToLocal(position) + tileAnchor;
                var spriteRenderer = GameObject.Instantiate(
                    spritePrefab,
                    localPosition,
                    rotation,
                    parent);

                spriteRenderer.name = position.ToString();
                spriteRenderer.sprite = tilemap.GetSprite(position);
            }
        }
    }

    static IEnumerable<Vector3Int> Positions(BoundsInt bounds)
    {
        for (int x = bounds.xMin; x <= bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y <= bounds.yMax; y++)
            {
                for (int z = bounds.zMin; z <= bounds.zMax; z++)
                {
                    yield return new Vector3Int(x, y, z);
                }
            }
        }
    }
}
