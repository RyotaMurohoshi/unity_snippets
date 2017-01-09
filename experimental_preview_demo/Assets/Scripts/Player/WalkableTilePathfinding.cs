using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

public class WalkableTilePathfinding : MonoBehaviour
{
	int m_InvalidTileMoveCost = 1000;
	int[] m_MovementCosts;
	Vector3Int m_Origin = Vector3Int.zero;
	Vector3Int m_Size = Vector3Int.zero;
	Vector3Int[] m_Neighbours = new Vector3Int[4]
	{
		new Vector3Int(0, -1, 0),
		new Vector3Int(0, 1, 0),
		new Vector3Int(-1, 0, 0),
		new Vector3Int(1, 0, 0),
	};

	void Start ()
	{
		UpdateMovementCosts();
	}
	
	bool IsValidTile(Vector3Int position)
	{
		if (m_Origin.x <= position.x && position.x < m_Origin.x + m_Size.x &&
		    m_Origin.y <= position.y && position.y < m_Origin.y + m_Size.y)
		{
			return true;
		}
		return false;
	}

	int GetIndex(Vector3Int position)
	{
		return m_Size.x * (position.y - m_Origin.y) + (position.x - m_Origin.x);
	}

	int GetScore(Vector3Int position, Vector3Int endPosition)
	{
		return Math.Abs(endPosition.x - position.x) + Math.Abs(endPosition.y - position.y);
	}

	public void UpdateMovementCosts()
	{
		var tilemap = GetComponent<Tilemap>();
		if (!tilemap)
			return;
		tilemap.CompressBounds();

		m_Origin = tilemap.origin;
		m_Size = tilemap.size;
		m_MovementCosts = new int[m_Size.x * m_Size.y];

		Vector3Int target = Vector3Int.zero;
		for (target.y = m_Origin.y; target.y < m_Origin.y + m_Size.y; ++target.y)
		{
			for (target.x = m_Origin.x; target.x < m_Origin.x + m_Size.x; ++target.x)
			{
				var moveIndex = (target.y - tilemap.origin.y) * m_Size.x + (target.x - tilemap.origin.x);
				var walkableTile = tilemap.GetTile<WalkableTile>(target);
				if (walkableTile)
				{
					m_MovementCosts[moveIndex] = walkableTile.m_MoveCost;
				}
				else
				{
					m_MovementCosts[moveIndex] = m_InvalidTileMoveCost;
				}
			}
		}
	}

	// Implemented from https://en.wikipedia.org/wiki/A*_search_algorithm
	public IList<Vector3Int> FindPath(Vector3Int startPosition, Vector3Int endPosition)
	{
		List<Vector3Int> path = new List<Vector3Int>();
		HashSet<Vector3Int> closedSet = new HashSet<Vector3Int>();
		HashSet<Vector3Int> openSet = new HashSet<Vector3Int>();

		Vector3Int[] cameFrom = new Vector3Int[m_Size.x * m_Size.y];
		int[] actualMovementCosts = new int[m_Size.x * m_Size.y];
		int[] heuristicMovementCosts = new int[m_Size.x * m_Size.y];
		for (int y = 0; y < m_Size.y; ++y)
		{
			for (int x = 0; x < m_Size.x; ++x)
			{
				int index = y * m_Size.x + x;
				actualMovementCosts[index] = int.MaxValue;
				heuristicMovementCosts[index] = int.MaxValue;
			}
		}

		var startIndex = GetIndex(startPosition);
		openSet.Add(startPosition);
		actualMovementCosts[startIndex] = 0;
		heuristicMovementCosts[startIndex] = GetScore(startPosition, endPosition);

		while (openSet.Count > 0)
		{
			Vector3Int current = Vector3Int.zero;
			var score = int.MaxValue;
			foreach (Vector3Int possible in openSet)
			{
				var possibleScore = heuristicMovementCosts[GetIndex(possible)];
				if (possibleScore < score)
				{
					score = possibleScore;
					current = possible;
				}
			}
			if (current.x == endPosition.x &&
				current.y == endPosition.y)
			{
				while (current != startPosition)
				{
					path.Add(current);
					current = cameFrom[GetIndex(current)];
				}
				path.Reverse();
				break;
			}

			openSet.Remove(current);
			closedSet.Add(current);
			var currentIndex = GetIndex(current);

			for (int i = 0; i < 4; ++i)
			{ 
				Vector3Int neighbour = current + m_Neighbours[i];
				if (!IsValidTile(neighbour))
					continue;
				if (closedSet.Contains(neighbour))
					continue;
				var neighbourIndex = GetIndex(neighbour);
				score = actualMovementCosts[currentIndex] + m_MovementCosts[neighbourIndex];
				if (!openSet.Contains(neighbour))
					openSet.Add(neighbour);
				else if (score >= actualMovementCosts[neighbourIndex])
					continue;

				cameFrom[neighbourIndex] = current;
				actualMovementCosts[neighbourIndex] = score;
				heuristicMovementCosts[neighbourIndex] = score + GetScore(neighbour, endPosition);
			}
		}
		return path;
	}
}
