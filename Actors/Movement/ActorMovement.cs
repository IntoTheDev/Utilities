using MEC;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActorMovement : MonoBehaviour
{
	public UnityAction<IMovementInput> OnInputChange = null;
	public IMovementInput MovementInput { get; private set; } = null;

	[SerializeField] private Rigidbody2D rb = null;

	private CoroutineHandle coroutineHandle = default;

	private void Start()
	{
		if (MovementInput != null)
			RunMovementCoroutine();
	}

	private void OnEnable()
	{
		if (coroutineHandle.IsValid)
			Timing.ResumeCoroutines(coroutineHandle);
	}

	private void OnDisable() =>
		Timing.PauseCoroutines(coroutineHandle);

	private IEnumerator<float> Move()
	{
		while (true)
		{
			//rb.MovePosition(rb.position + MovementInput.Direction * Time.fixedDeltaTime);
			Vector2 direction = MovementInput.Direction;
			direction.y = rb.velocity.y;

			rb.velocity = direction;

			yield return Timing.WaitForOneFrame;
		}
	}

	public void SetInput(IMovementInput newInput)
	{
		MovementInput = newInput;
		OnInputChange?.Invoke(MovementInput);

		Timing.KillCoroutines(coroutineHandle);

		if (newInput != null)
			RunMovementCoroutine();
	}

	private void RunMovementCoroutine() =>
		coroutineHandle = Timing.RunCoroutine(Move(), Segment.FixedUpdate);
}
