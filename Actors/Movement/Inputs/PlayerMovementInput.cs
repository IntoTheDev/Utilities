using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ActorMovement))]
public class PlayerMovementInput : MonoBehaviour, IMovementInput
{
	public Vector2 Direction { get; private set; } = default;

	private ActorMovement actorMovement = null;
	private Vector2 currentDirection = default;

	private PlayerInputActions inputActions = null;
	private InputAction moveAction = null;

	private void Awake()
	{
		actorMovement = GetComponent<ActorMovement>();
		inputActions = new PlayerInputActions();
		moveAction = inputActions.Player.Move;
	}

	private void OnEnable()
	{
		actorMovement.SetInput(this);
		inputActions.Enable();	
	}

	private void OnDisable()
	{
		actorMovement.SetInput(null);
		inputActions.Disable();
	}

	private void Update()
	{
		currentDirection.x = moveAction.ReadValue<Vector2>().x;
		Direction = currentDirection;
	}
}
