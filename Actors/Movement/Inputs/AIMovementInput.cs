using MEC;
using Pathfinding;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ActorMovement))]
public class AIMovementInput : MonoBehaviour, IMovementInput
{
	public UnityEvent OnPathComplete = null;

	public float MovementSpeed
	{
		get
		{
			return movementSpeed;
		}

		set
		{
			movementSpeed = value;
		}
	}

	public Vector2 Direction { get; private set; }

	[SerializeField, Required, FoldoutGroup("Components")] private ActorMovement actorMovement = null;

	[SerializeField, FoldoutGroup("Data")] private float stopDistance = 1f;
	[SerializeField, FoldoutGroup("Data")] private float nextWaypointDistance = 1f;
	[SerializeField, FoldoutGroup("Data")] private float movementSpeed = 5f;
	[SerializeField, FoldoutGroup("Data")] private LayerMask obstacles = default;

	[SerializeField, FoldoutGroup("Debug"), ReadOnly] private Vector3 desiredPosition = default;
	[SerializeField, FoldoutGroup("Debug"), ReadOnly] private Vector3 lastDesiredPosition = default;
	[SerializeField, FoldoutGroup("Debug"), ReadOnly] private bool isDesiredPositionVisible = false;

	private Transform cachedTransform = null;

	private Path path = null;
	private Seeker seeker = null;

	private int currentWaypoint = 0;
	private int waypointsCount = 0;
	private Vector2 direction = default;
	private float distance = 0f;
	private bool isLinear = false;

	private CoroutineHandle stateCoroutine = default;

	private void Awake()
	{
		cachedTransform = transform;
		seeker = GetComponent<Seeker>();
	}

	private void OnEnable()
	{
		actorMovement.SetInput(this);
		stateCoroutine = Timing.RunCoroutine(UpdateState(), Segment.SlowUpdate);
	}

	private void OnDisable()
	{
		actorMovement.SetInput(null);
		Timing.KillCoroutines(stateCoroutine);
		Direction = Vector2.zero;
		isLinear = false;
	}

	private void Update()
	{
		Vector3 position = cachedTransform.position;

		if (isDesiredPositionVisible && !isLinear)
		{
			Direction = Vector3.Normalize(desiredPosition - position) * movementSpeed;

			isLinear = true;
		}
		else if (path != null)
		{
			bool waypointsOut = !(currentWaypoint < waypointsCount);
			bool nextWaypointLast = !(currentWaypoint + 1 < waypointsCount);

			if (waypointsOut)
				return;

			float distanceToWaypoint = Vector2.Distance(position, path.vectorPath[currentWaypoint]);

			if (distanceToWaypoint < nextWaypointDistance)
			{
				currentWaypoint++;

				if (!nextWaypointLast)
					direction = Vector3.Normalize(path.vectorPath[currentWaypoint] - position);
				else
					direction = Vector2.zero;
			}

			Direction = direction * movementSpeed;
		}
	}

	private IEnumerator<float> UpdateState()
	{
		while (true)
		{
			UpdateVision();

			yield return Timing.WaitForOneFrame;
		}
	}

	public void MoveTo(Vector3 desiredPosition)
	{
		float distanceToOldPosition = Vector2.Distance(lastDesiredPosition, desiredPosition);

		if (distanceToOldPosition >= 1f)
		{
			isLinear = false;

			this.desiredPosition = desiredPosition;
			lastDesiredPosition = desiredPosition;

			Vector3 position = UpdateVision();

			if (!isDesiredPositionVisible)
				seeker.StartPath(position, desiredPosition, OnPathFound);
		}
	}

	private void OnPathFound(Path path)
	{
		if (!path.error)
		{
			this.path = path;

			currentWaypoint = 0;
			waypointsCount = 0;

			waypointsCount = path.vectorPath.Count;
			direction = Vector3.Normalize(path.vectorPath[0] - cachedTransform.position);
		}
	}

	private Vector3 UpdateVision()
	{
		Vector3 position = cachedTransform.position;
		Vector3 difference = desiredPosition - position;
		Vector3 direction = Vector3.Normalize(difference);
		distance = Vector3.Distance(position, desiredPosition);

		if (distance < stopDistance)
			Direction = Vector2.zero;

		isDesiredPositionVisible = !Physics2D.Raycast(position, direction, distance, obstacles);

		return position;
	}
}
