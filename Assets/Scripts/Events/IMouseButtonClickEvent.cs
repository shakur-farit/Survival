using System;

namespace Events
{
	public interface IMouseButtonClickEvent
	{
		event Action MouseButtonClicked;
		void CallMouseButtonClickedEvent();
	}
}