using System;

namespace Events
{
	public interface ICharacterMoveEvent
	{
		event Action CharacterStartedMove;
		
		void CallCharacterStartedMove();
	}
}