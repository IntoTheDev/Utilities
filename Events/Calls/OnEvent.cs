using Sirenix.OdinInspector;
using ToolBox.Modules;
using UnityEngine;

namespace ToolBox.Utilities
{
	public abstract class OnEvent : SerializedMonoBehaviour
	{
		[SerializeField, ListDrawerSettings(Expanded = true)] protected ModulesContainer modules = null;
	}
}
