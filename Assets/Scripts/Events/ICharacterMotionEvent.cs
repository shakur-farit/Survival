using System;

namespace Events
{
	public interface ICharacterMotionEvent
	{
		event Action CharacterMotionSwitched;
		
		void CallCharacterMotionSwitchedEvent();
	}
}