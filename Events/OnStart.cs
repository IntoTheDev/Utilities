public class OnStart : OnEvent
{
	private void Start() => onEvent?.Invoke();
}
