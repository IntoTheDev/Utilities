using MEC;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using ToolBox.Modules;
using UnityEngine;

namespace ToolBox.Utilities
{
	public class FastAnimator : MonoBehaviour, IModule
	{
		[SerializeField, Required, ChildGameObjectsOnly] private SpriteRenderer spriteRenderer = null;
		[SerializeField, PageList] private Animation[] animations = default;

		private Animation currentAnimation = default;

		private void Awake()
		{
			for (int i = 0; i < animations.Length; i++)
				animations[i].OnAwake(spriteRenderer);
		}

		[Button]
		public void PlayAnimation(int index) =>
			PlayAnimationInternal(index);

		[Button]
		public void StopAnimation() =>
			currentAnimation?.Stop();

		public void Process() =>
			PlayAnimationInternal(0);

		private void PlayAnimationInternal(int index)
		{
			if (currentAnimation != null)
				currentAnimation.Stop();

			if (index >= animations.Length)
				return;

			currentAnimation = animations[index];
			animations[index].Play();
		}

		[System.Serializable]
		private class Animation
		{
			[SerializeField] private float timeBetweenFrames = 1f;
			[SerializeField] private Frame[] frames = null;

			private CoroutineHandle coroutine = default;
			private SpriteRenderer spriteRenderer = null;
			private GameObject root = null;
			private int index = 0;

			public void OnAwake(SpriteRenderer spriteRenderer)
			{
				this.spriteRenderer = spriteRenderer;
				root = spriteRenderer.gameObject;
			}

			public void Play() =>
				coroutine = Timing.RunCoroutine(Process().CancelWith(root));

			public void Stop() =>
				Timing.KillCoroutines(coroutine);

			private IEnumerator<float> Process()
			{
				Frame firstFrame = frames[0];

				spriteRenderer.sprite = firstFrame.Sprite;
				firstFrame.OnFramePlayed.Process();
				index++;

				while (true)
				{
					yield return Timing.WaitForSeconds(timeBetweenFrames);

					if (index == frames.Length)
						index = 0;

					Frame currentFrame = frames[index];

					spriteRenderer.sprite = currentFrame.Sprite;
					currentFrame.OnFramePlayed.Process();
					index++;
				}
			}
		}

		[System.Serializable]
		private struct Frame
		{
			[SerializeField, Required, AssetSelector] private Sprite sprite;
			[SerializeField] private ModulesContainer onFramePlayed;

			public Sprite Sprite => sprite;
			public ModulesContainer OnFramePlayed => onFramePlayed;
		}
	}
}