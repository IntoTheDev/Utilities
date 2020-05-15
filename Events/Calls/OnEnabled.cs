using ToolBox.Observer;

namespace ToolBox.Framework.Utilities
{
	public class OnEnabled : OnEvent
	{
		private void OnEnable() =>
			reactors.Dispatch();
	}
}
