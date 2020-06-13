using Sirenix.OdinInspector;
using ToolBox.Reactors;
using UnityEngine;
using UnityEngine.UI;

namespace ToolBox.Utilities
{
	public class ButtonReactor : MonoBehaviour
	{
		[SerializeField, Required, ChildGameObjectsOnly] private Button button = null;
		[SerializeField, Required] private Reactor onClick = null;

		private void OnEnable() =>
			button.onClick.AddListener(ProcessReactor);

		private void OnDisable() =>
			button.onClick.RemoveListener(ProcessReactor);

		private void ProcessReactor() =>
			onClick.SendReaction();
	}
}