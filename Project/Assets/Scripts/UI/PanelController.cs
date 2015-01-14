using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour {

	public GameObject BoundPlayer;

	// Use this for initialization
	void Start () {
		if (BoundPlayer == null)
			BoundPlayer = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
