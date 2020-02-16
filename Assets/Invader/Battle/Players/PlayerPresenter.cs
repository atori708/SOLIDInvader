﻿using System.Collections;
using System.Collections.Generic;
using Invader.Inputs;
using UnityEngine;
using UniRx;
using Invader.Level;

namespace Invader.Unit.Players
{
	public class PlayerPresenter : MonoBehaviour
	{
		Mover mover = null;

		Attacker attacker = null;

		[SerializeField]
		PlayerView playerView = null;

		PlayerModel player = null;

		public void Initialize(IInput input, ILevelData levelData)
		{
			//attacker = new Attacker(player, attackInput);
			player = new PlayerModel(levelData);
			mover = new Mover(player, input);

			player.Position.Subscribe(playerView.SetPosition).AddTo(this);
		}

		private void Update()
		{
			mover.Move();
		}
	}
}
