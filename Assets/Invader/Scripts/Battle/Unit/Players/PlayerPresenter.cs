using System.Collections;
using System.Collections.Generic;
using Invader.Inputs;
using UnityEngine;
using UniRx;
using Invader.Level;
using Invader.Stages;

namespace Invader.Unit.Players
{
	public class PlayerPresenter : MonoBehaviour
	{
		Mover mover = null;

		Attacker attacker = null;

		[SerializeField]
		PlayerView playerView = null;

		PlayerModel player = null;

		public void Initialize(IInput input, ILevelData levelData, IStage stage)
		{
			player = new PlayerModel(levelData, stage);
			mover = new Mover(player, input);
			attacker = new Attacker(player, input);

			player.Position.Subscribe(playerView.SetPosition).AddTo(this);
		}

		private void Update()
		{
			mover.Move();
		}
	}
}
