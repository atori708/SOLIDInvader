using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invader.Units;
using Invader.Units.Players;

namespace Invader.Scene
{
	public interface IScene
	{
		void Start();
		void End();
	}
}
