using System.Collections;
using System.Collections.Generic;
using Invader.Level;
using UnityEngine;

namespace Invader.Stages
{
	public class TestStage : IStage
	{
		public float LeftEdgePosX => -10;

		public float RightEdgePosX => 10;

		ILevelData levelData;
		public ILevelData LevelData => levelData;

		public TestStage(ILevelData levelData)
		{
			this.levelData = levelData;
		}
	}
}
