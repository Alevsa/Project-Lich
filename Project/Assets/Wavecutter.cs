using UnityEngine;
using System.Collections;

public class Wavecutter : Enemy {

	public float currentDegree;
	public float RadiusWidth;

	public GameObject Target;

	private bool counterclockwise = true;
	private float radius;
	private Vector3 center;

	// Use this for initialization
	void Start () {
		Target = GameObject.Find ("SpawnTopRight");
		radius = Vector3.Distance(this.transform.position, Target.transform.position) / 2;
		center = (Target.transform.position - this.transform.position) * 0.5F + this.transform.position;
		currentDegree = 0;
		EquipWeapon ();
	}
	
	// Update is called once per frame
	public override void SetDestination () {
		if (Target != null)
		{
			if (currentDegree >= Mathf.PI)
				counterclockwise = false;
			if (currentDegree <= 0)
				counterclockwise = true;

			if (counterclockwise == true)
				currentDegree += ((Speed*Time.deltaTime) * Mathf.Deg2Rad);
			else
				currentDegree -= ((Speed*Time.deltaTime) * Mathf.Deg2Rad);

			movement = center + new Vector3(Mathf.Cos(currentDegree - (180 * Mathf.Deg2Rad)) * radius, Mathf.Sin(currentDegree - (180 * Mathf.Deg2Rad)) * radius/ 4);			                      
		}
	}

	public override bool CheckFire() {
		if ((currentDegree >= 1) && (currentDegree <= 3))
		{
			if (Random.value >= 0.99F)
				return true;
			else return false;
		}
		else
			return false;
	}

	public override void Fire() {
		EquippedWeapon.GetComponent<Weapon>().Fire ();
	}
}
