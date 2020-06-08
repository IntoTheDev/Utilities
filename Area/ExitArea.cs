using UnityEngine;

namespace ToolBox.Utilities
{
	public class ExitArea : TriggerArea
	{
		private void OnTriggerExit2D(Collider2D collision) =>
			onEnter[index].Call(collision.gameObject);
	}
}

