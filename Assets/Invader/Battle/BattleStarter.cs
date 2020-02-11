using System.Collections;
using System.Collections.Generic;
using Invader.Scene;
using UnityEngine;

public class BattleStarter : MonoBehaviour
{
	IScene battleScene;

	private void Awake()
	{
		battleScene = new BattleScene();
	}
}
