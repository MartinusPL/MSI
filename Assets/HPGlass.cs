﻿using UnityEngine;
using System.Collections;

public class HPGlass : MonoBehaviour {

    public GlassEnemy parent;
    private float x;

    // Update is called once per frame
    void Update()
    {
        x = 0.021f * parent.health - 2.1f;
        transform.localPosition = new Vector3(x, 0, 0);
        transform.localScale = new Vector3(parent.health / 100f, 1, 1);
        //transform.localScale * parent.health / 100f;
    }
}
