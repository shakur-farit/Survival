using System;

namespace Events
{
	public class Eventer : IGamePlayEvents, ICharacterMotionEvent, ICharacterAimEvent
	{
		public event Action GameStarted;
		public event Action CharacterMotionSwitched;
		public event Action CharacterAimSwitched;

		public void CallGameStartedEvent() => 
			GameStarted?.Invoke();

		public void CallCharacterMotionSwitchedEvent() => 
			CharacterMotionSwitched?.Invoke();

		public void CallCharacterAimSwitchedEvent() => 
			CharacterAimSwitched?.Invoke();
	}
}