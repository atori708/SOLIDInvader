using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invader.Inputs;
using System;
using UniRx;
using UnityEngine.UI;

namespace Invader.Inputs
{
	public class DebugInput : IInput
	{
		Subject<bool> _onInputMoveSubject = new Subject<bool>();
		public IObservable<bool> OnInputMoveObservable => _onInputMoveSubject;

		ReactiveProperty<Vector2> _moveDirection = new ReactiveProperty<Vector2>();
		public IReadOnlyReactiveProperty<Vector2> MoveDirection => _moveDirection;

		Button _attackButton;
		IObservable<Unit> IAttackInput.OnInputAttackObservable => _attackButton.OnClickAsObservable();

		CompositeDisposable _disposables = new();

		public DebugInput(DebugInputMoveButton leftButton, DebugInputMoveButton rightButton, Button attackButton)
		{
			_attackButton = attackButton;

			// 左移動
			leftButton.OnDownObservable
				.Subscribe(_ => {
					_moveDirection.Value = Vector2.left;
					_onInputMoveSubject.OnNext(true);
				})
				.AddTo(_disposables);

			// 右移動
			rightButton.OnDownObservable
				.Subscribe(_ => {
					_moveDirection.Value = Vector2.right;
					_onInputMoveSubject.OnNext(true);
				})
				.AddTo(_disposables);

			// 移動終了
			leftButton.OnUpObservable.Merge(rightButton.OnUpObservable).Subscribe(_ => {
				_onInputMoveSubject.OnNext(false);
				_moveDirection.Value = Vector2.zero;
			}).AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}
	}
}
