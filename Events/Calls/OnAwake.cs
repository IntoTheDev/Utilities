namespace ToolBox.Utilities
{
	public class OnAwake : OnEvent
	{
		private void Awake() =>
			reactors.Process();
	}
}
