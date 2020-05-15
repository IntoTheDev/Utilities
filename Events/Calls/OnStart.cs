using ToolBox.Observer;

namespace ToolBox.Framework.Utilities
{
	public class OnStart : OnEvent
	{
		private void Start() =>
			reactors.Dispatch();
	}
}
