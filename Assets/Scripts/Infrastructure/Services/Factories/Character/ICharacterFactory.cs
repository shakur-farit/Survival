using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Factories.Character
{
	public interface ICharacterFactory
	{
		GameObject Character { get; }

		UniTask Create();
		void Destroy();
	}
}