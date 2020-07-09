using MEC;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Utilities
{
    public class Updater : MonoBehaviour
	{
        [SerializeField] private Segment _segment = Segment.Update;
        [SerializeField, Required] private Reactor _reactor = null;

        private CoroutineHandle _coroutine = default;

        private void Awake()
        {
            _reactor.Setup();
            _coroutine = Timing.RunCoroutine(Update(), _segment);
        }

        private void OnEnable() =>
            Timing.ResumeCoroutines(_coroutine);

        private void OnDisable() =>
            Timing.PauseCoroutines(_coroutine);

        private void OnDestroy() =>
            Timing.KillCoroutines(_coroutine);

        private IEnumerator<float> Update()
        {
            while (true)
            {
                _reactor.SendReaction();

                yield return Timing.WaitForOneFrame;
            }
        }
    }
}
