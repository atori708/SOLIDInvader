using System;
using Invader.Inputs;
using UniRx;
using UnityEngine;

namespace Invader.Unit
{
	/// <summary>
	/// Update()を使いたいのでMonoBehaviourにしている
	/// →そうするとコンストラクタが使えないのでなんか気持ち悪い
	/// →Zenjectでなんとかできるのかな？
	/// </summary>
	public class Mover
	{
		// SerializeFieldにしたいけどインターフェースは無理なんだよなあ
		// なんか新しいバージョンだとできるようになるとか聞いた
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
