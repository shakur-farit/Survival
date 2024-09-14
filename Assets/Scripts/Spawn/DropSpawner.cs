using DropLogic;
using DropLogic.Factory;
using DropLogic.Mediator;
using StaticData;
using UnityEngine;

namespace Spawn
{
	public class DropSpawner : IDropSpawner
	{
		private readonly IDropFactory _dropFactory;
		private readonly IDropStaticDataInitializer _dropStaticDataInitializer;
		private readonly IDropInitializeMediator _dropMediator;
		private readonly IDropAnimator _dropAnimator;

		public DropSpawner(IDropFactory dropFactory, IDropStaticDataInitializer dropStaticDataInitializer, 
			IDropInitializeMediator dropMediator, IDropAnimator dropAnimator)
		{
			_dropFactory = dropFactory;
			_dropStaticDataInitializer = dropStaticDataInitializer;
			_dropMediator = dropMediator;
			_dropAnimator = dropAnimator;
		}

		public void Spawn(Vector2 position)
		{
			GameObject drop = _dropFactory.Create(position);

			DropStaticData dropStaticData = _dropStaticDataInitializer.InitializeDropStaticData();

			_dropMediator.Initialize(dropStaticData);

			Animate(drop);
		}

		private void Animate(GameObject drop)
		{
			_dropAnimator.Appear(drop.transform);
			_dropAnimator.Rotate(drop.transform);
		}
	}
}