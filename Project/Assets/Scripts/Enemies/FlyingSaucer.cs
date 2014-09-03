using UnityEngine;
using System.Collections;

public class FlyingSaucer : Enemy 
{
    public float OrbitSpeed;
    private Vector3 centre;

	// Use this for initialization
	void Start () 
    {
        centre = transform.position - new Vector3(0, 1.5f, 0);
	}

    void Update()
    {
        Orbit();
    }

    void Orbit()
    {
        transform.Rotate(Vector3.back, OrbitSpeed * Time.deltaTime);
        transform.RotateAround(centre, Vector3.forward, OrbitSpeed * Time.deltaTime);

    }
                    
}
