﻿using System.Collections;
using System.Collections.Generic;
using UniRx;
using System;
using Invader.Unit;

namespace Invader.Bullets
{
	public interface IBullet
	{
		/// <summary>
		/// 弾撃った人
		/// </summary>
		IAttackable Attacker { get; }

		/// <summary>
		/// あたった
		/// </summary>
		IObservable<IBullet> OnHit { get; }
	}
}