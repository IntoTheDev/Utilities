using Sirenix.OdinInspector;
using System;
using ToolBox.Test;
using UnityEngine;

namespace ToolBox.Utilities
{
	[DisallowMultipleComponent, DefaultExecutionOrder(-100)]
	public class GuidGenerator : MonoBehaviour
	{
		[SerializeField, ReadOnly] private string _prefabValue = null;

		public string PrefabValue => _prefabValue;

		private void OnValidate()
		{
			if (string.IsNullOrEmpty(_prefabValue))
				_prefabValue = Guid.NewGuid().ToString();
		}

		[Button]
		private void GeneratePrefabValue() =>
			_prefabValue = Guid.NewGuid().ToString();
	}
}
