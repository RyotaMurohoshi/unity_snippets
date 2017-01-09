using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Collections;

[RequireComponent (typeof (Camera))]
public class TilemapFollowCamera : MonoBehaviour {

	[HideInInspector]
	private GameObject player = null;
	[HideInInspector]
	private Grid grid = null;
	[HideInInspector]
	private Tilemap tilemap = null;

	public string playerTag = "Player";
	public string mapTag = "Cave";

	void Start () {
		player = GameObject.FindWithTag (playerTag);
		var go = GameObject.FindWithTag (mapTag);
		if (go != null)
		{
			tilemap = go.GetComponent<Tilemap> ();
			grid = tilemap.LayoutGrid;
		}
			
	}
	
	void Update () {
		if (player == null || tilemap == null || grid == null)
			return;

		var mainCamera = GetComponent<Camera> ();
		var height = mainCamera.orthographicSize;
		var width = mainCamera.aspect * mainCamera.orthographicSize;

		var tilemapSize = new Vector2(grid.cellSize.x * tilemap.size.x, grid.cellSize.y * tilemap.size.y);

		var playerPosition = player.transform.position;
		var x = Math.Min(tilemapSize.x - width, Math.Max(width, playerPosition.x));
		var y = Math.Min(tilemapSize.y - height, Math.Max(height, playerPosition.y));

		mainCamera.transform.position = new Vector3(x, y, mainCamera.transform.position.z);
	}
}
