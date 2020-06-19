using Sirenix.OdinInspector;
using ToolBox.Extensions;
using ToolBox.Reactors;
using ToolBox.Tags;
using UnityEngine;

namespace ToolBox.Utilities
{
	[DisallowMultipleComponent, RequireComponent(typeof(Collider2D))]
	public abstract class TriggerArea : MonoBehaviour
	{
		[SerializeField, ListDrawerSettings(NumberOfItemsPerPage = 1, Expanded = true, DraggableItems = false), FoldoutGroup("Data")] protected EventsData[] _onEnter = null;

		[SerializeField, ReadOnly, FoldoutGroup("Debug")] protected int _index = 0;

		[Button("Set Index"), FoldoutGroup("Debug")]
		public void SetIndex(int index) =>
			_index = index;

		protected struct EventsData : ISetupable
		{
#if UNITY_EDITOR
			[SerializeField] private string _editorName;
#endif

			[SerializeField, AssetSelector] private Tag[] _tags;
			[SerializeField] private bool _allTagsRequired;
			[SerializeField] private Reactor _onEntityEnters;
			[SerializeField] private GameObjectReactor _onEntityEntersGeneric;

			public void Setup()
			{
				_onEntityEnters.Setup();
				_onEntityEntersGeneric.Setup();
			}

			public void Call(GameObject entity)
			{
				if (!entity.HasTags(_tags, _allTagsRequired))
					return;
				
				_onEntityEnters.SendReaction();
				_onEntityEntersGeneric.SendReaction(entity);
			}
		}
	}
}
