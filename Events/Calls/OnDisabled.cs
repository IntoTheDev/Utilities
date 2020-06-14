namespace ToolBox.Utilities
{
	public class OnDisabled : OnEvent
	{
		private void OnDisable() =>
			_reactor.SendReaction();
	}
}
