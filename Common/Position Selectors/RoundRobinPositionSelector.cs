using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Utilities
{
	public class RoundRobinPositionSelector : IPositionSelector
	{
		[ShowInInspector, ReadOnly] private int _index = 0;
		[SerializeField, Required, SceneObjectsOnly] private Transform[] _points = null;

		public Vector3 GetPosition()
		{
			Vector3 position = _points[_index].position;
			_index++;

			if (_index == _points.Length)
				_index = 0;

			return position;
		}
	}
}
