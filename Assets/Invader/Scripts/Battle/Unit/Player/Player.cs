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

		public Player(IPlayerView playerView)
		{
			position.Subscribe(playerView.SetPosition);
		}

		public void Attack()
		{
		}

		public void Move(Vector2 dir, float moveValue)
		{
			position.Value += dir * moveValue;
		}

		public void ReceiveDamage(int damage)
		{
		}
	}
}
