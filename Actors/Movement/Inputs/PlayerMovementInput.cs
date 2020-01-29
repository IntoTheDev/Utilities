using UnityEngine;

namespace ToolBox.Behaviours.Actions
{
	public class PlayerMovementInput : Action, IMovementInput
	{
		public Vector2 Direction { get; private set; }

		[SerializeField] private float speed = 5f;
		[SerializeField] private ActorMovement actorMovement = null;

		public override void Initialize(BehaviourProcessor behaviourProcessor)
		{
			base.Initialize(behaviourProcessor);

			actorMovement.SetInput(this);
		}

		public override void OnEnter()
		{
			base.OnEnter();

			actorMovement.SetInput(this);
		}

		public override void OnExit()
		{
			base.OnExit();

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
