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
            var gridGameObject = new GameObject("Grid");

            foreach (var tilemap in grid.GetComponentsInChildren<Tilemap>())
            {
                CreateTilemap(tilemap, gridGameObject);
            }
        }
    }

    static void CreateTilemap(Tilemap tilemap, GameObject gridGameObject)
    {
        var spritePrefab = Resources.Load<SpriteRenderer>("TileSpriteRenderer");

        var parent = new GameObject("TileParent").transform;
        parent.transform.parent = gridGameObject.transform;

        var tilemapRotation = tilemap.orientationMatrix.rotation;
        var tileAnchor = CalculateTilemapAnchor(tilemap);

        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(position))
            {
                var matrix = tilemap.orientationMatrix * tilemap.GetTransformMatrix(position);
                var worldPosition = tilemap.CellToWorld(position) + tileAnchor;
                var spriteRenderer = GameObject.Instantiate(
                    spritePrefab,
                    worldPosition,
                    matrix.rotation,
                    parent);

                spriteRenderer.transform.localScale = matrix.scale;
                spriteRenderer.name = position.ToString();
                spriteRenderer.sprite = tilemap.GetSprite(position);
                spriteRenderer.sortingOrder = CalculateSortingOrder(tilemap, position);
            }
        }
    }

    static int CalculateSortingOrder(Tilemap tilemap, Vector3Int position)
    {
        switch (tilemap.cellLayout)
        {
            case Grid.CellLayout.Isometric:
            case Grid.CellLayout.IsometricZAsY:
                return CalculateIsometricSortingOrder(tilemap, position);
            default:
                return 0;
        }
    }

    static int CalculateIsometricSortingOrder(Tilemap tilemap, Vector3Int position)
    {
        var sortOrder = tilemap.GetComponent<TilemapRenderer>().sortOrder;
        if (sortOrder == TilemapRenderer.SortOrder.TopLeft || sortOrder == TilemapRenderer.SortOrder.BottomRight)
        {
            return 0;
        }

        var bounds = tilemap.cellBounds;
        if (sortOrder == TilemapRenderer.SortOrder.TopRight)
        {
            return - (position.x - bounds.xMin) - (position.y - bounds.yMin);
        }
        else // TilemapRenderer.SortOrder.BottomLeft
        {
            return (position.x - bounds.xMin) + (position.y - bounds.yMin);
        }
    }

    static Vector3 CalculateTilemapAnchor(Tilemap tilemap)
    {
        switch (tilemap.cellLayout)
        {
            case Grid.CellLayout.Rectangle:
                return CalculateRectangleTilemapAnchor(tilemap);
            case Grid.CellLayout.Isometric:
                return CalculateIsometricTilemapAnchor(tilemap);
            case Grid.CellLayout.IsometricZAsY:
                return CalculateIsometricZAsYTilemapAnchor(tilemap);
            default:
                Debug.LogWarningFormat("Cannot calculate anchor Grid.CellLayout : {0}", tilemap.cellLayout);
                return Vector3.zero;
        }
    }

    static Vector3 CalculateRectangleTilemapAnchor(Tilemap tilemap)
    {
        return tilemap.orientationMatrix.MultiplyPoint(tilemap.tileAnchor);
    }

    static Vector3 CalculateIsometricTilemapAnchor(Tilemap tilemap)
    {
        var gridCellSize = tilemap.LayoutGrid.cellSize;
        var xVector = new Vector3(gridCellSize.x, gridCellSize.y, 0.0F);
        var yVector = new Vector3(-gridCellSize.x, gridCellSize.y, 0.0F);
        var anchor = tilemap.tileAnchor;
        var result = (anchor.x * xVector + anchor.y * yVector) / 2;

        return result;
    }

    static Vector3 CalculateIsometricZAsYTilemapAnchor(Tilemap tilemap)
    {
        var gridCellSize = tilemap.LayoutGrid.cellSize;
        var xVector = new Vector3(gridCellSize.x, 0.0F, gridCellSize.y);
        var zAsYVector = new Vector3(-gridCellSize.x, 0.0F, gridCellSize.y);
        var anchor = tilemap.tileAnchor;
        var result = (anchor.x * xVector + anchor.y * zAsYVector) / 2;

        return result;
    }
}
