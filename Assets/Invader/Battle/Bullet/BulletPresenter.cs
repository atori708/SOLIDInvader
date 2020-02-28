using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Invader.Bullets
{
	/// <summary>
	/// 弾のPresenter
	/// </summary>
	public class BulletPresenter : MonoBehaviour
	{
		BulletModel model;

		[SerializeField]
		BulletView view = null;

		public void Initialize(BulletModel model)
		{
			model.Position.Subscribe(view.SetPosition).AddTo(this);
			model.OnDestroy.Subscribe(_ => view.Destroy()).AddTo(this);
			view.OnHit.Subscribe(_ => model.Hit()).AddTo(this);
			//view.OnHit.Subscribe().AddTo(this);
		}
	}
}
