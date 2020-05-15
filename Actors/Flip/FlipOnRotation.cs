using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using ToolBox.Extensions;

namespace ToolBox.Framework.Actors
{
	public class FlipOnRotation : FlipBase
	{
		[SerializeField, FoldoutGroup("Data")] private Transform rotationPivot = null;

		private Vector3 rightFlip = default;
		private Vector3 leftFlip = default;

		private bool isFacingRight = true;
		private Camera mainCamera = null;
		private PlayerInputActions inputActions = null;
		private InputAction mouseAction = null;
		private bool wasDisabled = false;

		protected override void Awake()
		{
			base.Awake();

			mainCamera = Camera.main;
			inputActions = new PlayerInputActions();
			mouseAction = inputActions.Player.MousePosition;
		}

		private void OnEnable()
		{
			inputActions.Enable();

			if (!wasDisabled)
				return;

			bool isFliped = IsMouseFliped();

			if (isFliped)
				Flip(leftRotation, leftFlip, false);
			else if (!isFliped)
				Flip(rightRotation, rightFlip, true);
		}

		private void OnDisable()
		{
			inputActions.Disable();
			wasDisabled = true;
		}

		private void Start()
		{
			rightFlip = Vector3.one;
			leftFlip = Vector3.one;
			leftFlip.y = -1f;
		}

		private void Update()
		{
			bool isFliped = IsMouseFliped();

			if (isFliped && isFacingRight)
				Flip(leftRotation, leftFlip, false);
			else if (!isFliped && !isFacingRight)
				Flip(rightRotation, rightFlip, true);
		}

		private bool IsMouseFliped() =>
			mainCamera.ScreenToWorldPoint(mouseAction.ReadValue<Vector2>()).x < cachedTransform.position.x;

		private void Flip(Quaternion rotation, Vector3 flipSide, bool isFacingRight)
		{
			FlipView(rotation);
			rotationPivot.localScale = flipSide;

			this.isFacingRight = isFacingRight;
		}
	}
}
