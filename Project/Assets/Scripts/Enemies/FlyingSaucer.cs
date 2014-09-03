using UnityEngine;
using System.Collections;

public class FlyingSaucer : Enemy 
{
    public float OrbitSpeed;
    private Vector3 centre;

    private float Timer;
    public float FireRate;

	// Use this for initialization
	void Start () 
    {
        EquipWeapon();
	}

    void Update()
    {
        Timer += Time.deltaTime;
       if (Health <= 0)
           Die();

       if (CheckFire())
           Fire();

        Orbit();
    }

    void Orbit()
    {
        centre = transform.parent.position;
        transform.Rotate(Vector3.back, OrbitSpeed * Time.deltaTime);
        transform.RotateAround(centre, Vector3.forward, OrbitSpeed * Time.deltaTime);
    }

    public override void Fire()
    {
        EquippedWeapon.GetComponent<Weapon>().Fire();
    }

    public override bool CheckFire()
    {
        if (Timer > FireRate)
        {
            Timer = 0f;
            return true;
        }
        
        return false;
    }

                    
}
