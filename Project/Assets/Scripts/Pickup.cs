using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public string Category;
	public GameObject weapon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			coll.gameObject.SendMessage ("ChangeWeapon", weapon);
			Destroy (this.gameObject);
		}
	}
}
