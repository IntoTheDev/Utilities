using ToolBox.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Framework.Utilities
{
	public class EventsContainer : MonoBehaviour
	{
		[SerializeField, ReorderableList] private EventsData[] eventsDatas = null;

		public void ExecuteEvent(int index) => eventsDatas[index].Events?.Invoke();

		[System.Serializable]
		private struct EventsData
		{
			public UnityEvent Events => events;

#if UNITY_EDITOR
			[SerializeField] private string editorName;
#endif

			[SerializeField] private UnityEvent events;
		}
	}
}

