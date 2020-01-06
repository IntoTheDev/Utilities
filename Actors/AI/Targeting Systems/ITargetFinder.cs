using UnityEngine;

public interface ITargetFinder
{
	void Initialize(TargetingBehaviour targetingBehaviour);
	Transform FindTarget();
	void Debugging();
}
