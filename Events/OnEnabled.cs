namespace ToolBox.Framework.Utilities
{
	public class OnEnabled : OnEvent
	{
		private void OnEnable() => eventsContainer.ExecuteEvent(index);
	}
}
