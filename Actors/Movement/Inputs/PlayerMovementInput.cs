using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Behaviours.Actions
{
	public class PlayerMovementInput : Action, IMovementInput
	{
		public Vector2 Direction { get; private set; }

		[SerializeField] private float speed = 5f;
		[SerializeField] private ActorMovement actorMovement = null;

		public override void OnEnter()
		{
			RunTask();
			actorMovement.SetInput(this);
		}

		public override void OnExit()
		{
			StopTask();
			actorMovement.SetInput(null);
		}

		public override void ProcessTask()
		{
			Direction = new Vector2
			{
				x = Input.GetAxisRaw("Horizontal"),
				y = Input.GetAxisRaw("Vertical")
			}.normalized * speed;
		}
	}

}
