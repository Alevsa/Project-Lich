using UnityEngine;
using System.Collections;

public class MultiMissile : Projectile 
{
    private Enemy[] enemies;
    private Enemy target;

    private Vector3 pointOne, pointTwo, destination;

    private bool targetFound, MovedForward;
    private float movementInX;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!targetFound)
            FindTarget();
        if (targetFound)
            MoveTo();

        if(!MovedForward)
            MoveForward();

        DestroyAfterTime();
    }

    void FindTarget()
    {
        enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            if (!enemy.lockedOn)
            {
                enemy.lockedOn = true;
                target = enemy;
                targetFound = true;
                break;
            }
        }
    }

    void MoveTo()
    {
        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);

        else
            Die();
    }

    void MoveForward()
    {

    }

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if (target != null)
            {
                target.lockedOn = false;
            }
            coll.gameObject.SendMessage("ApplyDamage", Damage);
            Die();
        }
    }

}
