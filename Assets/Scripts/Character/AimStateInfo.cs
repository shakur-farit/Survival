using System;

namespace Character
{
	public class AimStateInfo
	{
		public string StateName { get; set; }
		public float MinAngle { get; set; }
		public float MaxAngle { get; set; }
		public Action SwitchStateAction { get; set; }
	}
}