using DropLogic.Mediator;
using StaticData;
using UnityEngine;
using Zenject;

namespace DropLogic
{
	public class Drop : MonoBehaviour
	{
		private int _value;

		private IDropValueMediator _mediator;

		public int Value => _value;

		[Inject]
		public void Constructor(IDropValueMediator mediator) =>
			_mediator = mediator;

		private void Awake() =>
			_mediator.RegisterDrop(this);

		public void SetupValue(DropStaticData dropStaticData) => 
			_value = dropStaticData.Value;
	}
}