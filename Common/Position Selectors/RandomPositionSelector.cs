using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Utilities
{
	public class RandomPositionSelector : IPositionSelector
	{
		[SerializeField, Required, SceneObjectsOnly] private Transform[] points = null;

		public Vector3 GetPosition()
		{
			int index = Random.Range(0, points.Length);
			return points[index].position;
		}
	}
}
