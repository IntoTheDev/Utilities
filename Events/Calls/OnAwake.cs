namespace ToolBox.Framework.Utilities
{
	public class OnAwake : OnEvent
	{
		private void Awake() => events[index]?.Invoke();
	}
}
