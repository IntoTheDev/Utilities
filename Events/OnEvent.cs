using UnityEngine;
using UnityEngine.Events;

public abstract class OnEvent : MonoBehaviour
{
	[SerializeField] protected UnityEvent onEvent = null;
}
