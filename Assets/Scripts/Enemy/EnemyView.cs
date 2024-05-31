using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer BodySpriteRenderer;

		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake() =>
			BodySpriteRenderer.sprite = _staticDataService.EnemiesStaticDataList.EnemiesList[0].Sprite;
	}
}