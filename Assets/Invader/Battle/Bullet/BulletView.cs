using System;
using System.Collections;
using System.Collections.Generic;
using Invader.Units;
using UniRx;
using UnityEngine;

namespace Invader.Bullets
{
	public class BulletView : MonoBehaviour
	{
		Subject<Unit> onHit = new Subject<Unit>();
		public IObservable<Unit> OnHit => onHit;

		public void SetPosition(Vector2 position)
		{
			transform.position = position;
		}

		private void OnTriggerEnter(Collider other)
		{
			var damageable = other.GetComponent<IReceivableDamage>();
			if (damageable == null) {
				return;
			}

			var damageData = new DamageData(1);
			damageable.ReceiveDamage(damageData);
			onHit.OnNext(Unit.Default);

			Destroy();
		}

		public void Destroy()
		{
			GameObject.Destroy(gameObject);
		}
	}
}
