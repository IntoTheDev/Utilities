using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "ToolBox/Sprite Animation"), AssetSelector]
public class SpriteAnimation : ScriptableObject
{
	[SerializeField, AssetSelector, PreviewField] private Sprite[] _sprites = null;

	public void LoadSprites(ref Sprite[] sprites)
	{
		sprites = new Sprite[_sprites.Length];
		_sprites.CopyTo(sprites, 0);
	}
}
