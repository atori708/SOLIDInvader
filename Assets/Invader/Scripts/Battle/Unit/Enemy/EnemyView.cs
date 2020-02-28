using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Invader.Units.Enemies
{
	public interface IEnemyView : IDamagable
	{
		void SetPosition(Vector2 vector2);
	}

	public class EnemyView : MonoBehaviour, IEnemyView
	{
		[SerializeField]
		SpriteRenderer spriteRenderer = null;

		Subject<DamageData> onReceiveDamageSubject = new Subject<DamageData>();
		/// <summary>
		/// ダメージ受けた
		/// </summary>
		public IObservable<DamageData> OnReceiveDamage => onReceiveDamageSubject;

		public void SetEnemyData(EnemyData enemyData)
		{
		}

		public void FireBullet()
		{
		}

		public void SetPosition(Vector2 position)
		{
			transform.position = position;
		}

		public void ReceiveDamage(DamageData damageData)
		{
			onReceiveDamageSubject.OnNext(damageData);
			Destroy();
		}

		public void Destroy()
		{
			// TODO 破壊されたイベント発火したほうがいい
			Destroy(gameObject);
		}
	}
}
