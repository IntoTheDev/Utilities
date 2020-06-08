namespace ToolBox.Utilities
{
	public class OnDisabled : OnEvent
	{
		private void OnDisable() =>
			modules.Process();
	}
}
