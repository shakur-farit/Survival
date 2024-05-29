using System;

namespace Events
{
	public class Eventer : IGamePlayEvents, ICharacterEvents
	{
		public event Action GameStarted;

		public event Action CharacterDead;

		public void CallGameStartedEvent() => 
			GameStarted?.Invoke();

		public void CallCharacterDeadEvent() => 
			CharacterDead?.Invoke();
	}
}