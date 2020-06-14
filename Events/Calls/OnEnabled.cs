namespace ToolBox.Utilities
{
	public class OnEnabled : OnEvent
	{
		private void OnEnable() =>
			_reactor.SendReaction();
	}
}
