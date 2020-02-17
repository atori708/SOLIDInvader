using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invader.Unit;
using Invader.Unit.Players;
using Invader.Level;
using Invader.Bullets;
using Invader.Stages;

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

		public void Start()
		{
			testStage = new TestStage();
			debugInput.Initialize();
			playerPresenter.Initialize(debugInput, levelData, testStage);
		}

		public void End()
		{
		}
	}
}
