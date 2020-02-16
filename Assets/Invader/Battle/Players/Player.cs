using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Invader.Inputs;
using Invader.Level;
using Invader.Bullets;

namespace Invader.Unit.Players
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

		float moveVelocity;

		Bullet CreateBullet()
		{
			return GameObject.Instantiate(originalBulletObject);
		}

		public PlayerModel(ILevelData levelData)
		{
			this.levelData = levelData;
			originalBulletObject = levelData.PlayerBullet;
			moveVelocity = levelData.PlayerMoveVelocity;
		}

		public void Attack()
		{
			var bullet = CreateBullet();
			bullet.Initialize(this, levelData);
			Debug.Log("Attack");
		}

		public void Move(Vector2 dir)
		{
			position.Value += dir * moveVelocity * Time.deltaTime;
		}

		public void ReceiveDamage(int damage)
		{
		}
	}
}
