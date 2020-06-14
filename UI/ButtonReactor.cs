using Sirenix.OdinInspector;
using ToolBox.Reactors;
using UnityEngine;
using UnityEngine.UI;

namespace ToolBox.Utilities
{
	public class ButtonReactor : MonoBehaviour
	{
		[SerializeField, Required, ChildGameObjectsOnly] private Button _button = null;
		[SerializeField, Required] private Reactor _onClick = null;

		private void OnEnable() =>
			_button.onClick.AddListener(ProcessReactor);

		private void OnDisable() =>
			_button.onClick.RemoveListener(ProcessReactor);

		private void ProcessReactor() =>
			_onClick.SendReaction();
	}
}