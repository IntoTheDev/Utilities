namespace ToolBox.Utilities
{
	public class OnStart : OnEvent
	{
		private void Start() =>
			localSignal.Dispatch();
	}
}
