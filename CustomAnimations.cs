using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Framework.Utilities
{
	[RequireComponent(typeof(Animator))]
	public class CustomAnimations : MonoBehaviour
	{
		[SerializeField, FoldoutGroup("Components"), Required] private Animator animator = null;
		[SerializeField, FoldoutGroup("Data"), ListDrawerSettings(Expanded = true), AssetSelector] private AnimationClip[] animations = null;

		private int blend = 0;
		private int[] hashes = null;

		private void Awake()
		{
			int count = animations.Length;
			hashes = new int[count];
			blend = Animator.StringToHash("Blend");

			for (int i = 0; i < count; i++)
				hashes[i] = Animator.StringToHash(animations[i].name);
		}

		[Button("Play Animation"), FoldoutGroup("Debug")]
		public void PlayAnimation(int animationIndex) => animator.Play(hashes[animationIndex], -1, 0f);

		[Button("Play Animation at Random Frame"), FoldoutGroup("Debug")]
		public void PlayAnimationAtRandomFrame(int animationIndex) => animator.Play(hashes[animationIndex], -1, Random.value);

		[Button("Randomize Blend"), FoldoutGroup("Debug")]
		public void RandomizeBlend() => animator.SetFloat(blend, Random.value);
	}
}
