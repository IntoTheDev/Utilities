using MEC;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Utilities
{
	public class PeriodicReactor : MonoBehaviour, IReactor
	{
		[SerializeField, TabGroup("Data")] private float _interval = 1f;
		[SerializeField, TabGroup("Data")] private bool _runOnAwake = true;
		[ShowInInspector, ReadOnly, TabGroup("Data")] private bool _running = false;

		[SerializeField, TabGroup("Reactor")] private Reactor _reactor = null;

		private CoroutineHandle _coroutineHandle = default;
		private GameObject _gameObject = null;

		private void Awake()
		{
			_reactor.Setup();
			_gameObject = gameObject;

			if (_runOnAwake)
				HandleReaction();
		}

		public void HandleReaction()
		{
			if (!_running)
				_coroutineHandle = Timing.RunCoroutine(Process().CancelWith(_gameObject));
		}

		public void Stop()
		{
			if (_running)
				return;

			Timing.KillCoroutines(_coroutineHandle);
			_running = false;
		}

		private IEnumerator<float> Process()
		{
			_running = true;

			while (true)
			{
				_reactor.SendReaction();

				yield return Timing.WaitForSeconds(_interval);
			}
		}
	}
}
