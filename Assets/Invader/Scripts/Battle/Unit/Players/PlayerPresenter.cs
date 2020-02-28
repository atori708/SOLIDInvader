using System.Collections;
using System.Collections.Generic;
using Invader.Inputs;
using UnityEngine;
using UniRx;
using Invader.Level;
using Invader.Stages;

namespace Invader.Units.Players
{
	public class PlayerPresenter : MonoBehaviour
	{
		PlayerMover mover = null;

		Attacker attacker = null;

		[SerializeField]
		PlayerView playerView = null;

		PlayerModel player = null;

		public void Initialize(PlayerModel playerModel, IInput input, IStage stage)
		{
			player = playerModel;
			mover = new PlayerMover(player, input);
			attacker = new Attacker(player, input);

			player.Position.Subscribe(playerView.SetPosition).AddTo(this);
		}

		private void Update()
		{
			// TODO ここで呼ぶのおかしい Mover自身が勝手にUpdateを呼ぶべきでは...
			mover.Move();
		}
	}
}
