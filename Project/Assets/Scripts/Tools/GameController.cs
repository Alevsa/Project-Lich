using UnityEngine;
using System.Collections;
using Game;

public class GameController : MonoBehaviour {

	public State gameState = State.Running;
    private GameObject menu;

	// Use this for initialization
	void Start () 
    {
        menu = GameObject.Find("Menu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HandlePause () {
		if (gameState == State.Running)
			Pause ();
		else if (gameState == State.Paused)
			Unpause ();
	}

	void Pause()
	{
		gameState = State.Paused;
		Time.timeScale = 0;
	}

	void Unpause()
	{
		gameState = State.Running;
		Time.timeScale = 1;
	}
}
