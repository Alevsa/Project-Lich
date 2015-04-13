using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {

	public GameObject bullet;
	public int amountOfBullets;
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
			StartCoroutine(fire ());
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
	
	private IEnumerator fire()
	{
		firing = false;
		for (int i = 0; i < amountOfBullets; i++) 
		{
			GameObject bul = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
			yield return new WaitForSeconds(0.04f);
		}
	}
}
