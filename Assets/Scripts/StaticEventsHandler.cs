using System;

public static class StaticEventsHandler
{
	public static event Action OnGameStarted;

	public static void CallGameStartedEvent() => 
		OnGameStarted?.Invoke();
}