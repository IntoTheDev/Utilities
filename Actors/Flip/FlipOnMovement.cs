using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace ToolBox.Framework.Actors
{
	public class FlipOnMovement : SerializedMonoBehaviour
	{
		[SerializeField, Required, FoldoutGroup("Data")] private Transform view = null;
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
			float direction = movementInput.Direction.x;

			if (direction == 0f)
				return;

			float horizontalDirection = Mathf.Sign(direction);

			Vector3 scale = view.localScale;
			scale.x = horizontalDirection;

			view.localScale = scale;
		}

		private void SetInput(IMovementInput movementInput) =>
			this.movementInput = movementInput;
	}
}
