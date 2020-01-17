using MEC;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActorMovement : MonoBehaviour
{
	public UnityAction<IMovementInput> OnInputChange = null;
	public IMovementInput MovementInput => movementInput;

	[SerializeField] private Rigidbody2D rb = null;

	private IMovementInput movementInput = null;
	private CoroutineHandle coroutineHandle = default;
	private GameObject cachedObject = null;

	private void Start()
	{
		cachedObject = gameObject;

		if (movementInput != null)
			RunMovementCoroutine();
	}

	private IEnumerator<float> Move()
	{
		while (true)
		{
			rb.MovePosition(rb.position + movementInput.Direction * Time.fixedDeltaTime);

			yield return Timing.WaitForOneFrame;
		}
	}

	public void SetInput(IMovementInput newInput)
	{
		movementInput = newInput;
		OnInputChange?.Invoke(movementInput);

		Timing.KillCoroutines(coroutineHandle);

		if (newInput != null)
			RunMovementCoroutine();
	}

	private void RunMovementCoroutine() =>
		coroutineHandle = Timing.RunCoroutine(Move().CancelWith(cachedObject), Segment.FixedUpdate);
}
