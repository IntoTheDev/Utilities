using UnityEngine;

namespace ToolBox.Utilities
{
	[System.Serializable, HideLabel]
	public struct RangeFloat
	{
		[SerializeField, OnValueChanged(nameof(ProcessValue))] private Vector2 _possibleValue;

		public float Value => Random.Range(_possibleValue.x, _possibleValue.y);

		private void ProcessValue()
		{
			float firstValue = _possibleValue.x;

			if (_possibleValue.y < firstValue)
				_possibleValue.y = firstValue;
		}
	}
}
