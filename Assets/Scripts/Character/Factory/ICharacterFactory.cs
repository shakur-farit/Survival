using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Character.Factory
{
	public interface ICharacterFactory
	{
		GameObject Character { get; }

		UniTask Create();
		void Destroy();
	}
}