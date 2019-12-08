using System.Collections.Generic;
using ToolBox.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Runtime
{
	[DisallowMultipleComponent]
	public class Timer : MonoBehaviour
	{
		[SerializeField, ReorderableList] private TimerData[] timers = null;
		[SerializeField, ReadOnly] private int eventsCount = 0;

		private List<TimerData> timerDatas = new List<TimerData>();

		private void Update()
		{
			float deltaTime = Time.deltaTime;

			for (int i = eventsCount - 1; i >= 0; i--)
			{
				TimerData timer = timerDatas[i];
				timer.CurrentTime -= deltaTime;

				if (timer.CurrentTime <= 0f)
				{
					timer.Events?.Invoke();
					timerDatas.Remove(timer);
					eventsCount--;
				}
			}
		}

		public void LaunchTimer(int index)
		{
			TimerData timer = timers[index];

			if (timerDatas.Contains(timer))
				return;

			Vector2 possibleTime = timer.Time;
			timer.CurrentTime = Random.Range(possibleTime.x, possibleTime.y);
			timerDatas.Add(timer);
			eventsCount++;
		}

		[System.Serializable]
		private class TimerData
		{
#if UNITY_EDITOR
			[SerializeField] private string editorName;
#endif

			public float CurrentTime;
			public Vector2 Time => time;
			public UnityEvent Events => events;

			[SerializeField] private Vector2 time;
			[SerializeField] private UnityEvent events;
		}
	}
}

