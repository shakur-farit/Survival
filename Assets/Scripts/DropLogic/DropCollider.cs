using System;
using Character;
using DropLogic.Factory;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace DropLogic
{
	public class DropCollider : MonoBehaviour
	{
		[FormerlySerializedAs("_drop")] [SerializeField] private DropData dropData;

		private IDropFactory _dropFactory;
		private IDropAnimator _dropAnimator;

		[Inject]
		public void Constructor(IDropFactory dropFactory, IDropAnimator animator)
		{
			_dropFactory = dropFactory;
			_dropAnimator = animator;
		}

		private void OnDisable() => 
			StopAnimation();

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out CharacterDropPickuper pickuper))
			{
				PickupDrop(pickuper);
				Destroy();
			}
		}

		private void PickupDrop(CharacterDropPickuper pickuper) => 
			pickuper.PickupDrop(dropData.Type, dropData.Value);

		private void Destroy()
		{
			_dropFactory.DropsList.Remove(gameObject);
			_dropFactory.Destroy(gameObject);
		}

		private void StopAnimation() => 
			_dropAnimator.KillTwin(transform);
	}
}