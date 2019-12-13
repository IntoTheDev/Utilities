using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace ToolBox.Framework.Utilities
{
	public abstract class EventsContainer<T> : SerializedMonoBehaviour
	{
		[OdinSerialize, ListDrawerSettings(NumberOfItemsPerPage = 1)] protected EventsData[] eventsDatas = null;

		public abstract void ExecuteEvent(int index);

		[System.Serializable]
		protected struct EventsData
		{
			public T Events => events;

#if UNITY_EDITOR
			[SerializeField] private string editorName;
#endif

			[SerializeField] private T events;
		}
	}
}

