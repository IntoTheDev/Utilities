using Sirenix.OdinInspector;
using Sirenix.Serialization;
using ToolBox.Groups;
using ToolBox.Modules;
using UnityEngine;

namespace ToolBox.Framework.Utilities
{
	[DisallowMultipleComponent, RequireComponent(typeof(Collider2D))]
	public abstract class TriggerArea : SerializedMonoBehaviour
	{
		[OdinSerialize, ListDrawerSettings(NumberOfItemsPerPage = 1, Expanded = true, DraggableItems = false), FoldoutGroup("Data")] protected EventsData[] onEnter = null;

		[SerializeField, ReadOnly, FoldoutGroup("Debug")] protected int index = 0;

		[Button("Set Index"), FoldoutGroup("Debug")]
		public void SetIndex(int index) =>
			this.index = index;

		[System.Serializable]
		protected struct EventsData
		{
#if UNITY_EDITOR
			[SerializeField] private string editorName;
#endif

			[SerializeField, AssetSelector] private Group[] groups;
			[SerializeField] private ModulesContainer reactors;
			[SerializeField] private ModulesContainer<GameObject> reactorsGeneric;

			public void Call(GameObject entity)
			{
				if (!Group.IsEntityInGroups(entity, groups, CheckType.AllGroups))
					return;

				reactors.Process();
				reactorsGeneric.Process(entity);
			}
		}
	}
}
