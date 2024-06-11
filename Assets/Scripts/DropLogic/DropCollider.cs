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
			if (other.TryGetComponent(out CharacterHealth health))
			{
				AddHealthToCharacter(health);
				Destroy();
			}
		}

		private void AddHealthToCharacter(CharacterHealth health) => 
			health.AddHealth(_drop.Value);

		private void Destroy() => 
			_dropFactory.Destroy(gameObject);
	}
}