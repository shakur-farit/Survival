using System;

namespace Events
{
	public interface ICharacterAimEvent
	{
		event Action CharacterAimSwitched;
		void CallCharacterAimSwitchedEvent();
	}
}