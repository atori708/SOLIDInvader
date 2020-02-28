using Invader.Bullets;
using UnityEngine;

namespace Invader.Level
{
	public class LevelData : MonoBehaviour, ILevelData
	{
		public float PlayerBulletVelocity => 10;

		public float PlayerMoveVelocity => 10;

		[SerializeField]
		BulletModel playerBullet = null;
		public BulletModel PlayerBullet => playerBullet;
	}
}
