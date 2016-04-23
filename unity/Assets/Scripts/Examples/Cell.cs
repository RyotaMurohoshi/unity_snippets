using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
	[SerializeField] float height;
	[SerializeField] Text text;
	[SerializeField] Image background;

	public float Height {
		get { return height; }
	}

	public Data Data {
		set { 
			text.text = value.Name;
			background.color = value.Color;
		}
	}
}
