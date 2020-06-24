using Sirenix.OdinInspector;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Utilities
{
    public class Counter : MonoBehaviour, IReactor
    {
        [SerializeField, TabGroup("Data")] private int _requiredValue = 0;
        [ShowInInspector, ReadOnly, TabGroup("Data")] private int _currentValue = 0;
        [ShowInInspector, ReadOnly, TabGroup("Data")] private bool _isWorking = true;

        [SerializeField, TabGroup("Reactor")] private Reactor _onValueReached = null;

        private void Awake() =>
            _onValueReached.Setup();

        public void HandleReaction() =>
            InternalIncreaseValue();

        public void Refresh()
        {
            _currentValue = 0;
            _isWorking = true;
        }

        private void InternalIncreaseValue()
        {
            if (!_isWorking)
                return;

            _currentValue++;

            if (_currentValue == _requiredValue)
            {
                _onValueReached.SendReaction();
                _isWorking = false;
            }
        }
    }
}
