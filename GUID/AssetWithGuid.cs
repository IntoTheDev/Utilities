using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace ToolBox.Utilities
{
	[CreateAssetMenu(menuName = "ToolBox/Guid/Asset")]
	public class AssetWithGuid : ScriptableObject
	{
		[SerializeField, ReadOnly] private string _value = "";

		public string Value => _value;

#if UNITY_EDITOR
		private void OnEnable()
		{
			if (string.IsNullOrEmpty(_value))
				_value = Guid.NewGuid().ToString();
		}
#endif
	}
}
