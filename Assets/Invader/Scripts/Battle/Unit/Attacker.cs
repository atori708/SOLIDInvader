using System;
using System.Collections;
using System.Collections.Generic;
using Invader.Inputs;
using UniRx;

namespace Invader.Unit
{
	public class Attacker
	{
		IAttackable attackable = null;

		IAttackInput attackInput = null;

		IDisposable disposable;

		public Attacker(IAttackable attackable, IAttackInput attackInput)
		{
			this.attackable = attackable;
			this.attackInput = attackInput;
			disposable = attackInput.OnInputAttackObservable.Subscribe(_ => attackable.Attack());
		}

		~Attacker()
		{
			disposable.Dispose();
		}
	}
}
