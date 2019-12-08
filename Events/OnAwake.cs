public class OnAwake : OnEvent
{
	private void Awake() => onEvent?.Invoke();
}
