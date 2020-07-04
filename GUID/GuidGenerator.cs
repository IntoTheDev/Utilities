using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace ToolBox.Utilities
{
	[DisallowMultipleComponent]
	public class GuidGenerator : MonoBehaviour
	{
		[SerializeField, ReadOnly] private string _prefabValue = null;
		[SerializeField, ReadOnly] private string _instanceValue = null;

		public string PrefabValue => _prefabValue;
		public string InstanceValue => _instanceValue;

		private void OnValidate()
		{
			if (Application.isPlaying)
				return;

			Generate(ref _prefabValue);

			GameObject obj = gameObject;
			string sceneName = obj.scene.name;

			if (sceneName != obj.name && obj.activeInHierarchy)
				Generate(ref _instanceValue);
			else
				_instanceValue = null;
		}

		private void Generate(ref string value)
		{
			if (string.IsNullOrEmpty(value))
				value = Guid.NewGuid().ToString();
		}
	}
}
