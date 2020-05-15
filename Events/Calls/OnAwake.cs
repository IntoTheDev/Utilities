using ToolBox.Observer;

namespace ToolBox.Framework.Utilities
{
	public class OnAwake : OnEvent
	{
		private void Awake() =>
			reactors.Dispatch();
	}
}
