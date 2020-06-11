using ToolBox.Signals.Local;
using UnityEngine;

namespace ToolBox.Utilities
{
	public class PixelPerfectFollow : MonoBehaviour, ISignalReceiver<Transform>
	{
		[SerializeField] private float pixelsPerUnit = 16f;
		[SerializeField] private Transform target = null;
		[SerializeField] private float smoothValue = 0.25f;
		[SerializeField] private Vector2 offset = default;

		private Transform cachedTransform = null;

		private void Awake() =>
			cachedTransform = transform;

		private void OnValidate()
		{
			if (target == null)
				return;

			Vector3 newPosition = cachedTransform.position;

			newPosition = target.position;
			newPosition.x = Mathf.Floor((newPosition.x + offset.x) * pixelsPerUnit) / pixelsPerUnit;
			newPosition.y = Mathf.Floor((newPosition.y + offset.y) * pixelsPerUnit) / pixelsPerUnit;
			newPosition.z = -10f;

			transform.position = newPosition;
		}

		private void FixedUpdate()
		{
			if (target == null)
				return;

			Vector3 newPosition = cachedTransform.position;

			newPosition = Vector3.Lerp(newPosition, target.position, smoothValue * Time.fixedDeltaTime);
			newPosition.x = Mathf.Floor((newPosition.x + offset.x) * pixelsPerUnit) / pixelsPerUnit;
			newPosition.y = Mathf.Floor((newPosition.y + offset.y) * pixelsPerUnit) / pixelsPerUnit;
			newPosition.z = -10f;

			cachedTransform.position = newPosition;
		}

		public void Receive(Transform value) =>
			target = value;
	}
}