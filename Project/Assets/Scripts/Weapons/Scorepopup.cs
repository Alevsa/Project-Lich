using UnityEngine;
using System.Collections;

public class Scorepopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().sortingLayerID = 2;
		GetComponent<Renderer>().sortingOrder = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
