using UnityEngine;

namespace ToolBox.Utilities
{
	public class EnterArea : TriggerArea
	{
		private void OnTriggerEnter2D(Collider2D collision) =>
			onEnter[0].Call(collision.gameObject);
	}
}

