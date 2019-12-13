using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Framework.Utilities
{
	[RequireComponent(typeof(Animator))]
	public class CustomAnimations : MonoBehaviour
	{
		[SerializeField, FoldoutGroup("Components"), Required] private Animator animator = null;
		[SerializeField, FoldoutGroup("Data")] private AnimationClip[] animations = null;

		private int[] hashes = null;

		private void Awake()
		{
			int count = animations.Length;
			hashes = new int[count];

			for (int i = 0; i < count; i++)
				hashes[i] = Animator.StringToHash(animations[i].name);
		}

		[Button("Play Animation")]
		public void PlayAnimation(int index) => animator.Play(hashes[index], -1, 0f);
	}
}
