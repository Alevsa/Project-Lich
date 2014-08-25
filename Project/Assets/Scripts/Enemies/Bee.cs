using UnityEngine;
using System.Collections;

public class Bee : Enemy {

	public float Magnitude;
	public float Frequency;
	public GameObject Target;

	// Use this for initialization
	void Start () {
		Target = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	public override void SetDestination () {
		if (Target != null)
			movement += (((Target.transform.position - transform.position).normalized * Speed + Vector3.Cross (Target.transform.position - transform.position, Vector3.forward).normalized * Mathf.Sin(Time.time * Frequency) * Magnitude * Speed) * Time.deltaTime);
	}
}
