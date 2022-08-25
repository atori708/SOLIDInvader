using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invader.Units;
using Invader.Units.Players;
using Invader.Level;
using Invader.Bullets;
using Invader.Stages;
using Invader.Units.Enemies;
using UniRx;
using Invader.Inputs;
using UnityEngine.UI;

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

		/// <summary>
		/// TODO 弾持つのここなのは違和感
		/// </summary>
		[SerializeField]
		BulletPresenter originalBullet = null;

		[SerializeField]
		DebugInputMoveButton leftButton = null;

		[SerializeField]
		DebugInputMoveButton rightButton = null;

		[SerializeField]
		Button attackButton = null;

		IInput input;

		BulletFactory bulletFactory = null;
		IBullet playerBullet = null;

		EnemyArmy enemyArmy;

		PlayerModel playerModel;

		private void Awake()
		{
			OpenScene();
		}

		private void Update()
		{
			playerBullet?.Move(playerModel.Direction);
		}

		private void OnDestroy()
		{
			CloseScene();
		}

		public void OpenScene()
		{
			//IInput input = new KeyboardInput();
			input = new DebugInput(leftButton, rightButton, attackButton);

			testStage = new TestStage(levelData);

			bulletFactory = new BulletFactory(originalBullet, testStage);

			// プレイヤー
			playerModel = new PlayerModel(testStage.LevelData, testStage);
			playerPresenter.Initialize(playerModel, input, testStage);
			playerModel.OnAttackObservable.Subscribe(attacker => {
				// 弾生成
				if (playerBullet == null) {
					playerBullet = bulletFactory.CreateBullet(attacker);

					playerBullet.OnDestroy.Subscribe(_ => {
						playerBullet = null;
					}).AddTo(this);
				}
			}).AddTo(this);

			// 敵
			enemyArmy = new EnemyArmy(testStage);
		}

		public void CloseScene()
		{
			playerPresenter.Dispose();
			input.Dispose();
		}
	}
}
