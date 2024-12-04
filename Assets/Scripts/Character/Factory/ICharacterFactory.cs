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