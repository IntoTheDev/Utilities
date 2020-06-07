using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Utilities
{
	public class RoundRobinPositionSelector : IPositionSelector
	{
		[ShowInInspector, ReadOnly] private int index = 0;
		[SerializeField, Required, SceneObjectsOnly] private Transform[] points = null;

		public Vector3 GetPosition()
		{
			Vector3 position = points[index].position;
			index++;

			if (index == points.Length)
				index = 0;

			return position;
		}
	}
}
