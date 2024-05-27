using System;

namespace Events
{
	public class Eventer : IGamePlayEvents, ICharacterMoveEvent
	{
		public event Action GameStarted;
		public event Action CharacterStartedMove;

		public void CallGameStartedEvent() => 
			GameStarted?.Invoke();

		public void CallCharacterStartedMove() => 
			CharacterStartedMove?.Invoke();
	}
}