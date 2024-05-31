using System;

namespace Events
{
	public class Eventer : IGamePlayEvents
	{
		public event Action GameStarted;

		public event Action CharacterDead;

		public void CallGameStartedEvent() => 
			GameStarted?.Invoke();

		public void CallCharacterDeadEvent() => 
			CharacterDead?.Invoke();
	}
}