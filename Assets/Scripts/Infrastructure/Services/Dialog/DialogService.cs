namespace Infrastructure.Services.Dialog
{
	public class DialogService : IDialogService
	{
		public string Text { get; private set; }

		public void UpdateText(string text) => 
			Text = text;
	}
}