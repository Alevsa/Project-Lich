using UnityEngine;
using System.Collections;

public class Wavecutter : Enemy {

	public float currentDegree;
	public float RadiusWidth;

	public Vector3 Target;

	private bool counterclockwise = true;
	private float radius;
	private Vector3 center;

    [HideInInspector]
    public Animator thisAnimation;

	// Use this for initialization
	void Start () {

        thisAnimation = GetComponent<Animator>();
		Target = new Vector3 (-this.transform.position.x, this.transform.position.y, this.transform.position.z);
		radius = Vector3.Distance(this.transform.position, Target) / 2;
		center = (Target - this.transform.position) * 0.5F + this.transform.position;
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

	public override void Fire() 
    {
        thisAnimation.SetTrigger("Firing");
		EquippedWeapon.GetComponent<Weapon>().Fire ();
	}
}
