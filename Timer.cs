using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Framework.Utilities
{
	[DisallowMultipleComponent]
	public class Timer : MonoBehaviour
	{
		[SerializeField, ListDrawerSettings(NumberOfItemsPerPage = 1), FoldoutGroup("Data")] private TimerData[] timers = null;
		[SerializeField, ReadOnly, FoldoutGroup("Debug")] private int timersCount = 0;

		private List<TimerData> timerDatas = new List<TimerData>();

		private void Update()
		{
			float deltaTime = Time.deltaTime;

			for (int i = timersCount - 1; i >= 0; i--)
			{
				TimerData timer = timerDatas[i];
				timer.CurrentTime -= deltaTime;

				if (timer.CurrentTime <= 0f)
				{
					timer.Events?.Invoke();
					timerDatas.Remove(timer);
					timersCount--;
				}
			}
		}

		[Button("Launch Timer"), FoldoutGroup("Debug")]
		public void LaunchTimer(int index)
		{
			TimerData timer = timers[index];

			if (timerDatas.Contains(timer))
				return;

			Vector2 possibleTime = timer.Time;
			timer.CurrentTime = Random.Range(possibleTime.x, possibleTime.y);
			timerDatas.Add(timer);
			timersCount++;
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

