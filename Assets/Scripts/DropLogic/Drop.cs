using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;

namespace DropLogic
{
	public class Drop : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		private DropType _type;
		private int _value;

		private IStaticDataService _staticDataService;

		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake()
		{
			int min = 0;
			int max = 100;

			int random = Random.Range(min, max);

			if(random >= 0 && random <= 80)
				_type = DropType.Coin;
			else
				_type = DropType.Heart;

			foreach (DropStaticData dropStaticData in _staticDataService.DropsListStaticData.DropsList)
			{
				if (_type == dropStaticData.Type)
				{
					_spriteRenderer.sprite = dropStaticData.Sprite;
					_value = dropStaticData.Value;
				}
			}
		}
	}
}