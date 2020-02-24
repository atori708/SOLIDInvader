using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Invader.Units.Enemies
{
	public class EnemyPresenter : MonoBehaviour
	{
		EnemyModel model;

		[SerializeField]
		EnemyView view = null;

		public void Initialize(EnemyModel model)
		{
			this.model = model;
			model.EnemyData.Subscribe(view.SetEnemyData).AddTo(this);
			model.Position.Subscribe(view.SetPosition).AddTo(this);
		}
	}
}
