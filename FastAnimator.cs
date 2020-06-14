using MEC;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Utilities
{
	public class FastAnimator : MonoBehaviour, IReactor
	{
		[SerializeField, Required, ChildGameObjectsOnly] private SpriteRenderer _spriteRenderer = null;
		[SerializeField, PageList] private Animation[] _animations = default;

		private Animation _currentAnimation = default;

		private void Awake()
		{
			for (int i = 0; i < _animations.Length; i++)
				_animations[i].OnAwake(_spriteRenderer);
		}

		[Button]
		public void PlayAnimation(int index) =>
			PlayAnimationInternal(index);

		[Button]
		public void StopAnimation() =>
			_currentAnimation?.Stop();

		public void HandleReaction() =>
			PlayAnimationInternal(0);

		private void PlayAnimationInternal(int index)
		{
			if (_currentAnimation != null)
				_currentAnimation.Stop();

			if (index >= _animations.Length)
				return;

			_currentAnimation = _animations[index];
			_animations[index].Play();
		}


		[System.Serializable]
		private class Animation
		{
			[SerializeField] private float _timeBetweenFrames = 1f;
			[SerializeField] private Frame[] _frames = null;

			private CoroutineHandle _coroutine = default;
			private SpriteRenderer _spriteRenderer = null;
			private GameObject _root = null;
			private int _index = 0;

			public void OnAwake(SpriteRenderer spriteRenderer)
			{
				_spriteRenderer = spriteRenderer;
				_root = spriteRenderer.gameObject;
			}

			public void Play() =>
				_coroutine = Timing.RunCoroutine(Process().CancelWith(_root));

			public void Stop() =>
				Timing.KillCoroutines(_coroutine);

			private IEnumerator<float> Process()
			{
				Frame firstFrame = _frames[0];

				_spriteRenderer.sprite = firstFrame.Sprite;
				firstFrame.OnFramePlayed.SendReaction();
				_index++;

				while (true)
				{
					yield return Timing.WaitForSeconds(_timeBetweenFrames);

					if (_index == _frames.Length)
						_index = 0;

					Frame currentFrame = _frames[_index];

					_spriteRenderer.sprite = currentFrame.Sprite;
					currentFrame.OnFramePlayed.SendReaction();
					_index++;
				}
			}
		}

		[System.Serializable]
		private struct Frame
		{
			[SerializeField, Required, AssetSelector] private Sprite _sprite;
			[SerializeField] private Reactor _onFramePlayed;

			public Sprite Sprite => _sprite;
			public Reactor OnFramePlayed => _onFramePlayed;
		}
	}
}