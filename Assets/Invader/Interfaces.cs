using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Invader
{
	public interface IHittable
	{
		void Hit();
	}

	public interface IBullet : IMovable, IHittable
	{ }

	/// <summary>
	/// 弾
	/// </summary>
	public class Bullet : IBullet
	{
		public void Hit()
		{
		}

		public void Move(Vector2 dir, float moveValue)
		{
		}
	}
}