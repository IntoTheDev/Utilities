using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
	[SerializeField, ReadOnly] private List<Node> nodes = new List<Node>();
	[SerializeField] private Transform target = null;

	private int nodesCount = 0;

	[Button("Find")]
	private void Find()
	{
		Vector3 targetPosition = target.position;

		List<Node> opened = new List<Node>(nodesCount);
		List<Node> closed = new List<Node>(nodes);

		Node firstNode = closed[0];
		opened.Add(firstNode);
		closed.Remove(firstNode);

		while (opened.Count > 0)
		{
			Node currentNode = opened[0];
			Node nextNode = null;
			List<Node> nodes = currentNode.Nodes;

			int count = nodes.Count;
			float distance = Mathf.Infinity;

			for (int i = 0; i < count; i++)
			{
				Node node = nodes[i];
				float newDistance = Vector2.Distance(node.Position, targetPosition);

				if (newDistance < distance)
				{
					distance = newDistance;
					nextNode = node;
				}
			}

			currentNode = nextNode;
		}
	}

	public void AddNode(Node node)
	{
		nodes.Add(node);
		nodesCount++;
	}
}
