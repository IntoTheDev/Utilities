namespace ToolBox.Framework.Utilities
{
	public class OnDisabled : OnEvent
	{
		private void OnDisable() => eventsContainer.ExecuteEvent(index);
	}
}
