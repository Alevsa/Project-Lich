using UnityEngine;
using System.Collections;

public class MultiMissile : Projectile 
{
    private Enemy[] enemies;
    private Enemy target;
    private bool targetFound;

    private Vector2 currentPosition;
    private Vector3 rotation;
    private float xDif, yDif;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!targetFound)
            FindTarget();
        if (targetFound && target != null)
            MoveTo(target.transform.position);
        if (targetFound && target == null)
            Die();

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

    void MoveTo(Vector2 target)
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
        xDif = target.x - currentPosition.x;
        yDif = target.y - currentPosition.y;
        
        rotation = Vector3.zero;
        rotation.z = Mathf.Atan(yDif/xDif) * Mathf.Rad2Deg - (xDif > 0 ? 90 : -90);
                
        transform.rotation = Quaternion.Euler(rotation);
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
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
            coll.gameObject.SendMessage("SpawnExplosion", transform.position);
            Die();
        }
    }
}
