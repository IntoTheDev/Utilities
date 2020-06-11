using Sirenix.OdinInspector;
using ToolBox.Signals.Local;
using UnityEngine;

namespace ToolBox.Utilities
{
	public abstract class OnEvent : MonoBehaviour
	{
		[SerializeReference, ListDrawerSettings(Expanded = true)] protected LocalSignal localSignal = null;

		protected virtual void Awake() =>
			localSignal.Initialize();
	}
}
