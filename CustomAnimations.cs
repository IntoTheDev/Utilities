using ToolBox.Attributes;
using UnityEngine;

namespace ToolBox.Framework.Utilities
{
	public class CustomAnimations : MonoBehaviour
	{
		[SerializeField, BoxGroup("Components")] private Animator animator = null;
		[SerializeField, BoxGroup("Data"), ReorderableList] private AnimationClip[] animations = null;

		private int[] hashes = null;

		private void Awake()
		{
			int count = animations.Length;
			hashes = new int[count];

			for (int i = 0; i < count; i++)
				hashes[i] = Animator.StringToHash(animations[i].name);
		}

		public void PlayAnimation(int index) => animator.Play(hashes[index], -1, 0f);
	}
}
