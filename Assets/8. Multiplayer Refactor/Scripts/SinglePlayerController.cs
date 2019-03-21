using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerController : MonoBehaviour {

	public void StartSinglePlayer()
	{
		GameManager.Instance.StartGame();
	}
}
