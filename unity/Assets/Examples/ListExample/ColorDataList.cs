﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;


public class ColorDataList : MonoBehaviour
{
	[SerializeField] ColorDataCell cellPrefabA;
	[SerializeField] ColorDataCell cellPrefabB;
	[SerializeField] List<ColorData> dataList;

	void Start ()
	{
		var rect = GetComponent<ScrollRect> ();
		var totalY = 0.0F;
		foreach (var it in dataList.Select((data, index) => new {data, index})) {
			var prefab = it.index % 2 == 0 ? cellPrefabA : cellPrefabB;
			var cell = Instantiate (prefab);
			cell.ColorData = it.data;
			cell.transform.SetParent(rect.content.transform);
			var rectTransform = cell.GetComponent<RectTransform> ();
			rectTransform.anchoredPosition = Vector2.zero + totalY * Vector2.down;
			totalY += cell.Height;
		}

		rect.content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, totalY);
	}
}
