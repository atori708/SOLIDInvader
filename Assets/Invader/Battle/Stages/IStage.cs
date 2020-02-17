using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invader.Stages
{
	public interface IStage
	{
		float LeftEdgePosX { get; }
		float RightEdgePosX { get; }
	}
}
