namespace Game.Core.GameManager.Interfaces.Map.Models
{
	interface IField
	{
		bool IsMoveAble { get; }
		double SpeedModify { get; }
	}
}
