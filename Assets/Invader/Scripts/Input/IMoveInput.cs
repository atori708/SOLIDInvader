using System;
using UniRx;
using UnityEngine;

namespace Invader.Inputs
{
	public interface IMoveInput
	{
		IObservable<bool> OnInputMoveObservable { get; }
		IReadOnlyReactiveProperty<Vector2> MoveDirection { get; }
	}

	public interface IInput : IMoveInput, IAttackInput
	{ }

}
