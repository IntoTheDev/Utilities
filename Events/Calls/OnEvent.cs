using Sirenix.OdinInspector;
using Sirenix.Serialization;
using ToolBox.Modules;

namespace ToolBox.Framework.Utilities
{
	public abstract class OnEvent : SerializedMonoBehaviour
	{
		[OdinSerialize, ListDrawerSettings(Expanded = true)] protected ModulesContainer reactors = default;
	}
}
