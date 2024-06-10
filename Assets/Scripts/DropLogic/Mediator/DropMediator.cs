using StaticData;
using UnityEngine;

namespace DropLogic
{
	public class DropMediator : IDropViewMediator, IDropValueMediator, IDropInitializeMediator
	{
		private DropView _view;
		private Drop _drop;

		public void RegisterView(DropView view)
		{
			Debug.Log("Reg");
			_view = view;
		}

		public void RegisterDrop(Drop drop) => 
			_drop = drop;

		public void Initialize(DropStaticData dropStaticData)
		{
			Debug.Log("Init");
			_view.SetupView(dropStaticData);
			_drop.SetupValue(dropStaticData);
		}
	}
}