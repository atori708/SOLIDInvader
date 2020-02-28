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

		BulletFactory bulletFactory = null;
		IBullet playerBullet = null;
		BulletMover bulletMover = null;

		EnemyArmy enemyArmy;

		PlayerModel playerModel;

		public void Start()
		{
			debugInput.Initialize();
			testStage = new TestStage(levelData);

			bulletFactory = new BulletFactory(originalBullet, levelData);
			
			// プレイヤー
			playerModel = new PlayerModel(testStage.LevelData, testStage);
			playerPresenter.Initialize(playerModel, debugInput, testStage);
			playerModel.OnAttackObservable.Subscribe(attacker => {
				// 弾生成
				if (playerBullet == null) {
					playerBullet = bulletFactory.CreateBullet(attacker);
					bulletMover = new BulletMover(playerBullet, attacker.Direction);

					playerBullet.OnDestroy.Subscribe(_ => {
						playerBullet = null;
						bulletMover = null;
					}).AddTo(this);
				}
			}).AddTo(this);

			// 敵
			enemyArmy = new EnemyArmy(testStage);
		}

		public void End()
		{
		}

		private void Update()
		{
			bulletMover?.Move();
		}
	}
}
