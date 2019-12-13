namespace ToolBox.Framework.Utilities
{
	public class BetterEventsContainer : EventsContainer<BetterEvent>
	{
		public override void ExecuteEvent(int index) => eventsDatas[index].Events.Invoke();
	}
}

