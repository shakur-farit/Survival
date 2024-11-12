using System;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Soundtrack
{
	public class MusicSwitcher : IMusicSwitcher
	{
		public event Action MusicChanged;

		private readonly IStaticDataService _staticDataService;

		public AudioClip CurrentMusic { get; private set; }

		public MusicSwitcher(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		public void PlayMainMenu()
		{
			CurrentMusic = _staticDataService.SoundtrackStaticData.MainMenu;

			MusicChanged?.Invoke();
		}

		public void PlayEnemyBattle()
		{
			CurrentMusic = _staticDataService.SoundtrackStaticData.EnemyBattle;

			MusicChanged?.Invoke();
		}
	}
}