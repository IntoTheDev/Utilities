using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class TargetingBehaviour : SerializedMonoBehaviour
{
	public Transform Target => target;

	[FoldoutGroup("Events")] public UnityEvent<Transform> OnTargetFound = null;
	[FoldoutGroup("Events")] public UnityEvent<Transform> OnTargetLost = null;

	[SerializeField, FoldoutGroup("Data")] private Transform target = null;
	[OdinSerialize, FoldoutGroup("Data")] private ITargetFinder targetFinder = null;

	private void Awake()
	{
		targetFinder.Initialize(this);

		if (target != null)
			OnTargetFound?.Invoke(target);
	}

	public void FindTarget()
	{
		Transform newTarget = targetFinder.FindTarget();

		if (newTarget != target)
		{
			target = newTarget;
			OnTargetFound?.Invoke(target);
		}
	}

	public void LoseTarget()
	{
		if (target == null)
			return;

		target = null;
		OnTargetLost?.Invoke(target);
	}

	private void OnDrawGizmos()
	{
		if (targetFinder == null)
			return;

		targetFinder.Debugging();
	}
}
