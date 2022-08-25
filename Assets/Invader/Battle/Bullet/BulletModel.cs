using System;
using System.Collections;
using System.Collections.Generic;
using Invader.Level;
using Invader.Stages;
using Invader.Units;
using UniRx;
using UnityEngine;

namespace Invader.Bullets
{
	/// <summary>
	/// 弾のModel
	/// </summary>
	public class BulletModel : IBullet
	{
		IAttackable attacker;
		public IAttackable Attacker => attacker;

		ReactiveProperty<Vector2> position;
		public IReadOnlyReactiveProperty<Vector2> Position => position;

		Subject<Unit> onDestroy;
		public IObservable<Unit> OnDestroy => onDestroy;

		Vector3 direction;

		float velocity = 0;

		IStage _stage;

		public BulletModel(IAttackable attackable, IStage stage)
		{
			position = new ReactiveProperty<Vector2>(attackable.Position.Value);
			_stage = stage;
			onDestroy = new Subject<Unit>();

			this.attacker = attackable;

			velocity = _stage.LevelData.PlayerBulletVelocity;
			direction = attackable.Direction;
		}

		public void Move(Vector2 dir)
		{
			position.Value += dir * velocity * Time.deltaTime;

			// ステージ端まで行ったらDestroy
			// TODO 端の判定の数値は外部からもらう IStageとかがいいと思います
			if(position.Value.y > 8) {
				Destroy();
			}
		}

		public void Hit()
		{
			Destroy();
		}

		void Destroy()
		{
			onDestroy.OnNext(Unit.Default);
		}
	}
}
