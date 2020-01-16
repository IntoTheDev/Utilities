using MEC;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Framework.Utilities
{
	[DisallowMultipleComponent]
	public class Timer : MonoBehaviour
	{
		[SerializeField, ListDrawerSettings(NumberOfItemsPerPage = 1, Expanded = true, DraggableItems = false), FoldoutGroup("Data")] private TimerData[] timers = null;

		private void OnDisable()
		{
			for (int i = 0; i < timers.Length; i++)
				Timing.KillCoroutines(timers[i].CoroutineHandle);
		}

		private IEnumerator<float> RunTimer(TimerData timerData)
		{
			yield return Timing.WaitForSeconds(timerData.GetTime());

			timerData.Events?.Invoke();
		}

		[Button("Launch Timer"), FoldoutGroup("Debug")]
		public void LaunchTimer(int index)
		{
			TimerData timerData = timers[index];
			timerData.CoroutineHandle = Timing.RunCoroutine(RunTimer(timerData));
		}

		[Button("Stop Timer"), FoldoutGroup("Debug")]
		public void StopTimer(int index) =>
			Timing.KillCoroutines(timers[index].CoroutineHandle);

		[System.Serializable]
		private class TimerData
		{
#if UNITY_EDITOR
			[SerializeField, FoldoutGroup("Debug")] private string editorName;
#endif

			public UnityEvent Events => events;
			public CoroutineHandle CoroutineHandle;

			[SerializeField, FoldoutGroup("Data")] private Vector2 possibleTime;
			[SerializeField, FoldoutGroup("Data")] private UnityEvent events;
			[SerializeField, ReadOnly, FoldoutGroup("Debug")] private float currentTime;

			public float GetTime()
			{
				currentTime = Random.Range(possibleTime.x, possibleTime.y);
				return currentTime;
			}
		}
	}
}

