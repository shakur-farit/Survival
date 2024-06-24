using System;
using System.Collections.Generic;
using Enemy;
using Enemy.States;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;

namespace Shop
{
	public class ShopItemStateMachine : MonoBehaviour, IShopItemStatesSwitcher, IShopItemStatesRegistrar
	{
		private readonly Dictionary<Type, IShopItemState> _statesDictionary = new();
		private IShopItemState _activeState;

		public void SwitchState<TState>(EnemyAnimator enemyAnimator) where TState : IEnemyAnimatorState
		{
			_activeState?.Exit();
			IShopItemState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : IShopItemState =>
			_statesDictionary.Add(typeof(TState), state);
	}

	public class WeaponShopItemState : IShopItemState
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IRandomService _randomizer;

		public WeaponShopItemState(IStaticDataService staticDataService, IRandomService randomizer)
		{
			_staticDataService = staticDataService;
			_randomizer = randomizer;
		}

		public void Enter()
		{
			int random = _randomizer.Next(0, _staticDataService.ShopItemsListStaticData.WeaponShopItemsList.Count);

			WeaponShopItemStaticData weaponShopItem = _staticDataService.ShopItemsListStaticData.WeaponShopItemsList[random];

		}

		public void Exit()
		{
			
		}
	}
}