public class OnDisabled : OnEvent
{
	private void OnDisable() => onEvent?.Invoke();
}
