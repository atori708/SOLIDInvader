using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invader.Unit;
using Invader.Unit.Players;

namespace Invader.Scene
{
	public interface IScene
	{
		void Start();
		void End();
	}
}
