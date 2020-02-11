using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invader.Unit;
using Invader.Unit.Players;

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
			playerPresenter.Initialize(debugInput);
		}

		public void End()
		{
		}
	}
}
