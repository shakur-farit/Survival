using System;
using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.Timer
{
	public interface ICountDownTimer
	{
		event Action Started;
		event Action Completed;

		UniTask Start(int durationInSeconds);
		int GetTimeLeft();
	}
}