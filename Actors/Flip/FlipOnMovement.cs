using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace ToolBox.Framework.Actors
{
	public class FlipOnMovement : FlipBase
	{
		[SerializeField, Required, FoldoutGroup("Data")] private ActorMovement actorMovement = null;

		[OdinSerialize, ReadOnly, FoldoutGroup("Debug")] IMovementInput movementInput = null;

		private void Start() =>
			movementInput = actorMovement.MovementInput;

		private void OnEnable() =>
			actorMovement.OnInputChange += SetInput;

		private void OnDisable() =>
			actorMovement.OnInputChange -= SetInput;

		private void Update()
		{
			if (movementInput == null)
				return;

			float direction = movementInput.Direction.x;

			if (direction == 0f)
				return;

			Quaternion side = direction > 0f ? rightRotation : leftRotation;
			FlipView(side);
		}

		private void SetInput(IMovementInput movementInput) =>
			this.movementInput = movementInput;
	}
}
