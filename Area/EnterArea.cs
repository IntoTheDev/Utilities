using UnityEngine;

namespace ToolBox.Utilities
{
	public class EnterArea : TriggerArea
	{
		private void OnTriggerEnter2D(Collider2D collision) =>
			_onEnter[_index].Call(collision.gameObject);
	}
}

