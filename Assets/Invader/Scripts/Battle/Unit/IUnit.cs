using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invader.Unit
{
	public interface IMovable
	{
		void Move(Vector2 dir, float moveValue);
	}

	public interface IAttackable
	{
		void Attack();
	}

	public interface IDamagable
	{
		void ReceiveDamage(int damage);
	}

	public interface IUnit : IMovable, IAttackable, IDamagable
	{ }
}
