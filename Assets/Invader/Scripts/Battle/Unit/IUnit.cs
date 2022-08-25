using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Invader.Units
{
	public interface IMovable
	{
		IReadOnlyReactiveProperty<Vector2> Position { get; }

		void Move(Vector2 dir);
	}

	public interface IAttackable
	{
		/// <summary>
		/// 座標
		/// </summary>
		IReadOnlyReactiveProperty<Vector2> Position { get; }

		/// <summary>
		/// どっち向いてるか
		/// </summary>
		Vector2 Direction { get; }

		/// <summary>
		/// 攻撃
		/// </summary>
		void Attack();
	}

	public readonly struct DamageData
	{
		public readonly int Damage { get; }

		public DamageData(int damage)
		{
			this.Damage = damage;
		}
	}

	public interface IReceivableDamage
	{
		void ReceiveDamage(DamageData damage);
	}

	public interface IUnit : IMovable, IAttackable, IReceivableDamage
	{ }
}
