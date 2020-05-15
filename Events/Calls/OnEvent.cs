using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using ToolBox.Observer;

namespace ToolBox.Framework.Utilities
{
	public abstract class OnEvent : SerializedMonoBehaviour
	{
		[OdinSerialize, ListDrawerSettings(Expanded = true)] protected IReactor[] reactors = null;
	}

}
