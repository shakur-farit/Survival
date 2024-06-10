using Infrastructure.Services.Factories.Ammo;
using UnityEngine;

namespace Spawn
{
	public class DropSpawner : IDropSpawner
	{
		private readonly IDropFactory _dropFactory;

		public DropSpawner(IDropFactory dropFactory) => 
			_dropFactory = dropFactory;

		public void Spawn(Vector2 position)
		{
			Debug.Log("Drop");
			//_dropFactory.Create(position);
		}
	}
}