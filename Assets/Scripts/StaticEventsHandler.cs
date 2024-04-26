using System;

namespace Assets.Scripts
{
	public static class StaticEventsHandler
	{
		public static event Action OnGameStarted;

		public static void CallGameStartedEvent() => 
			OnGameStarted?.Invoke();
	}
}