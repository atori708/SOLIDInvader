using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invader.Unit;
using Invader.Unit.Players;
using Invader.Level;

namespace Invader.Scene
{
	public class BattleScene : MonoBehaviour, IScene
	{
		IUnit player;

		[SerializeField]
		PlayerPresenter playerPresenter = null;

		[SerializeField]
		DebugInput debugInput = null;

		public void Start()
		{
			debugInput.Initialize();
			playerPresenter.Initialize(debugInput, new LevelData());
		}

		public void End()
		{
		}
	}

	public class LevelData : ILevelData
	{
		public float PlayerBulletVelocity => 10;

		public float PlayerMoveVelocity => 10;
	}
}
