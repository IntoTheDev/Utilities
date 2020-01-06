using MEC;
using System.Collections.Generic;
using UnityEngine;

public abstract class Targeting : MonoBehaviour
{
	protected Transform target = null;
	protected Transform cachedTransform = null;
	protected GameObject cachedObject = null;

	private CoroutineHandle targetingCoroutine = default;
	private TargetingBehaviour targetingBehaviour = null;

	private void Awake()
	{
		targetingBehaviour = GetComponent<TargetingBehaviour>();
		cachedTransform = transform;
		cachedObject = gameObject;
	}

	private void OnEnable()
	{
		targetingBehaviour.OnTargetFound.AddListener(OnTargetFound);
		targetingBehaviour.OnTargetLost.AddListener(OnTargetLost);
	}

	private void OnDisable()
	{
		targetingBehaviour.OnTargetFound.RemoveListener(OnTargetFound);
		targetingBehaviour.OnTargetLost.RemoveListener(OnTargetLost);
	}

	private void StartProcessing()
	{
		if (target != null)
			targetingCoroutine = Timing.RunCoroutine(TargetingProcessing().CancelWith(gameObject), Segment.SlowUpdate);
	}

	private void StopProcessing() =>
		Timing.KillCoroutines(targetingCoroutine);

	protected abstract IEnumerator<float> TargetingProcessing();

	private void OnTargetFound(Transform target)
	{
		this.target = target;
		StartProcessing();
	}

	private void OnTargetLost(Transform target)
	{
		this.target = null;
		StopProcessing();
	}
}
