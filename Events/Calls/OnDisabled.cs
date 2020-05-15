using ToolBox.Observer;

namespace ToolBox.Framework.Utilities
{
	public class OnDisabled : OnEvent
	{
		private void OnDisable() =>
			reactors.Dispatch();
	}
}
