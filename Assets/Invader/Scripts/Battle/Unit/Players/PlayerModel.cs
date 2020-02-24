using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Invader.Inputs;
using Invader.Level;
using Invader.Bullets;
using Invader.Stages;

namespace Invader.Units.Players
{
	/// <summary>
	/// プレイヤー
	/// </summary>
	public class PlayerModel : IUnit
	{
		IPlayerView playerView;

		ReactiveProperty<Vector2> position = new ReactiveProperty<Vector2>();
		public IReadOnlyReactiveProperty<Vector2> Position => position;

		public Vector2 Direction => Vector2.up;

		Bullet originalBulletObject;

		ILevelData levelData;
		IStage stage;

		float moveVelocity;

		Bullet CreateBullet()
		{
			return GameObject.Instantiate(originalBulletObject);
		}

		public PlayerModel(ILevelData levelData, IStage stage)
		{
			this.levelData = levelData;
			this.stage = stage;
			originalBulletObject = levelData.PlayerBullet;
			moveVelocity = levelData.PlayerMoveVelocity;
			position.Value = new Vector2(0, -2.3f);
		}

		public void Attack()
		{
			var bullet = CreateBullet();
			bullet.Initialize(this, levelData);
		}

		public void Move(Vector2 dir)
		{
			var pos = position.Value;
			pos += dir * moveVelocity * Time.deltaTime;

			if (pos.x > stage.RightEdgePosX) {
				pos.x = stage.RightEdgePosX;
			}
			else if (pos.x < stage.LeftEdgePosX) {
				pos.x = stage.LeftEdgePosX;
			}

			position.Value = pos;
		}

		public void ReceiveDamage(int damage)
		{
		}
	}
}
