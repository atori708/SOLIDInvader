using System.Collections;
using System.Collections.Generic;
using Invader.Inputs;
using UniRx;

namespace Invader.Unit
{
	public class Attacker
	{
		IAttacker target = null;

		IAttackInput attackInput = null;

		public Attacker(IAttacker target, IAttackInput attackInput)
		{
			this.target = target;
			this.attackInput = attackInput;
			attackInput.OnInputAttackObservable.Subscribe(_ => target.Attack());
		}
	}
}
