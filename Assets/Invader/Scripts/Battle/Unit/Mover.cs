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
	public class Mover : MonoBehaviour
	{
		// SerializeFieldにしたいけどインターフェースは無理なんだよなあ
		// なんか新しいバージョンだとできるようになるとか聞いた
		IMovable movable = null;

		IMoveInput moveInput;

		bool isMoving = false;

		public void Initialize(IMovable movable, IMoveInput moveInput)
		{
			this.movable = movable;
			this.moveInput = moveInput;
			this.moveInput.OnInputMoveObservable
				.Subscribe(SetMoving)
				.AddTo(this);
		}

		void SetMoving(bool isMoving)
		{
			this.isMoving = isMoving;
		}

		void Update()
		{
			if (!isMoving) {
				return;
			}

			movable.Move(moveInput.MoveDirection.Value);
		}
	}
}
