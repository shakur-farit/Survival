using System;
using Cysharp.Threading.Tasks;

namespace Character.Shooting
{
	public interface IWeaponReloader
	{
		event Action WeaponReloaded;
		int AmmoCount { get; }
		UniTask Reload();
		event Action ReloadInProgress;
	}
}