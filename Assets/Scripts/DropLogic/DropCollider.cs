using Character;
using Infrastructure.Services.Factories.Drop;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace DropLogic
{
	public class DropCollider : MonoBehaviour
	{
		[SerializeField] private Drop _drop;

		private IDropFactory _dropFactory;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IDropFactory dropFactory, IPersistentProgressService persistentProgressService)
		{
			_persistentProgressService = persistentProgressService;
			_dropFactory = dropFactory;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out CharacterDropPickuper pickuper))
			{
				PickupDrop(pickuper);
				RemoveFromDropList();
				Destroy();
			}
		}

		private void PickupDrop(CharacterDropPickuper pickuper) => 
			pickuper.PickupDrop(_drop.Type, _drop.Value);

		private void RemoveFromDropList() => 
			_persistentProgressService.Progress.DropData.DropsList.Remove(gameObject);

		private void Destroy() => 
			_dropFactory.Destroy(gameObject);
	}
}