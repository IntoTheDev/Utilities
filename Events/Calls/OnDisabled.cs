namespace ToolBox.Framework.Utilities
{
	public class OnDisabled : OnEvent
	{
		private void OnDisable() => events[index]?.Invoke();
	}
}
