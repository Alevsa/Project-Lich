using UnityEngine;
using System.Collections;

public class DeathExplosion : MonoBehaviour 
{
    public float ExplosionTime;
    private float timer;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += 1.0f * Time.deltaTime;
        if(timer > ExplosionTime)
            Destroy(gameObject);
	}

}
