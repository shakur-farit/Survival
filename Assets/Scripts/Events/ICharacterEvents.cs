using System;

namespace Events
{
	public interface ICharacterEvents
	{
		event Action CharacterDead;
		void CallCharacterDeadEvent();
	}
}