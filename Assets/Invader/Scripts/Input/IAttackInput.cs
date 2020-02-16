using System;

namespace Invader.Inputs
{
	public interface IAttackInput
	{
		IObservable<UniRx.Unit> OnInputAttackObservable { get; }
	}
}
