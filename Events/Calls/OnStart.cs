namespace ToolBox.Framework.Utilities
{
	public class OnStart : OnEvent
	{
		private void Start() => events[index]?.Invoke();
	}
}
