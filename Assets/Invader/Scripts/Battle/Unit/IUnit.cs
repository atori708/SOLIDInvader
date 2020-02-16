using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invader.Unit
{
	public interface IMover
	{
		void Move(Vector2 dir);
	}

	public interface IAttacker
	{
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

	public interface IUnit : IMover, IAttacker, IDamagable
	{ }
}
