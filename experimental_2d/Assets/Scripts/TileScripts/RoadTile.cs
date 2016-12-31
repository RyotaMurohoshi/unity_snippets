using System;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine
{
    [Serializable]
    public class RoadTile : TileBase
    {
        [SerializeField]
        public Sprite[] m_Sprites;

        private Vector3Int[] vectors = new Vector3Int[]{
            Vector3Int.zero,
            Vector3Int.up,
            Vector3Int.right,
            Vector3Int.down,
            Vector3Int.left,
        };

        public override void RefreshTile(Vector3Int location, ITilemap tilemap)
        {
            foreach (var addVector in vectors)
            {
                Vector3Int position = location + addVector;
                if (TileValue(tilemap, position))
                {
                    tilemap.RefreshTile(position);
                }
            }
        }

        public override bool GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            UpdateTile(location, tilemap, ref tileData);
            return true;
        }

        private void UpdateTile(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            tileData.transform = Matrix4x4.identity;
            tileData.color = Color.white;

            int mask = TileValue(tilemap, location + new Vector3Int(0, 1, 0)) ? 1 : 0;
            mask += TileValue(tilemap, location + new Vector3Int(1, 0, 0)) ? 2 : 0;
            mask += TileValue(tilemap, location + new Vector3Int(0, -1, 0)) ? 4 : 0;
            mask += TileValue(tilemap, location + new Vector3Int(-1, 0, 0)) ? 8 : 0;

            int index = GetIndex((byte)mask);
            if (index >= 0 && index < m_Sprites.Length && TileValue(tilemap, location))
            {
                tileData.sprite = m_Sprites[index];
                tileData.transform = GetTransform((byte)mask);
                tileData.flags = (int)(TileFlags.LockTransform | TileFlags.LockColor);
            }
        }

        private bool TileValue(ITilemap tilemap, Vector3Int position)
        {
            TileBase tile = tilemap.GetTile(position);
            return (tile != null && tile == this);
        }

        private int GetIndex(byte mask)
        {
            switch (mask)
            {
                case 0:
                    return 0;
                case 3:
                case 6:
                case 9:
                case 12:
                    return 1;
                case 1:
                case 2:
                case 4:
                case 8:
                    return 5;
                case 5:
                case 10:
                    return 2;
                case 7:
                case 11:
                case 13:
                case 14:
                    return 3;
                case 15:
                    return 4;
            }
            return -1;
        }

        private Matrix4x4 GetTransform(byte mask)
        {
            switch (mask)
            {
                case 9:
                case 10:
                case 7:
                case 8:
                    return Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, -90f), Vector3.one);
                case 3:
                case 1:
                case 14:
                    return Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, -180f), Vector3.one);
                case 2:
                case 6:
                case 13:
                    return Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, -270f), Vector3.one);
            }
            return Matrix4x4.identity;
        }

#if UNITY_EDITOR
        [MenuItem("Assets/Create/Scripted Tile/Road Tile")]
        public static void CreateRoadTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Road Tile", "New Road Tile", "asset", "Save Road Tile", "Assets");

            if (path == "")
                return;

            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<RoadTile>(), path);
        }

        public override Sprite GetPreview()
        {
            if (m_Sprites != null && m_Sprites.Length > 5)
            {
                return m_Sprites[5];
            }
            return null;
        }
#endif
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(RoadTile))]
    public class RoadTileEditor : Editor
    {
        private RoadTile tile { get { return (target as RoadTile); } }

        public void OnEnable()
        {
            if (tile.m_Sprites == null || tile.m_Sprites.Length != 6)
                tile.m_Sprites = new Sprite[6];
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Place sprites shown based on the number of tiles bordering it.");
            EditorGUILayout.Space();

            EditorGUI.BeginChangeCheck();
            tile.m_Sprites[0] = (Sprite)EditorGUILayout.ObjectField("Single", tile.m_Sprites[0], typeof(Sprite), false, null);
            tile.m_Sprites[2] = (Sprite)EditorGUILayout.ObjectField("Straight", tile.m_Sprites[2], typeof(Sprite), false, null);
            tile.m_Sprites[1] = (Sprite)EditorGUILayout.ObjectField("Corner", tile.m_Sprites[1], typeof(Sprite), false, null);
            tile.m_Sprites[3] = (Sprite)EditorGUILayout.ObjectField("Tjunction", tile.m_Sprites[3], typeof(Sprite), false, null);
            tile.m_Sprites[4] = (Sprite)EditorGUILayout.ObjectField("Cross", tile.m_Sprites[4], typeof(Sprite), false, null);
            tile.m_Sprites[5] = (Sprite)EditorGUILayout.ObjectField("DeadEnd", tile.m_Sprites[5], typeof(Sprite), false, null);
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(tile);
        }
    }
#endif
}
