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

        var parent = new GameObject("TileParent");

        foreach (var position in Positions(tilemap.size))
        {
            var tile = tilemap.GetTile(position);
            if (tile != null)
            {
                var worldPosition = tilemap.CellToWorld(position) + tilemap.tileAnchor;
                var matrix = tilemap.GetTransformMatrix(position);
                var spriteRenderer = GameObject.Instantiate(
                    spritePrefab, worldPosition, matrix.rotation, parent.transform);

                spriteRenderer.sprite = tilemap.GetSprite(position);
            }
        }
    }

    static IEnumerable<Vector3Int> Positions(Vector3Int size)
    {
        for (int x = -size.x; x <= size.x; x++)
        {
            for (int y = -size.y; y <= size.y; y++)
            {
                for (int z = -size.z; z <= size.z; z++)
                {
                    yield return new Vector3Int(x, y, z);
                }
            }
        }
    }
}
