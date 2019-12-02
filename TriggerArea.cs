using ToolBox.Attributes;
using ToolBox.Groups;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Runtime
{
	[DisallowMultipleComponent, RequireComponent(typeof(BoxCollider2D))]
	public class TriggerArea : MonoBehaviour
	{
		[SerializeField, ReorderableList] private EventsData[] eventsData = null;

		private int index = 0;

		private void OnTriggerEnter2D(Collider2D collision) => eventsData[index].Call(collision.gameObject);

		public void SetIndex(int index) => this.index = index;

		[System.Serializable]
		private struct EventsData
		{
#if UNITY_EDITOR
			[SerializeField] private string editorName;
#endif

			[SerializeField] private Group[] groups;
			[SerializeField] private UnityEvent events;

			public void Call(GameObject entity)
			{
				if (Group.IsEntityInGroups(entity, groups, CheckType.AllGroups))
					events?.Invoke();
			}
		}
	}
}
