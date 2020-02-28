using System;
using System.Collections;
using System.Collections.Generic;
using Invader.Level;
using Invader.Units;
using UniRx;
using UnityEngine;

namespace Invader.Bullets
{
	/// <summary>
	/// 弾
	/// ViewとModelで分けたほうがいい？
	/// </summary>
	public class Bullet : MonoBehaviour, IBullet
	{
		IAttackable attacker;
		public IAttackable Attacker => attacker;

		Subject<IBullet> onHit = new Subject<IBullet>();
		public IObservable<IBullet> OnHit => OnHit;

		Vector3 direction;

		float velocity = 0;

		public void Initialize(IAttackable attacker, ILevelData levelData)
		{
			transform.position = attacker.Position.Value;
			this.attacker = attacker;
			velocity = levelData.PlayerBulletVelocity;
			direction = attacker.Direction;
		}

		private void OnTriggerEnter(Collider other)
		{
			var damageable = other.GetComponent<IDamagable>();
			if (damageable == null) {
				return;
			}

			var damageData = new DamageData(1);
			damageable.ReceiveDamage(damageData);
			onHit.OnNext(this);

			Destroy(gameObject);
		}

		private void Update()
		{
			transform.position += direction * (velocity * Time.deltaTime);
		}
	}
}
