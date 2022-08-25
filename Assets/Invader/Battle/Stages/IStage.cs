using System.Collections;
using System.Collections.Generic;
using Invader.Level;

namespace Invader.Stages
{
	/// <summary>
	/// ステージの範囲を示す値オブジェクト
	/// </summary>
	public class StageArea
	{
		public float Depth { get; private set; }
		public float LeftEdgePosX { get; private set; }
		public float RightEdgePosX { get; private set; }

		public StageArea(float depth, float leftEdgePosX, float rightEdgePosX)
		{
			LeftEdgePosX = leftEdgePosX;
			RightEdgePosX = rightEdgePosX;
			Depth = depth;
		}
	}

	public interface IStage
	{
		StageArea StageArea { get; }

		ILevelData LevelData { get; }
	}
}
