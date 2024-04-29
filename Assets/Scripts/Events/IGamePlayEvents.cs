using System;

namespace Events
{
	public interface IGamePlayEvents
	{
		event Action OnGameStarted;
		void CallGameStartedEvent();
	}
}