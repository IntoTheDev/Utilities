using Sirenix.OdinInspector;
using System;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Utilities
{
	[DisallowMultipleComponent]
	public class GuidGenerator : MonoBehaviour
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
