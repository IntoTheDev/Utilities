using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using ToolBox.Groups;
using UnityEngine;
using UnityEngine.Events;

public class TargetDetection : SerializedMonoBehaviour
{
	public IReadOnlyList<Transform> BestTargets => bestPack.Entities;
	public IReadOnlyList<Transform>[] BestTargetsInGroups => entitiesGroups;
	public IReadOnlyList<Transform> AllTargets => entities;

	[OdinSerialize, ListDrawerSettings(
		Expanded = true,
		NumberOfItemsPerPage = 1,
		DraggableItems = false), FoldoutGroup("Data")] private EntityPack[] entityPacks = null;

	[SerializeField, ReadOnly, FoldoutGroup("Debug")] private EntityPack bestPack = null;

	private List<Transform> entities = null;
	private int entitiesCount = 0;

	private IReadOnlyList<Transform>[] entitiesGroups = null;

	private Transform cachedTransform = null;

	private void Awake()
	{
		for (int i = 0; i < entityPacks.Length; i++)
			entityPacks[i].Entities = new List<Transform>();

		Array.Sort(entityPacks, (left, right) => right.Priority.CompareTo(left.Priority));

		entities = new List<Transform>();
		cachedTransform = transform;

		entitiesGroups = new IReadOnlyList<Transform>[entityPacks.Length];

		for (int i = 0; i < entityPacks.Length; i++)
			entitiesGroups[i] = entityPacks[i].Entities;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject entity = collision.gameObject;
		Transform entityTransform = entity.transform;

		for (int i = 0; i < entityPacks.Length; i++)
		{
			EntityPack entityPack = entityPacks[i];
			List<Transform> entities = entityPack.Entities;

			if (Group.IsEntityInGroups(entity, entityPack.Groups, entityPack.CheckType) && !entities.Contains(entityTransform))
			{
				entities.Add(entityTransform);
				this.entities.Add(entityTransform);

				entityPack.Count++;
				entitiesCount++;

				SetBestPack();
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Transform entity = collision.transform;

		for (int i = 0; i < entityPacks.Length; i++)
		{
			EntityPack entityPack = entityPacks[i];
			List<Transform> entities = entityPack.Entities;

			if (entities.Contains(entity))
			{
				entities.Remove(entity);
				this.entities.Remove(entity);

				entityPack.Count--;
				entitiesCount--;

				SetBestPack();
			}
		}
	}

	private void SetBestPack()
	{
		for (int i = 0; i < entityPacks.Length; i++)
		{
			EntityPack entityPack = entityPacks[i];

			if (entityPack.Count != 0)
			{
				bestPack = entityPack;
				return;
			}
		}

		bestPack = null;
	}

	[System.Serializable]
	private class EntityPack
	{
		[ReadOnly, TabGroup("Debug")] public int Count = 0;
		[ReadOnly, TabGroup("Debug")] public List<Transform> Entities = null;

		public float Priority => priority;
		public Group[] Groups => groups;
		public CheckType CheckType => checkType;
		public UnityEvent Reaction => reaction;

#if UNITY_EDITOR
		[SerializeField, TabGroup("Debug"), PropertyOrder(-1)] private string packName = "";
#endif

		[SerializeField, TabGroup("Data")] private float priority = 0;
		[SerializeField, AssetSelector, ListDrawerSettings(Expanded = true), TabGroup("Data")] private Group[] groups = null;
		[SerializeField, EnumPaging, TabGroup("Data")] private CheckType checkType = CheckType.AllGroups;
		[SerializeField, TabGroup("Data")] private UnityEvent reaction = null;
	}
}
