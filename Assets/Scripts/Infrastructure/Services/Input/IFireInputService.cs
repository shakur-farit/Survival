namespace Infrastructure.Services.Input
{
	public interface IFireInputService
	{
		bool IsFireButtonPressed { get; }
		void RegisterFireInputAction();
	}
}