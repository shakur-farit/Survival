using System;
using UnityEngine;

namespace Soundtrack
{
	public interface IMusicSwitcher
	{
		event Action MusicChanged;
		AudioClip CurrentMusic { get; }
		void PlayMainMenu();
		void PlayEnemyBattle();
	}
}