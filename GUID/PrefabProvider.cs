using Sirenix.OdinInspector;
#if UNITY_EDITOR
using Sirenix.Utilities.Editor;
#endif
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ToolBox.Utilities
{
	[CreateAssetMenu(menuName = "ToolBox/Guid/Prefab Provider"), AssetSelector, Required]
	public class PrefabProvider : ScriptableObject
	{
		[SerializeField, AssetList, Required, HideInPlayMode] private GuidGenerator[] _prefabs = null;
		[ShowInInspector, ReadOnly, HideInEditorMode] private Dictionary<string, GameObject> _objects = null;

#if UNITY_EDITOR
		private void Awake()
		{
			IEnumerable<GuidGenerator> prefabs = AssetUtilities.GetAllAssetsOfType<GuidGenerator>();
			_prefabs = prefabs.ToArray();
		}
#endif

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

		public GameObject Provide(string guid)
		{
			_objects.TryGetValue(guid, out GameObject prefab);
			return prefab;
		}
	}
}
