using ToolBox.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Runtime
{
	public class Timer : MonoBehaviour
	{
		[SerializeField, ReorderableList] private TimerData[] timers = null;

		private UnityEvent events = null;

		private const string method = "InternalTimer";

		public void LaunchTimer(int index)
		{
			TimerData timer = timers[index];

			Vector2 possibleTime = timer.Time;
			events = timer.Events;

			float time = Random.Range(possibleTime.x, possibleTime.y);
			Invoke(method, time);
		}

		private void InternalTimer() => events?.Invoke();

		[System.Serializable]
		private struct TimerData
		{
			public Vector2 Time => time;
			public UnityEvent Events => events;


#if UNITY_EDITOR
			[SerializeField] private string editorName;
#endif
			[SerializeField] private Vector2 time;
			[SerializeField] private UnityEvent events;
		}
	}
}

