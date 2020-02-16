using System;
using System.Collections;
using System.Collections.Generic;
using Invader.Level;
using Invader.Unit;
using UniRx;
using UnityEngine;

namespace Invader.Bullet
{
	/// <summary>
	/// 弾
	/// ViewとModelで分けたほうがいい？
	/// </summary>
	public class Bullet : MonoBehaviour, IBullet
	{
		Subject<UniRx.Unit> onHit;
		public IObservable<UniRx.Unit> OnHit => OnHit;

		IAttacker attacker;
		public IAttacker Attacker => attacker;

		Vector3 direction;

		float velocity = 0;

		public void Initialize(IAttacker attacker, ILevelData levelData)
		{
			this.attacker = attacker;
			velocity = levelData.PlayerBulletVelocity;
			direction = attacker.Direction;
		}

		public void Hit()
		{
			onHit.OnNext(UniRx.Unit.Default);
		}

		private void Update()
		{
			transform.position += direction * (velocity * Time.deltaTime);
		}
	}
}
