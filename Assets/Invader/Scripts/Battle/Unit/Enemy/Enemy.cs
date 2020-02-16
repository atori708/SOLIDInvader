using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Invader.Unit.Enemies
{
	/// <summary>
	/// 敵
	/// </summary>
	public class Enemy : IUnit
	{
		public Vector2 Direction => Vector2.down;

		public IReadOnlyReactiveProperty<Vector2> Position => throw new System.NotImplementedException();

		public void Attack()
		{
		}

		public void Move(Vector2 dir)
		{
		}

		public void ReceiveDamage(int damage)
		{
		}
	}
}