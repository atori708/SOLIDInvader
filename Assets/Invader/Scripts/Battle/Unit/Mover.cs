using System;
using Invader.Inputs;
using UniRx;
using UnityEngine;

namespace Invader.Units
{
	public class PlayerMover : IDisposable
	{
		IMovable movable = null;

		IMoveInput moveInput;

		bool isMoving = false;

		IDisposable disposable;

		public PlayerMover(IMovable movable, IMoveInput moveInput)
		{
			this.movable = movable;
			this.moveInput = moveInput;

			disposable = this.moveInput.OnInputMoveObservable.Subscribe(SetMoving);
		}

		public void Dispose()
		{
			disposable.Dispose();
		}

		void SetMoving(bool isMoving)
		{
			this.isMoving = isMoving;
		}

		public void Move()
		{
			if (!isMoving) {
				return;
			}

			movable.Move(moveInput.MoveDirection.Value);
		}
	}
}
