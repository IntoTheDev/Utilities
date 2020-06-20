using Sirenix.OdinInspector;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Utilities
{
    public class Switcher : MonoBehaviour, IReactor
    {
        [ShowInInspector, ReadOnly] private int _reactorIndex = 0;
        [SerializeField, PageList] private Reactor[] _reactors = null;

        private void Awake()
        {
            for (int i = 0; i < _reactors.Length; i++)
                _reactors[i].Setup();
        }

        [Button]
        public void HandleReaction()
        {
            _reactors[_reactorIndex].SendReaction();
            _reactorIndex = Extensions.Extensions.RoundRobin(_reactorIndex, _reactors.Length);
        }
    }
}
