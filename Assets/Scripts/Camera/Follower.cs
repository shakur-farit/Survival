using Character.Factory;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Camera
{
	public class Follower : MonoBehaviour
	{
		[SerializeField] private CinemachineVirtualCamera _camera;
		
		private ICharacterFactory _characterFactory;

		[Inject]
		public void Constructor(ICharacterFactory characterFactory) => 
			_characterFactory = characterFactory;

		private void OnEnable() => 
			FollowToCharacter(_characterFactory.Character);

		private void FollowToCharacter(GameObject character)
		{
			if(character == null)
				return;
			
			_camera.Follow = character.transform;
		}
	}
}