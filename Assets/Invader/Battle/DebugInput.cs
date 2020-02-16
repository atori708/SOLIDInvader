using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invader.Inputs;
using System;
using UniRx;
using UnityEngine.UI;

public class DebugInput : MonoBehaviour, IInput
{
	[SerializeField]
	DebugInputMoveButton leftButton = null;

	[SerializeField]
	DebugInputMoveButton rightButton = null;

	[SerializeField]
	Button attackButton = null;

	Subject<bool> onInputMoveSubject = new Subject<bool>();
	public IObservable<bool> OnInputMoveObservable => onInputMoveSubject;

	ReactiveProperty<Vector2> moveDirection = new ReactiveProperty<Vector2>();
	public IReadOnlyReactiveProperty<Vector2> MoveDirection => moveDirection;

	IObservable<Unit> IAttackInput.OnInputAttackObservable => attackButton.OnClickAsObservable();

	public void Initialize()
	{
		leftButton.OnDownObservable
			.Subscribe(_ => {
				moveDirection.Value = Vector2.left;
				onInputMoveSubject.OnNext(true);
			})
			.AddTo(this);

		rightButton.OnDownObservable
			.Subscribe(_ => {
				moveDirection.Value = Vector2.right;
				onInputMoveSubject.OnNext(true);
			})
			.AddTo(this);

		leftButton.OnUpObservable.Merge(rightButton.OnUpObservable).Subscribe(_ => {
			onInputMoveSubject.OnNext(false);
			moveDirection.Value = Vector2.zero;
		}).AddTo(this);
	}
}

