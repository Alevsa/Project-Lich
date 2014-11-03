using UnityEngine;
using System.Collections;
using MainMenu;

public class Controller : MonoBehaviour {

	public State MenuState = State.Default;
	public Canvas DefaultCanvas;
	public Canvas OptionsCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartEndless ()
	{
		Application.LoadLevel (1);
	}

	void OpenOptions ()
	{
		MenuState = State.Options;
	}
}
