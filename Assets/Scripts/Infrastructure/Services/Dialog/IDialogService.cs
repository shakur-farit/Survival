namespace Infrastructure.Services.Dialog
{
	public interface IDialogService
	{
		string Text { get; }
		void UpdateText(string text);
	}
}