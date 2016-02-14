using UnityEngine;
using System.Collections;

public class CustomYieldInstructionExample : MonoBehaviour
{
	[SerializeField] bool waitUntil = false;
	[SerializeField] bool waitWhile = true;

	void Start ()
	{
		StartCoroutine (WaitUntilCoroutine ());
		StartCoroutine (WaitWhileCoroutine ());
	}

	IEnumerator WaitUntilCoroutine ()
	{
		Debug.Log ("WaitUntilCoroutine Begin");
		yield return new WaitUntil (() => waitUntil);
		Debug.Log ("WaitUntilCoroutine Finish");
	}

	IEnumerator WaitWhileCoroutine ()
	{
		Debug.Log ("WaitWhileCoroutine Begin");
		yield return new WaitWhile (() => waitWhile);
		Debug.Log ("WaitWhileCoroutine Finish");
	}
}
