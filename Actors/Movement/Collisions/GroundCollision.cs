using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class GroundCollision : Collision
{
	[SerializeField] private UnityEvent onGround = null;
	[SerializeField] private UnityEvent onLostGround = null;
	[SerializeField, ReadOnly] private bool isGrounded = false;

	public bool IsGrounded => isGrounded;

	private void Update()
	{
		bool isGrounded = ProcessCollision(Vector2.right);
		bool stateChanged = this.isGrounded != isGrounded;

		if (!stateChanged)
			return;

		this.isGrounded = isGrounded;
		UnityEvent callback = isGrounded ? onGround : onLostGround;
		callback?.Invoke();
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawRay(pivot.position, Vector2.right * rayLength);
	}
}
