﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GlassEnemy : Enemy
{
    public int damageGlass = 20;

    void OnTriggerStay2D(Collider2D co)
    {
        // Is it my tower? Then degrade!
        if (permission && co.GetComponent<Range>())
        {
            Range access = co.GetComponent<Range>();
            if ((access.glassTower || access.universalTower) && !access.boxFull)
            {
                this.co = co;
                Shoot();
                Invoke("givePermission", interval);
            }
        }

        if (co.GetComponent<Castle>())
        {
            co.GetComponent<Castle>().decreaceHealth(health * 0.1f);
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        permission = false;
        GameObject g = Instantiate(wreckage, transform.position, Quaternion.identity) as GameObject;
        if (co.GetComponent<Range>().glassTower)
        {
            health -= damageGlass;
            g.GetComponent<Wreckage>().load = damageGlass;
        }
        if (co.GetComponent<Range>().universalTower)
        {
            health -= damageUniv;
            g.GetComponent<Wreckage>().load = damageUniv;
        }
        g.GetComponent<Wreckage>().target = co.transform;
        g.GetComponent<SpriteRenderer>().sprite = g.GetComponent<Wreckage>().glass;
    }
}