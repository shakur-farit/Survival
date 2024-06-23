using Character;
using DropLogic.Factory;
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
				PickupDrop(pickuper);
				Destroy();
			}
		}

		private void PickupDrop(CharacterDropPickuper pickuper) => 
			pickuper.PickupDrop(_drop.Type, _drop.Value);

		private void Destroy()
		{
			_dropFactory.DropsList.Remove(gameObject);
			_dropFactory.Destroy(gameObject);
		}
	}
}