using MEC;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetingBehaviour), typeof(TargetingDistance))]
public class TargetingLineOfSight : Targeting
{
	public bool IsInLineOfSight => isInLineOfSight;

	[SerializeField] private LayerMask layerMask = default;
	[SerializeField] private TargetingDistance targetingDistance = default;

	[SerializeField, ReadOnly] private bool isInLineOfSight = false;

	protected override IEnumerator<float> TargetingProcessing()
	{
		while (true)
		{
			Vector3 position = cachedTransform.position;
			Vector3 direction = Vector3.Normalize(target.position - position);

			isInLineOfSight = !Physics2D.Raycast(position, direction, targetingDistance.Distance, layerMask);

			yield return Timing.WaitForOneFrame;
		}
	}
}
