using System.Collections;
using System.Collections.Generic;
using Invader.Inputs;
using UnityEngine;
using UniRx;

namespace Invader.Unit.Players
{
	public class PlayerPresenter : MonoBehaviour
	{
		[SerializeField]
		Mover mover = null;

		[SerializeField]
		PlayerView playerView = null;

		Player player = null;

		public void Initialize(IMoveInput moveInput)
		{
			player = new Player();
			mover.Initialize(player, moveInput);

			player.Position.Subscribe(playerView.SetPosition).AddTo(this);
		}
	}
}
