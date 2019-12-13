using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	public Vector2 Position { get; private set; }
	public List<Node> Nodes { get; private set; } = new List<Node>();

	private Pathfinding pathfinding = null;

	private void Awake()
	{
		Position = transform.position;

		for (int i = 0; i < transform.childCount; i++)
		{
			Nodes.Add(transform.GetChild(i).GetComponent<Node>());
		}

		pathfinding = FindObjectOfType<Pathfinding>();
		pathfinding.AddNode(this);
	}

	private void OnDrawGizmos()
	{
		Transform cachedTransform = transform;
		int childCount = cachedTransform.childCount;

		Vector3 offset = new Vector3 { x = 0.5f, y = 0.5f };
		Vector3 newPosition = cachedTransform.position - offset;

		newPosition.x = Mathf.Round(newPosition.x);
		newPosition.y = Mathf.Round(newPosition.y);

		cachedTransform.position = newPosition + offset;

		for (int i = 0; i < childCount; i++)
		{
			Transform point = cachedTransform.GetChild(i);

			Gizmos.color = Color.green;
			Gizmos.DrawLine(cachedTransform.position, point.position);
		}
	}
}
