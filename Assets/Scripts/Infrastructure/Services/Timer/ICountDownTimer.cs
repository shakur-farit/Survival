using System;
using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.Timer
{
	public interface ICountDownTimer
	{
		UniTask Start(int durationInSeconds, Action onTick, Action onComplete);
		int GetTimeLeft();
	}
}