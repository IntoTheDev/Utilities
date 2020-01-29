using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Framework.Utilities
{
	[System.Serializable]
	public struct RangeFloat
	{
		[SerializeField, ReadOnly] public float Value;

		[SerializeField] private Vector2 possibleValue;

		public void GenerateValue() =>
			Value = Random.Range(possibleValue.x, possibleValue.y);
	}
}
