using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invader.Unit;
using Invader.Unit.Players;
using Invader.Level;
using Invader.Bullets;

namespace Invader.Scene
{
	public class BattleScene : MonoBehaviour, IScene
	{
		IUnit player;

		[SerializeField]
		PlayerPresenter playerPresenter = null;

		[SerializeField]
		DebugInput debugInput = null;

		[SerializeField]
		LevelData levelData = null;

		public void Start()
		{
			debugInput.Initialize();
			playerPresenter.Initialize(debugInput, levelData);
		}

		public void End()
		{
		}
	}
}
