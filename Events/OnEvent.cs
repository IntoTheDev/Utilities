using UnityEngine;

namespace ToolBox.Framework.Utilities
{
	[RequireComponent(typeof(EventsContainer))]
	public abstract class OnEvent : MonoBehaviour
	{
		[SerializeField] protected EventsContainer eventsContainer = null;
		[SerializeField] protected int index = 0;

		public void SetIndex(int index) => this.index = index;
	}

}
