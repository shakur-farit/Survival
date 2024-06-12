using Character;
using Infrastructure.Services.Factories.Drop;
using UnityEngine;
using Zenject;

namespace DropLogic
{
	public class DropCollider : MonoBehaviour
	{
		[SerializeField] private Drop _drop;

		private IDropFactory _dropFactory;

		[Inject]
		public void Constructor(IDropFactory dropFactory) => 
			_dropFactory = dropFactory;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out CharacterDropPickuper pickuper))
			{
				pickuper.PickupDrop(_drop.Type, _drop.Value);
				Destroy();
			}
		}

		private void Destroy() => 
			_dropFactory.Destroy(gameObject);
	}
}