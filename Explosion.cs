using Sirenix.OdinInspector;
using ToolBox.Extensions;
using UnityEngine;

namespace ToolBox.Framework.Utilities
{
	public class Explosion : MonoBehaviour
	{
		[SerializeField] private float force = 0f;
		[SerializeField] private float torque = 0f;
		[SerializeField] private float radius = 0f;
		[SerializeField] private LayerMask layerMask = default;

		private Transform cachedTransform = null;

		private void Awake() =>
			cachedTransform = transform;

		[Button("Explode", ButtonSizes.Medium)]
		public void Explode() =>
			Extensions.Extensions.OverlapCircle(cachedTransform.position, radius, layerMask, Push);

		private void Push(Collider2D[] colliders)
		{
			Vector2 position = cachedTransform.position;

			for (int i = 0; i < colliders.Length; i++)
			{
				Rigidbody2D body = colliders[i].GetComponent<Rigidbody2D>();

				if (body == null)
					continue;

				Vector2 bodyPosition = body.position;
				Vector2 direction = Vector3.Normalize(bodyPosition - position);
				Vector2 force = direction.Multiply(this.force);
				float torque = position.x > bodyPosition.x ? -this.torque : this.torque;

				body.AddForce(force, ForceMode2D.Impulse);
				body.AddTorque(torque, ForceMode2D.Impulse);
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, radius);
		}
	}
}
