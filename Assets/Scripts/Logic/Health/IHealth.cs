using System;

namespace Logic.Health
{
	public interface IHealth 
	{
		float Current { get; }
		float Max { get; }

		void TakeDamage(float damage);
		void AddHealth(float value);
	}
}
