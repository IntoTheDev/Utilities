using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace ToolBox.Framework.Actors
{
	public class FlipOnMovement : SerializedMonoBehaviour
	{
		/*[SerializeField, Required, FoldoutGroup("Data")] private Transform view = null;
		[SerializeField, Required, FoldoutGroup("Data")] private ActorMovement actorMovement = null;

		[OdinSerialize, ReadOnly, FoldoutGroup("Debug")] IMovementInput movementInput = null;

		private void Update()
		{
			if (movementInput.Horizontal == 0f || movementInput == null)
				return;

			Vector3 scale = view.localScale;
			scale.x = movementInput.Horizontal;

			view.localScale = scale;
		}

		public void SetInput(IMovementInput movementInput) =>
			this.movementInput = movementInput;*/
	}
}
