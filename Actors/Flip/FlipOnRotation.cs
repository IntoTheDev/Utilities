using UnityEngine;

namespace ToolBox.Framework.Actors
{
	public class FlipOnRotation : MonoBehaviour
	{
		[SerializeField] private Transform rotationPivot = null;
		[SerializeField] private Transform view = null;

		private Quaternion rotation = default;
		private Vector3 rightFlip = default;
		private Vector3 leftFlip = default;
		private Vector3 upFlip = default;
		private Vector3 downFlip = default;

		private const float rotationPoint = 0.70711068f;

		private void Start()
		{
			rightFlip = Vector3.one;

			leftFlip = Vector3.one;
			leftFlip.x = -1f;

			upFlip = Vector3.one;

			downFlip = Vector3.one;
			downFlip.y = -1f;
		}

		private void Update()
		{
			rotation = rotationPivot.localRotation;
			float direction = rotation.w;

			bool isFliped = direction >= rotationPoint || direction == 0f;

			Vector3 viewScale = isFliped ? rightFlip : leftFlip;
			Vector3 rotationScale = isFliped ? upFlip : downFlip;

			view.localScale = viewScale;
			rotationPivot.localScale = rotationScale;
		}
	}
}
