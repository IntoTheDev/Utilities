using UnityEngine;

public abstract class Collision : MonoBehaviour
{
	[SerializeField] protected Transform pivot = null;
	[SerializeField] protected float rayLength = 1f;
	[SerializeField] private LayerMask solidLayers = default;

	protected RaycastHit2D ProcessCollision(Vector2 direction) =>
		Physics2D.Raycast(pivot.position, direction, rayLength, solidLayers);
}
