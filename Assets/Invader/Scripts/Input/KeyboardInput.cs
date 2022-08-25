using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


namespace Invader.Inputs
{
	public class KeyboardInput : IInput
	{
		Subject<bool> onInputMoveSubject = new();
		public IObservable<bool> OnInputMoveObservable => onInputMoveSubject;

		ReactiveProperty<Vector2> moveDirection = new();
		public IReadOnlyReactiveProperty<Vector2> MoveDirection => moveDirection;

		Subject<Unit> onClickAttackKey = new ();
		public IObservable<Unit> OnInputAttackObservable => onClickAttackKey;

		public KeyboardInput()
		{
			Observable.EveryUpdate().Subscribe(_ => {
				moveDirection.Value = Vector2.zero;

				if (Input.GetKey(KeyCode.A)) {
					moveDirection.Value = Vector2.left;
				}
				else if (Input.GetKey(KeyCode.D)) {
					moveDirection.Value = Vector2.right;
				}

				onInputMoveSubject.OnNext(moveDirection.Value.sqrMagnitude > 0);

				if(Input.GetKeyDown(KeyCode.Space)) {
					onClickAttackKey.OnNext(Unit.Default);
				}
			});


		}
	}
}
