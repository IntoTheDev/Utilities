using ToolBox.Observer;
using UnityEngine;

public class CameraSetTarget : MonoBehaviour
{
	[SerializeField] private TransformGameEvent cameraTarget = null;

	private Transform cachedTransform = null;

	private void Start()
	{
		cachedTransform = transform;
		cameraTarget.Raise(cachedTransform);
	}
}
