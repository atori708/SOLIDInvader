using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invader.Level
{
	/// <summary>
	/// 難易度調整に使うデータのインターフェース
	/// </summary>
	public interface ILevelData
	{
		float PlayerMoveVelocity { get; }
		float PlayerBulletVelocity { get; }

		// etc...
	}
}
