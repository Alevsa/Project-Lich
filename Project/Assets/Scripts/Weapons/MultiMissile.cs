using UnityEngine;
using System.Collections;

public class MultiMissile : Projectile 
{
    //private Enemy targetCheck, target;
    //public float Magnitude;
    //public float Frequency;

    //private bool targetFound;
    //// Use this for initialization
    //void Start () 
    //{
	
    //}
	
    //// Update is called once per frame
    //void Update () 
    //{
    //    if (FindTarget())
    //    {
    //        targetFound = true;
    //    }
    //    if (targetFound)
    //    {
    //        MoveTo();
    //    }
	
    //}

    //bool FindTarget()
    //{
    //    while (target == null)
    //    {
    //        targetCheck = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    //        if (!targetCheck.lockedOn)
    //        {
    //            targetCheck.lockedOn = true;
    //            target = targetCheck;
    //            return true;
    //        }
    //        else
    //            targetCheck = null;
    //    }

    //    return false;
    //}

    //void MoveTo()
    //{
    //    movement += (target.transform.position - transform.position).normalized * Speed + Vector3.Cross(target.transform.position - transform.position, Vector3.forward).normalized * Mathf.Sin(Time.time * Frequency) * Magnitude * Speed;
    //}

    //public override void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coll.gameObject.tag == "Enemy")
    //        coll.gameObject.SendMessage("ApplyDamage", Damage);
    //    if(target != null)
    //}

}
