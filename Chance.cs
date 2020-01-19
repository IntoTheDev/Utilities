﻿using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ToolBox.Framework.Utilities
{
	public class Chance : MonoBehaviour
	{
		[SerializeField, ListDrawerSettings(
			NumberOfItemsPerPage = 1,
			Expanded = true,
			DraggableItems = false)] private EventData[] events = null;

		public void Process(int index) =>
			events[index].InvokeOnSuccess();

		[System.Serializable]
		private struct EventData
		{
			[SerializeField, Range(0f, 1f)] private float chance;
			[SerializeField] private UnityEvent onSuccess;

			public void InvokeOnSuccess()
			{
				if (Extensions.Extensions.PercentChance(chance))
					onSuccess?.Invoke();
			}
		}
	}
}