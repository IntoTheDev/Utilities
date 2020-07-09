using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace ToolBox.Utilities
{
	[CreateAssetMenu(menuName = "ToolBox/Guid/Asset"), AssetSelector]
	public class AssetWithGuid : ScriptableObject
	{
		[SerializeField, ReadOnly] protected string _value = "";

		public string Value => _value;

		protected virtual void OnEnable()
		{
#if UNITY_EDITOR
			if (string.IsNullOrEmpty(_value))
				_value = Guid.NewGuid().ToString();
#endif
		}
	}
}
