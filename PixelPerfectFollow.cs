using UnityEngine;

public class PixelPerfectFollow : MonoBehaviour
{
	[SerializeField] private float pixelsPerUnit = 16f;
	[SerializeField] private Transform target = null;
	[SerializeField] private float smoothValue = 0.25f;

	private Transform cachedTransform = null;

	private void Awake() =>
		cachedTransform = transform;

	private void FixedUpdate()
	{
		Vector3 newPosition = cachedTransform.position;

		newPosition = Vector3.Lerp(newPosition, target.position, smoothValue * Time.fixedDeltaTime);
		newPosition.x = Mathf.Floor(newPosition.x * pixelsPerUnit) / pixelsPerUnit;
		newPosition.y = Mathf.Floor(newPosition.y * pixelsPerUnit) / pixelsPerUnit;
		newPosition.z = -10f;

		cachedTransform.position = newPosition;
	}
}