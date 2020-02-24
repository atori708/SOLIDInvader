using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invader.Units;
using Invader.Units.Players;
using Invader.Level;
using Invader.Bullets;
using Invader.Stages;
using Invader.Units.Enemies;

namespace Invader.Scene
{
	public class BattleScene : MonoBehaviour, IScene
	{
		IUnit player;

		[SerializeField]
		PlayerPresenter playerPresenter = null;

		[SerializeField]
		DebugInput debugInput = null;

		TestStage testStage = null;

		[SerializeField]
		LevelData levelData = null;

		EnemyArmy enemyArmy;

		public void Start()
		{
			debugInput.Initialize();
			testStage = new TestStage(levelData);

			enemyArmy = new EnemyArmy(testStage);
			playerPresenter.Initialize(debugInput, testStage);
		}

		public void End()
		{
		}
	}
}
