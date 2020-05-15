using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class ActorMovement : SerializedMonoBehaviour
{
	[SerializeField] private float startMovementSpeed = 5f;
	[SerializeField] private bool smooth = false;
	[SerializeField, Required] private Rigidbody2D body = null;
	[OdinSerialize] private IMovementInput movementInput = null;

	[HideInInspector] public UnityAction<IMovementInput> OnInputChange = null;
	public IMovementInput MovementInput => movementInput;
	public float MovementSpeed { get; set; } = 5f;

	private void OnValidate() =>
		MovementSpeed = startMovementSpeed;

	private void Start() =>
		MovementSpeed = startMovementSpeed;

	private void OnDisable() =>
		body.velocity = Vector2.zero;

	private void FixedUpdate()
	{
		if (movementInput != null)
		{
			Vector2 velocity = movementInput.Direction * MovementSpeed;
			velocity.y = body.velocity.y;

			body.velocity = smooth ? Vector2.Lerp(body.velocity, velocity, 10f * Time.deltaTime) : velocity;
		}
	}

	public void SetInput(IMovementInput newInput)
	{
		movementInput = newInput;
		OnInputChange?.Invoke(movementInput);

		if (newInput == null)
		{
			body.velocity = Vector2.zero;

			return;
		}
	}

	public void SetSmooth(bool smooth) =>
		this.smooth = smooth;
}
