using Sirenix.OdinInspector;
using ToolBox.Modules;
using UnityEngine;

namespace ToolBox.Utilities
{
	public abstract class OnEvent : MonoBehaviour
	{
		[SerializeField, ListDrawerSettings(Expanded = true)] protected ModulesContainer reactors = null;
	}
}
