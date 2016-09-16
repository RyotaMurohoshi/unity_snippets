using UnityEngine;
using UnityEngine.UI;

public class ColorDataCell : MonoBehaviour
{
	[SerializeField] float height;
	[SerializeField] Text text;
	[SerializeField] Image background;

	public float Height {
		get { return height; }
	}

	public ColorData ColorData {
		set { 
			text.text = value.Name;
			background.color = value.Color;
		}
	}
}
