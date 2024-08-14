using DG.Tweening;
using UnityEngine;
using Utility;

namespace Character
{
	public class CharacterBlinker : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _character;
		
		private Color _originalColor;

		private void OnDestroy() => 
			DOTween.Kill(_character);

		private void Awake() => 
			_originalColor = _character.color;

		public void BlinkOnDamaged() =>
			_character.DOColor(Color.red, Constants.CharacterSpriteBlinkDuration)
				.OnComplete(() => _character.DOColor(_originalColor, Constants.CharacterSpriteBlinkDuration));

		public void BlinkOnHealed() =>
			_character.DOColor(new Color(0f, 221f, 17f), Constants.CharacterSpriteBlinkDuration)
				.OnComplete(() => _character.DOColor(_originalColor, Constants.CharacterSpriteBlinkDuration));
	}
}