namespace Infrastructure.Services.Randomizer
{
	public interface IRandomService
	{
		float Next(float min, float max);
		int Next(int min, int max);
		int NextZeroToHundred();
	}
}