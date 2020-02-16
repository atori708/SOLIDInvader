using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invader.Unit.Enemies
{
	/// <summary>
	/// 敵
	/// </summary>
	public class Enemy : IUnit
	{
		public Vector2 Direction => Vector2.down;

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