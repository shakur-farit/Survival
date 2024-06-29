using StaticData;

namespace DropLogic.Mediator
{
	public class DropMediator : IDropViewMediator, IDropValueMediator, IDropInitializeMediator
	{
		private DropView _view;
		private DropData _dropData;

		public void RegisterView(DropView view) => 
			_view = view;

		public void RegisterDrop(DropData dropData) => 
			_dropData = dropData;

		public void Initialize(DropStaticData dropStaticData)
		{
			_view.SetupView(dropStaticData);
			_dropData.SetupValue(dropStaticData);
			_dropData.SetupType(dropStaticData);
		}
	}
}