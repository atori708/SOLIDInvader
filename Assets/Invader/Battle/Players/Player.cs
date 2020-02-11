using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Invader.Unit.Players
{
	/// <summary>
	/// プレイヤー
	/// </summary>
	public class Player : IUnit
	{
		IPlayerView playerView;

		ReactiveProperty<Vector2> position = new ReactiveProperty<Vector2>();
		public IReadOnlyReactiveProperty<Vector2> Position => position;

		// こういったデータは外部からもらったほうがよい
		float moveSpeed = 10;

		public void Attack()
		{
		}

		public void Move(Vector2 dir)
		{
			position.Value += dir * moveSpeed * Time.deltaTime;
		}

		public void ReceiveDamage(int damage)
		{
		}
	}
}
