using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Utilities
{
	public class PixelPerfectFollow : MonoBehaviour, ITransformReactor
	{
		[SerializeField] private float _pixelsPerUnit = 16f;
		[SerializeField] private Transform _target = null;
		[SerializeField] private float _smoothValue = 0.25f;
		[SerializeField] private Vector2 _offset = default;

		private Transform _transform = null;

		private void Awake() =>
			_transform = transform;

		private void OnValidate()
		{
			if (_target == null)
				return;

			Vector3 newPosition = _transform.position;

			newPosition = _target.position;
			newPosition.x = Mathf.Floor((newPosition.x + _offset.x) * _pixelsPerUnit) / _pixelsPerUnit;
			newPosition.y = Mathf.Floor((newPosition.y + _offset.y) * _pixelsPerUnit) / _pixelsPerUnit;
			newPosition.z = -10f;

			transform.position = newPosition;
		}

		private void FixedUpdate()
		{
			if (_target == null)
				return;

			Vector3 newPosition = _transform.position;

			newPosition = Vector3.Lerp(newPosition, _target.position, _smoothValue * Time.fixedDeltaTime);
			newPosition.x = Mathf.Floor((newPosition.x + _offset.x) * _pixelsPerUnit) / _pixelsPerUnit;
			newPosition.y = Mathf.Floor((newPosition.y + _offset.y) * _pixelsPerUnit) / _pixelsPerUnit;
			newPosition.z = -10f;

			_transform.position = newPosition;
		}

		public void HandleReaction(Transform value) =>
			_target = value;
	}
}