using Cysharp.Threading.Tasks;
using UI.Windows;

namespace UI.Services.Windows
{
	public interface IWindowsService
	{
		UniTask Open(WindowType type);
		void Close(WindowType type);
	}
}