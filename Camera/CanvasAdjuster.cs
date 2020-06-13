using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class CanvasAdjuster : MonoBehaviour
{
	private void Awake()
	{
		Resolution resolution = Screen.currentResolution;
		float aspectRatio = (float)resolution.width / resolution.height;

		CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
		float height = canvasScaler.referenceResolution.y;
		canvasScaler.referenceResolution = new Vector2
		{
			x = height * aspectRatio,
			y = height
		};
	}
}
