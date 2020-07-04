using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Utilities
{
	[CreateAssetMenu(menuName = "ToolBox/Guid/Prefab Provider"), AssetSelector]
	public class PrefabProvider : ScriptableObject
	{
		[SerializeField, AssetList, Required] private GuidGenerator[] _prefabs = null;

		private Dictionary<string, GameObject> _objects = null;

		private void OnEnable()
		{
			int count = _prefabs.Length;
			_objects = new Dictionary<string, GameObject>(count);

			for (int i = 0; i < count; i++)
			{
				GuidGenerator prefab = _prefabs[i];
				_objects.Add(prefab.PrefabValue, prefab.gameObject);
			}
		}

		public GameObject GetPrefab(string guid)
		{
			_objects.TryGetValue(guid, out GameObject prefab);
			return prefab;
		}
	}
}
