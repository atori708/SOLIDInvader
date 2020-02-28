using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Invader.Units.Enemies
{
	public struct EnemyData
	{
		public enum EnemyType
		{
			First,
			Second,
			Third,
			Fourth,
			Fifth,
			UFO,
		}

		public EnemyType Type { private set; get; }

		public EnemyData(EnemyType type)
		{
			Type = type;
		}
	}

	public interface IEnemy : IUnit
	{
		IReadOnlyReactiveProperty<EnemyData> EnemyData { get; }
	}

	/// <summary>
	/// 敵
	/// </summary>
	public class EnemyModel : IEnemy
	{
		public Vector2 Direction => Vector2.down;

		ReactiveProperty<Vector2> position;
		public IReadOnlyReactiveProperty<Vector2> Position => position;

		ReactiveProperty<EnemyData> enemyData;
		public IReadOnlyReactiveProperty<EnemyData> EnemyData => enemyData;

		public EnemyModel(EnemyData enemyData, Vector2 initialPos)
		{
			this.position = new ReactiveProperty<Vector2>();
			this.enemyData = new ReactiveProperty<EnemyData>(enemyData);
			position.Value = initialPos;
		}

		public void Attack()
		{
		}

		public void Move(Vector2 dir)
		{
		}

		public void ReceiveDamage(DamageData damage)
		{
		}
	}
}