using System.Collections;
using System.Collections.Generic;
using UniRx;
using System;
using Invader.Units;

namespace Invader.Bullets
{
	public interface IBullet : IMovable
	{
		/// <summary>
		/// 弾撃った人
		/// </summary>
		IAttackable Attacker { get; }

		IObservable<Unit> OnDestroy { get; }
	}

	public interface IBulletView
	{
		/// <summary>
		/// あたった
		/// </summary>
		IObservable<IBullet> OnHit { get; }
	}
}
