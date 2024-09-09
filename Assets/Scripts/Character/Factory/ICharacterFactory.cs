using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Character.Factory
{
	public interface ICharacterFactory
	{
		GameObject Character { get; }

		void Create();
		void Destroy();
	}
}