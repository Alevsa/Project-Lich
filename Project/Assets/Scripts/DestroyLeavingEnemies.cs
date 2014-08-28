using UnityEngine;
using System.Collections;

public class DestroyLeavingEnemies : MonoBehaviour 
{
    public bool bottomCollider;
    public float timeTillDestroyed;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (bottomCollider)
        {
            if (col.gameObject.tag == "Enemy")
            {
                StartCoroutine(DestroyEnemy(col.gameObject));
            }
        }
    }

    IEnumerator DestroyEnemy(GameObject col)
    {
        yield return new WaitForSeconds(timeTillDestroyed);
        Destroy(col);
    }
}
