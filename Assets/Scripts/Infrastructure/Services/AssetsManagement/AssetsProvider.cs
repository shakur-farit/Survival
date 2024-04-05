using UnityEngine;
using Zenject;

namespace Infrastructure.Services.AssetsManagement
{
	public class AssetsProvider
	{
		private readonly DiContainer _diContainer;

		public AssetsProvider(DiContainer diContainer) => 
			_diContainer = diContainer;

		public GameObject Instantiate(string heroAddress) => 
			_diContainer.InstantiatePrefabResource(heroAddress);
	}
}