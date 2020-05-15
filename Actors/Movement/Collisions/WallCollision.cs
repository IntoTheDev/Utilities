using Sirenix.OdinInspector;
using UnityEngine;

public class WallCollision : Collision
{
	[SerializeField, ReadOnly] private bool onWall = false; 
	[SerializeField, ReadOnly] private bool onRightWall = false;
	[SerializeField, ReadOnly] private bool onLeftWall = false;

	public bool OnWall => onWall;
	public bool OnRightWall => onRightWall;
	public bool OnLeftWall => onLeftWall;
	public RaycastHit2D WallHit { get; private set; } = default;

	private RaycastHit2D rightHit = default;
	private RaycastHit2D leftHit = default;

	private void Update()
	{
		rightHit = ProcessCollision(Vector2.right);
		leftHit = ProcessCollision(Vector2.left);

		onRightWall = rightHit;
		onLeftWall = leftHit;

		onWall = onRightWall || onLeftWall;

		if (!onWall)
			return;

		WallHit = onRightWall ? rightHit : leftHit;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawRay(pivot.position, Vector2.right * rayLength);
		Gizmos.DrawRay(pivot.position, Vector2.left * rayLength);
	}
}
