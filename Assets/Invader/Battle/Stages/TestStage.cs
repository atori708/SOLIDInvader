using System.Collections;
using System.Collections.Generic;
using Invader.Level;
using UnityEngine;

namespace Invader.Stages
{
	public class TestStage : IStage
	{
		private const float Depth = 8;
		private const float LeftEdgePosX = -10;
		private const float RightEdgePosX = 10;

		StageArea stageArea;
		public StageArea StageArea => stageArea;

		ILevelData levelData;
		public ILevelData LevelData => levelData;

		public TestStage(ILevelData levelData)
		{
			this.levelData = levelData;
			stageArea = new StageArea(Depth, LeftEdgePosX, RightEdgePosX);
		}
	}
}
