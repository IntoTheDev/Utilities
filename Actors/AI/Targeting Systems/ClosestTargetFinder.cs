using UnityEngine;
using ToolBox.Groups;

public class ClosestTargetFinder : ITargetFinder
{
	[SerializeField] private Transform pivot = null;
	[SerializeField] private float radius = 1f;
	[SerializeField] private LayerMask targetsLayers = default;
	[SerializeField] private int collidersCapacity = 10;
	[SerializeField] private Faction targetsFaction = null;

	private Collider2D[] colliders = null;
	private Transform cachedTransform = null;
	private Group[] targetsGroups = null;

	public void Initialize(TargetingBehaviour targetingBehaviour)
	{
		colliders = new Collider2D[collidersCapacity];
		cachedTransform = targetingBehaviour.transform;
		
		targetsGroups = new Group[targetsFaction.Groups.Length];
		targetsFaction.Groups.CopyTo(targetsGroups, 0);
	}

	public Transform FindTarget()
	{
		//int count = Physics2D.OverlapCircleNonAlloc(pivot.position, radius, colliders, targetsLayers);
		Collider2D[] colliders = Physics2D.OverlapCircleAll(pivot.position, radius, targetsLayers);
		int count = colliders.Length;

		if (count == 0)
			return null;

		float bestDistance = Mathf.Infinity;
		Transform target = null;
		Vector3 position = cachedTransform.position;

		for (int i = 0; i < count; i++)
		{
			Transform possibleTarget = colliders[i].transform;
			Vector3 targetPosition = possibleTarget.position;

			float distance = (targetPosition - position).sqrMagnitude;

			if (distance < bestDistance && Group.IsEntityInGroups(possibleTarget.gameObject, targetsGroups, CheckType.OneGroup))
			{
				bestDistance = distance;
				target = possibleTarget;
			}
		}

		return target;
	}

	public void Debugging()
	{
		if (pivot == null)
			return;

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(pivot.position, radius);
	}
}
