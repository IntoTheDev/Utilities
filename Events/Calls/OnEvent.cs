using Sirenix.OdinInspector;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Utilities
{
	public abstract class OnEvent : MonoBehaviour
	{
		[SerializeField, ListDrawerSettings(Expanded = true)] protected Reactor _reactor = null;
	}
}
