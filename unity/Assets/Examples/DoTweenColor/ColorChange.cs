using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorChange : MonoBehaviour
{
	IEnumerator Start ()
	{
		Debug.Log ("Ready");
		var spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.color = Color.white;

		yield return new WaitForSeconds (1.0F);
		Debug.Log ("Animation Start");

		yield return spriteRenderer.DOColor (Color.black, 5.0F);

		yield return new WaitForSeconds (1.0F);
		Debug.Log ("Animation Finished");
		List<Vector3> f = new List<Vector3> ();

		List<Vector3> paths = new List<Vector3> ();
		paths.AddRange (f);
	}
}
