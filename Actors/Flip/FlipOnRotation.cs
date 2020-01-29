using UnityEngine;

namespace ToolBox.Framework.Actors
{
	public class FlipOnRotation : MonoBehaviour
	{
		[SerializeField] private Transform rotationPivot = null;
		[SerializeField] private Transform view = null;

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
			downFlip.x = -1f;
			downFlip.y = -1f;
		}

		private void Update()
		{
			bool isFliped = rotationPivot.rotation.w < rotationPoint;

			Vector3 rotationScale = isFliped ? downFlip : upFlip;
			Vector3 viewScale = isFliped ? leftFlip : rightFlip;

			rotationPivot.localScale = rotationScale;
			view.localScale = viewScale; 
		}
	}
}
