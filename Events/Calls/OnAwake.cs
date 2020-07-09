namespace ToolBox.Utilities
{
	public class OnAwake : OnEvent
	{
		protected override void Awake()
		{
			base.Awake();
			_reactor.SendReaction();
			Destroy(this);
		}
	}
}
