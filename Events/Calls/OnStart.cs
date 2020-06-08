namespace ToolBox.Utilities
{
	public class OnStart : OnEvent
	{
		private void Start() =>
			reactors.Process();
	}
}
