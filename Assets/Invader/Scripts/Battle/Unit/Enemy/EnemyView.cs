using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invader.Units.Enemies
{
	public interface IEnemyView
	{
		void SetPosition(Vector2 vector2);
	}


	public class EnemyView : MonoBehaviour, IEnemyView
	{
		[SerializeField]
		SpriteRenderer spriteRenderer = null;

		public void SetEnemyData(EnemyData enemyData)
		{
		}

		public void FireBullet()
		{
		}

		public void SetPosition(Vector2 position)
		{
			transform.position = position;
		}
	}
}
