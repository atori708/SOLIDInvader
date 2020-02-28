using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Invader.Inputs;
using Invader.Level;
using Invader.Bullets;
using Invader.Stages;
using System;

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

		Subject<PlayerModel> onAttackSubject = new Subject<PlayerModel>();
		public IObservable<PlayerModel> OnAttackObservable => onAttackSubject;

		public Vector2 Direction => Vector2.up;

		BulletModel originalBulletObject;

		ILevelData levelData;
		IStage stage;

		float moveVelocity;

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
			onAttackSubject.OnNext(this);
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

		public void ReceiveDamage(DamageData damage)
		{
		}
	}

	public class BulletFactory
	{
		BulletPresenter originalBulletObject;

		ILevelData levelData;

		public BulletFactory(BulletPresenter originalBulletObject, ILevelData levelData)
		{
			this.originalBulletObject = originalBulletObject;
			this.levelData = levelData;
		}

		public IBullet CreateBullet(IAttackable attackable)
		{
			var presenter = GameObject.Instantiate(originalBulletObject);
			BulletModel model = new BulletModel(attackable, levelData);
			presenter.Initialize(model);
			return model;
		}
	}
}
