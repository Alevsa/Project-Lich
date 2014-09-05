using UnityEngine;
using System.Collections;

public class DestroyLeavingEnemies : MonoBehaviour 
{
    public bool bottomCollider;
    public float timeTillDestroyed;
    public float extraTime;

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
<<<<<<< HEAD
            {           
                StartCoroutine(DestroyEnemy(col.gameObject));
=======
            {
				if (col.gameObject.GetComponent<Enemy>().Type != "Boss")
                	StartCoroutine(DestroyEnemy(col.gameObject));
>>>>>>> origin/evgeniy_develop
            }
        }
    }

    IEnumerator DestroyEnemy(GameObject col)
    {
        yield return new WaitForSeconds(timeTillDestroyed);
        Destroy(col);
    }
}
