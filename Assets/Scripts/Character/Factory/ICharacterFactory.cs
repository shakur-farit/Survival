using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Character.Factory
{
	public interface ICharacterFactory
	{
		event Action<Transform> CharacterUsed;

		GameObject Character { get; }

		void Create();
		void Destroy();
	}
}