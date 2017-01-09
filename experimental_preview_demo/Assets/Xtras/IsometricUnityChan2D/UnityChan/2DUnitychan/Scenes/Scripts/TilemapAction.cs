using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapAction : MonoBehaviour
{
	public Vector3Int targetCell;
	public float speed = 1.0f;
	
	Animator animator;
	Transform myTransform;
	Tilemap tilemap;
	Transform tilemapTransform;
	Vector3 targetPosition;
	WalkableTilePathfinding pathFinder;
	IList<Vector3Int> path = new List<Vector3Int>();

	// Animation
	int hashStateNegative = Animator.StringToHash("Emotion.Negative");
	int hashSpeed = Animator.StringToHash("Speed");

	void Awake ()
	{
		animator = GetComponent<Animator>();
		myTransform = this.transform;
		tilemap = GetComponentInParent<Tilemap>();
		tilemapTransform = tilemap.transform;
		targetCell = tilemap.WorldToCell(myTransform.position);
		targetPosition = myTransform.position;
		pathFinder = GetComponentInParent<WalkableTilePathfinding>();
	}

	Vector3 GetNextPosition()
	{
		if (path.Count > 0)
		{
			var nextCell = path[0];
			return tilemap.LocalToWorld(
					tilemap.GetInterpolatedLocal(
						new Vector3(nextCell.x, nextCell.y, myTransform.position.z)));
		}
		return targetPosition;
	}

	void Update ()
	{
		// Determine new target
		bool hasInput = false;
		Vector2 inputPosition;
		if (Input.GetMouseButtonDown(0))
		{
			inputPosition = Input.mousePosition;
			hasInput = true;
		}
		if (Input.touchCount > 0)
		{
			inputPosition = Input.GetTouch(0).position;
			hasInput = true;
		}

		if (hasInput)
		{
			Vector3 forward = tilemap.orientationMatrix.MultiplyVector(tilemapTransform.forward) * -1f;
			Plane plane = new Plane(forward, tilemapTransform.position);
			Ray ray = Camera.main.ScreenPointToRay(inputPosition);

			float result;
			plane.Raycast(ray, out result);
			Vector3 world = ray.GetPoint(result);
			var cell = tilemap.WorldToCell(world);
			if (targetCell != cell)
			{
				var tile = tilemap.GetTile(cell);
				if (tile is WalkableTile)
				{
					targetCell = cell;
					path = pathFinder.FindPath(tilemap.WorldToCell(myTransform.position), targetCell);
					targetPosition = GetNextPosition();
				}
				else
				{
					animator.Play(hashStateNegative);
				}
			}
		}
		
		// Animation/Movement
		if (myTransform.position.x != targetPosition.x ||
			myTransform.position.y != targetPosition.y)
		{
			animator.SetFloat(hashSpeed, 1.0f);

			// Move to target position
			myTransform.position = Vector3.MoveTowards(myTransform.position, 
				targetPosition,
				Time.deltaTime * speed);
		}
		else
		{
			animator.SetFloat(hashSpeed, 0.0f);
			if (path.Count > 0)
				path.RemoveAt(0);
			targetPosition = GetNextPosition();
		}
	}
}
