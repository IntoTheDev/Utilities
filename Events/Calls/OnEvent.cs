using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace ToolBox.Framework.Utilities
{
	public abstract class OnEvent : MonoBehaviour
	{
		[SerializeField, ListDrawerSettings(NumberOfItemsPerPage = 1)] protected UnityEvent[] events = null;
		[SerializeField] protected int index = 0;

		public void SetIndex(int index) => this.index = index;
	}

}
