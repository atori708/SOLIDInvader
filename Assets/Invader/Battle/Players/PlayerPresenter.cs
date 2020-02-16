using System.Collections;
using System.Collections.Generic;
using Invader.Inputs;
using UnityEngine;
using UniRx;
using Invader.Level;

namespace Invader.Unit.Players
{
	public class PlayerPresenter : MonoBehaviour
	{
		[SerializeField]
		Mover mover = null;

		Attacker attacker = null;

		[SerializeField]
		PlayerView playerView = null;

		PlayerModel player = null;

		public void Initialize(IInput input, ILevelData levelData)
		{
			player = new PlayerModel(input, levelData);
			//mover.Initialize(player, moveInput);
			//attacker = new Attacker(player, attackInput);

			player.Position.Subscribe(playerView.SetPosition).AddTo(this);
		}

		private void Update()
		{
			player.Update();
		}
	}
}
