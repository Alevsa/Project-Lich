using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {

	public GameObject[] bullet;
	public float baseRotSpeed, speedToFire, incSpeed;
	private SprayEnemy sEnemy;
	private float speed;
	private bool firing, moving;
	// Use this for initialization
	void Start () {
		speed = baseRotSpeed;
		sEnemy = gameObject.GetComponentInParent<SprayEnemy> ();
	}
	
	// Update is called once per frame
	void Update () {	
		transform.Rotate (Vector3.forward * (speed * Time.deltaTime));
		
		if (firing)
			speed += (Time.deltaTime * incSpeed);
		if (speed > speedToFire)
			fire ();
		if (!firing && (speed > baseRotSpeed))
			speed -= (Time.deltaTime * incSpeed);
		if (speed < baseRotSpeed && !moving)
		{
			sEnemy.moveInfrontPlayer ();
			moving = true;
		}
	}
	
	public void startFire()
	{
		firing = true;
		moving = false;
	}

	private void fire()
	{
		firing = false;
		for (int i = 0; i < bullet.Length; i++) 
			Instantiate (bullet[i], transform.position, transform.rotation);
	}
}
