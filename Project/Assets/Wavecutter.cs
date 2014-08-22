using UnityEngine;
using System.Collections;

public class Wavecutter : Enemy {

	public float currentDegree;
	public float RadiusWidth;

	public GameObject Target;
	private float radius;
	private Vector3 center;

	// Use this for initialization
	void Start () {
		Target = GameObject.Find ("SpawnTopRight");
		radius = Vector3.Distance(this.transform.position, Target.transform.position) / 2;
		center = (Target.transform.position - this.transform.position) * 0.5F + this.transform.position;
		currentDegree = Vector3.Angle (this.transform.position, center);
	}
	
	// Update is called once per frame
	public override void SetDestination () {
		if (Target != null)
		{
			currentDegree += Speed*Time.deltaTime;

			movement = center + new Vector3(Mathf.Cos(currentDegree) * radius, Mathf.Sin(currentDegree) * radius/ 4);			                      
		}
	}
}
