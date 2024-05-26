using System;

namespace Events
{
	public class Eventer : IGamePlayEvents, IMouseButtonClickEvent
	{
		public event Action GameStarted;
		public event Action MouseButtonClicked;

		public void CallGameStartedEvent() => 
			GameStarted?.Invoke();

		public void CallMouseButtonClickedEvent() => 
			MouseButtonClicked?.Invoke();
	}
}