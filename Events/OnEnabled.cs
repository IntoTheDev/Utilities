public class OnEnabled : OnEvent
{
	private void OnEnable() => onEvent?.Invoke();
}
