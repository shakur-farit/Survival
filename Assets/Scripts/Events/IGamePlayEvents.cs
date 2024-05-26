using System;

namespace Events
{
	public interface IGamePlayEvents
	{
		event Action GameStarted;
		void CallGameStartedEvent();
	}
}