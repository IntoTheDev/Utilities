using MEC;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetingBehaviour))]
public class TargetingDistance : Targeting
{
	public float Distance => distance;

	[SerializeField, ReadOnly] private float distance = 0f;

	protected override IEnumerator<float> TargetingProcessing()
	{
		while (true)
		{
			distance = Vector3.Distance(cachedTransform.position, target.position);

			yield return Timing.WaitForOneFrame;
		}
	}
}
