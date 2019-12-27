using Sirenix.OdinInspector;
using UnityEngine;

public class PixelPerfectFollow : MonoBehaviour
{
	[SerializeField] private Transform target = null;
	[SerializeField] private float followSpeed = 1f;
	[SerializeField] private float pixelsPerUnit = 32f;

	private Transform cachedTransform = null;

	private void Awake() => cachedTransform = transform;

	private void FixedUpdate()
	{
		if (target == null)
			return;

		Vector3 cameraPosition = cachedTransform.position;
		Vector3 targetPosition = target.position;
		float speed = followSpeed * Time.fixedDeltaTime;

		targetPosition = Vector3.MoveTowards(cameraPosition, targetPosition, speed);

		targetPosition.x = (Mathf.Round(targetPosition.x * pixelsPerUnit) / pixelsPerUnit);
		targetPosition.y = (Mathf.Round(targetPosition.y * pixelsPerUnit) / pixelsPerUnit);
		targetPosition.z = -10f;

		cachedTransform.position = targetPosition;
	}

	[Button("Set Target")]
	public void SetTarget(Transform target) => this.target = target;
}
