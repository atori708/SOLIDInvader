using System.Collections;
using System.Collections.Generic;
using UniRx;
using System;
using Invader.Unit;

namespace Invader.Bullet
{
	public interface IBullet
	{
		/// <summary>
		/// 弾撃った人
		/// </summary>
		IAttacker Attacker { get; }

		/// <summary>
		/// あたった
		/// </summary>
		IObservable<UniRx.Unit> OnHit { get; }

		void Hit();
	}
}
