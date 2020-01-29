using Sirenix.OdinInspector;
using ToolBox.Groups;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Framework.Utilities
{
	[DisallowMultipleComponent]
	public abstract class TriggerArea : MonoBehaviour
	{
		[SerializeField, ListDrawerSettings(NumberOfItemsPerPage = 1, Expanded = true, DraggableItems = false), FoldoutGroup("Data")] protected EventsData[] onEnter = null;

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
			[SerializeField] private UnityEvent events;

			public void Call(GameObject entity)
			{
				if (Group.IsEntityInGroups(entity, groups, CheckType.AllGroups))
					events?.Invoke();
			}
		}
	}
}
