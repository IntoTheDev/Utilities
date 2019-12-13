using UnityEngine.Events;

namespace ToolBox.Framework.Utilities
{
	public class UnityEventsContainer : EventsContainer<UnityEvent>
	{
		public override void ExecuteEvent(int index) => eventsDatas[index].Events?.Invoke();
	}
}

