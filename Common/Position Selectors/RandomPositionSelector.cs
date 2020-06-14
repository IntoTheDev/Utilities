using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Utilities
{
	public class RandomPositionSelector : IPositionSelector
	{
		[SerializeField, Required, SceneObjectsOnly] private Transform[] _points = null;

		public Vector3 GetPosition()
		{
			int index = Random.Range(0, _points.Length);
			return _points[index].position;
		}
	}
}
