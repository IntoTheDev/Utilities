namespace ToolBox.Utilities
{
	public class OnEnabled : OnEvent
	{
		private void OnEnable() =>
			localSignal.Dispatch();
	}
}
