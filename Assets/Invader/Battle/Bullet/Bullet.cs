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
		IAttacker attacker;
		public IAttacker Attacker => attacker;

		Subject<IBullet> onHit;
		public IObservable<IBullet> OnHit => OnHit;

		Vector3 direction;

		float velocity = 0;

		public void Initialize(IAttacker attacker, ILevelData levelData)
		{
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

			damageable.ReceiveDamage(1);
			onHit.OnNext(this);

			Destroy(gameObject);
		}

		private void Update()
		{
			transform.position += direction * (velocity * Time.deltaTime);
		}
	}
}
