using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Invader.Unit
{
	public interface IMover
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

	public interface IDamagable
	{
		void ReceiveDamage(int damage);
	}

	public interface IUnit : IMover, IAttackable, IDamagable
	{ }
}
