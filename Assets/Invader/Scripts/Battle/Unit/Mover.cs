using System;
using Invader.Inputs;
using UniRx;

namespace Invader.Unit
{
	public class Mover
	{
		IMover movable = null;

		IMoveInput moveInput;

		bool isMoving = false;

		IDisposable disposable;

		public Mover(IMover movable, IMoveInput moveInput)
		{
			this.movable = movable;
			this.moveInput = moveInput;

			disposable = this.moveInput.OnInputMoveObservable.Subscribe(SetMoving);
		}

		~Mover()
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
