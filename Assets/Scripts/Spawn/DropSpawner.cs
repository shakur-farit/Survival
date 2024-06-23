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

		public DropSpawner(IDropFactory dropFactory, IDropStaticDataInitializer dropStaticDataInitializer, 
			IDropInitializeMediator dropMediator)
		{
			_dropFactory = dropFactory;
			_dropStaticDataInitializer = dropStaticDataInitializer;
			_dropMediator = dropMediator;
		}

		public async void Spawn(Vector2 position)
		{
			await _dropFactory.Create(position);

			DropStaticData dropStaticData = _dropStaticDataInitializer.InitializeDropStaticData();

			_dropMediator.Initialize(dropStaticData);
		}
	}
}