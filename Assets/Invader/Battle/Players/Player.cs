using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Invader.Inputs;
using Invader.Level;

namespace Invader.Unit.Players
{
	/// <summary>
	/// プレイヤー
	/// </summary>
	public class PlayerModel : IUnit
	{
		IPlayerView playerView;

		IInput input;

		ReactiveProperty<Vector2> position = new ReactiveProperty<Vector2>();
		public IReadOnlyReactiveProperty<Vector2> Position => position;

		public Vector2 Direction => Vector2.up;

		// こういったデータは外部からもらったほうがよい
		float moveVelocity;

		bool isMoving = false;

		public PlayerModel(IInput input, ILevelData levelData)
		{
			this.input = input;
			moveVelocity = levelData.PlayerMoveVelocity;
			input.OnInputMoveObservable
				.Subscribe(SetMoving);
			input.OnInputAttackObservable.Subscribe(_ => Attack());
		}

		public void Attack()
		{
		}

		public void Move(Vector2 dir)
		{
			position.Value += dir * moveVelocity * Time.deltaTime;
		}

		public void ReceiveDamage(int damage)
		{
		}

		void SetMoving(bool isMoving)
		{
			this.isMoving = isMoving;
		}

		public void Update()
		{
			if (!isMoving) {
				return;
			}

			Move(input.MoveDirection.Value);
		}
	}
}
