using System;
using Cysharp.Threading.Tasks;

namespace Character.Shooting
{
	public interface IWeaponReloader
	{
		event Action WeaponReloaded;
		event Action ReloadInProgress;

		UniTask Reload();
	}
}