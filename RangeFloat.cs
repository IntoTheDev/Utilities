using UnityEngine;

namespace ToolBox.Utilities
{
	[System.Serializable]
	public struct RangeFloat
	{
		[SerializeField] private Vector2 _possibleValue;

		public float Value => Random.Range(_possibleValue.x, _possibleValue.y);
	}
}
