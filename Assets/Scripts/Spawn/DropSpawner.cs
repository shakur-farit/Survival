using DropLogic;
using DropLogic.Mediator;
using Infrastructure.Services.Factories.Drop;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;

namespace Spawn
{
	public class DropSpawner : IDropSpawner
	{
		private readonly IDropFactory _dropFactory;
		private readonly IDropStaticDataInitializer _dropStaticDataInitializer;
		private readonly IDropInitializeMediator _dropMediator;
		private readonly IPersistentProgressService _persistentProgressService;

		public DropSpawner(IDropFactory dropFactory, IDropStaticDataInitializer dropStaticDataInitializer, 
			IDropInitializeMediator dropMediator, IPersistentProgressService persistentProgressService)
		{
			_dropFactory = dropFactory;
			_dropStaticDataInitializer = dropStaticDataInitializer;
			_dropMediator = dropMediator;
			_persistentProgressService = persistentProgressService;
		}

		public async void Spawn(Vector2 position)
		{
			GameObject drop = await _dropFactory.Create(position);

			DropStaticData dropStaticData = _dropStaticDataInitializer.InitializeDropStaticData();

			_dropMediator.Initialize(dropStaticData);

			_persistentProgressService.Progress.DropData.DropsList.Add(drop);
		}
	}
}