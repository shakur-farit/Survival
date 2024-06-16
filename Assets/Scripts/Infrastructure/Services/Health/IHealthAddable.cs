namespace Infrastructure.Services.Health
{
	public interface IHealthAddable : IHealth
	{
		void AddHealth(int value);
	}
}