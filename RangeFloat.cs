using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Framework.Utilities
{
	[System.Serializable]
	public struct RangeFloat
	{
		[SerializeField] private Vector2 possibleValue;

		public float GenerateValue() =>
			Random.Range(possibleValue.x, possibleValue.y);
	}
}
