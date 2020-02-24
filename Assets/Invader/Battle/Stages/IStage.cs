using System.Collections;
using System.Collections.Generic;
using Invader.Level;

namespace Invader.Stages
{
	public interface IStage
	{
		float LeftEdgePosX { get; }
		float RightEdgePosX { get; }

		ILevelData LevelData { get; }
	}
}
