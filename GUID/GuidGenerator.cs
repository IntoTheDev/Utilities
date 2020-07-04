using Sirenix.OdinInspector;
using System;
using TMPro;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Utilities
{
	[DisallowMultipleComponent]
	public class GuidGenerator : MonoBehaviour
	{
		[SerializeField, ReadOnly] private string _value = "";

		public string Value => _value;

#if UNITY_EDITOR
		private void OnEnable()
		{
			if (string.IsNullOrEmpty(_value))
				_value = Guid.NewGuid().ToString();
		}
#endif
	}

	public class GuidDisplay : IReactor
	{
		[SerializeField, Required, AssetSelector] private AssetWithGuid _asset = null;
		[SerializeField, Required, SceneObjectsOnly] private TMP_Text _view = null;

		public void HandleReaction() =>
			_view.text = _asset.Value;
	}
}
