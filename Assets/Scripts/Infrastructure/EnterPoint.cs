using UnityEngine;

namespace Infrastructure
{
	public class EnterPoint : MonoBehaviour
	{
		private Game _game;

		void Start() => 
			_game = new Game();
	}
}