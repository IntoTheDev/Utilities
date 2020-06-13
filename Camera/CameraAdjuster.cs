using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(PixelPerfectCamera))]
public class CameraAdjuster : MonoBehaviour
{
	private void Awake()
	{
		Resolution resolution = Screen.currentResolution;
		float aspectRatio = (float)resolution.width / resolution.height;

		PixelPerfectCamera pixelPerfectCamera = GetComponent<PixelPerfectCamera>();
		pixelPerfectCamera.refResolutionX = (int)(pixelPerfectCamera.refResolutionY * aspectRatio);
	}
}
