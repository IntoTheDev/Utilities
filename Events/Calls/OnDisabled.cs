namespace ToolBox.Utilities
{
	public class OnDisabled : OnEvent
	{
		private void OnDisable() =>
			reactors.Process();
	}
}
