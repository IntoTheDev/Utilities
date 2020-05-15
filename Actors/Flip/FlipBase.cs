using Sirenix.OdinInspector;
using UnityEngine;

public class FlipBase : SerializedMonoBehaviour
{
	[SerializeField, FoldoutGroup("Data")] private Transform view = null;

	protected Transform cachedTransform = null;
	protected Quaternion rightRotation = default;
	protected Quaternion leftRotation = default;

	protected virtual void Awake()
	{
		cachedTransform = transform;

		leftRotation = Quaternion.Euler(0f, 180f, 0f);
	}

	protected void FlipView(Quaternion side) =>
		view.rotation = side;
}
