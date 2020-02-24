using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invader.Units.Players
{
	public interface IPlayerView
	{
		//void PlayAnimation();
		void FireBullet();
		void SetPosition(Vector2 vector2);
	}

	public class PlayerView : MonoBehaviour, IPlayerView
	{

		public void FireBullet()
		{
		}

		//public void PlayAnimation()
		//{
		//}

		public void SetPosition(Vector2 position)
		{
			transform.position = position;
		}
	}
}
