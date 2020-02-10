using System;
using UniRx;
using UnityEngine;

namespace Invader.Inputs
{
	public class ControllerInput : IMoveInput, IAttackInput
	{
		Subject<bool> onInputAttackSubject = new Subject<bool>();
		public IObservable<bool> OnInputAttackObservable => onInputAttackSubject;

		Subject<bool> onInputMoveSubject = new Subject<bool>();
		public IObservable<bool> OnInputMoveObservable => onInputMoveSubject;

		ReactiveProperty<Vector2> moveDirection;
		public IReadOnlyReactiveProperty<Vector2> MoveDirection => moveDirection;

		public ControllerInput()
		{
		}
	}
}
