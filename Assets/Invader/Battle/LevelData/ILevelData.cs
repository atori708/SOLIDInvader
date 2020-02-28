using System.Collections;
using System.Collections.Generic;
using Invader.Bullets;
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

		BulletModel PlayerBullet { get; }
		// etc...
	}
}
