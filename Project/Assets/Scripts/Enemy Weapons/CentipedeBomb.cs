using UnityEngine;
using System.Collections;

public class CentipedeBomb : MonoBehaviour {

	public GameObject Explosion;
	public float DetonationTime;

	// Use this for initialization
	void Start () {
		StartCoroutine ("StartDetonation");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator StartDetonation ()
	{
		yield return new WaitForSeconds(DetonationTime);
		Detonate ();
	}

	void Detonate()
	{
		Instantiate (Explosion, this.transform.position, Quaternion.identity);
		Destroy (this.gameObject);
	}
}
