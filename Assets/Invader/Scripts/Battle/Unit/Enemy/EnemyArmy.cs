using System.Collections;
using System.Collections.Generic;
using Invader.Level;
using Invader.Stages;
using UnityEngine;

namespace Invader.Units.Enemies
{
	/// <summary>
	/// 敵の軍隊クラス
	/// </summary>
	public class EnemyArmy
	{
		IStage stage;

		List<IEnemy> enemies;

		public EnemyArmy(IStage stage)
		{
			EnemyFactory factory = new EnemyFactory();
			enemies = new List<IEnemy>();

			// とりあえず並べる
			Vector2 origin = new Vector2(-6, 5);
			Vector2 pos = origin;
			for (int row = 0; row < 5; row++) {
				for (int enemyColumn = 0; enemyColumn < 11; enemyColumn++) {
					pos.x += 1;
					var enemy = factory.Create(EnemyData.EnemyType.First, pos);
					enemies.Add(enemy);
				}
				pos.x = origin.x;
				pos.y -= 1;
			}
		}
	}

	public class EnemyFactory
	{
		public EnemyModel Create(EnemyData.EnemyType type, Vector2 initialPos)
		{
			var enemyData = new EnemyData(EnemyData.EnemyType.First);
			var enemyModel = new EnemyModel(enemyData, initialPos);

			var prefab = Resources.Load<EnemyPresenter>("Enemy");
			var enemyObject = GameObject.Instantiate(prefab);
			enemyObject.Initialize(enemyModel);

			return enemyModel;
		}
	}
}
