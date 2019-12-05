using ToolBox.Attributes;
using UnityEngine;
using UnityEngine.Events;

public class InputEvents : MonoBehaviour
{
	[SerializeField, ReorderableList] private InputEvent[] inputEvents = null;

	private void Update()
	{
		for (int i = 0; i < inputEvents.Length; i++)
		{
			if (Input.GetButtonDown(inputEvents[i].Input))
				inputEvents[i].Events?.Invoke();
		}
	}


	[System.Serializable]
	private struct InputEvent
	{
		public string Input => input;
		public UnityEvent Events => events;

		[SerializeField] private string input;
		[SerializeField] private UnityEvent events;
	}
}
