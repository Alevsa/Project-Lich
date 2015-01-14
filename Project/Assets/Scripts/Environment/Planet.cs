using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour 
{

    public float lowerSize, upperSize, Speed;

	// Use this for initialization
	void Start () 
    {
        SetSize();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
	}

    void SetSize()
    {
        float size = Random.Range(lowerSize, upperSize);
        transform.localScale = new Vector3(size, size, 0);

        Speed *= size;
    }

    public virtual void Move()
    {
        transform.position += (new Vector3(0, -Speed, 0) * Time.deltaTime);
    }
}
