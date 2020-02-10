using System;

namespace Invader.Inputs
{
	public interface IAttackInput
	{
		IObservable<bool> OnInputAttackObservable { get; }
	}
}
