using System;

namespace Events
{
	public class Eventer : IGamePlayEvents
	{
		public event Action OnGameStarted;

		public void CallGameStartedEvent() => 
			OnGameStarted?.Invoke();
	}
}