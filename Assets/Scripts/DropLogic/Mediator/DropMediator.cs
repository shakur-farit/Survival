using StaticData;

namespace DropLogic.Mediator
{
	public class DropMediator : IDropViewMediator, IDropValueMediator, IDropInitializeMediator
	{
		private DropView _view;
		private Drop _drop;

		public void RegisterView(DropView view) => 
			_view = view;

		public void RegisterDrop(Drop drop) => 
			_drop = drop;

		public void Initialize(DropStaticData dropStaticData)
		{
			_view.SetupView(dropStaticData);
			_drop.SetupValue(dropStaticData);
			_drop.SetupType(dropStaticData);
		}
	}
}