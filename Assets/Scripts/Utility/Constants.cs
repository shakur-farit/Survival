namespace Utility
{
	public class Constants
	{
		// General
		public const float Epsilon = 0.001f;
		public const int ValueOfInfinity = -1;

		// Drop animation values
		public const int JumpPower = 2;
		public const int JumpNumber = 1;
		public const float JumDuration = 0.5f;
		public const int RotateDuration = 2;

		// Weapon reloading text animation values
		public const float BlinkDuration = 0.5f;
		public const float EndValue = 0;

		// Character aiming angle values
		public const float UpAndUpRightBorder = 67f;
		public const float UpAndUpLeftBorder = 115f;
		public const float LeftAndUpLeftBorder = 158f;
		public const float LeftAndDownBorder = -115f;
		public const float RightAndUpRightBorder = 22f;
		public const float RightAndDownBorder = -46f;
		public const float RightNegativeBorder = 0f;
		public const float LeftNegativeBorder = -180f;
		public const float LeftPositiveBorder = 180f;

		// Minimal distance to target for enemy move
		public const float MinDistanceToTarget = 1f;

		// Values for next bullet icon's position
		public const float NextIconYPositionStep = 15f;
		public const float NextIconXPositionStep = 30f;
		public const int MaxIconsInColumn = 20;
	}
}