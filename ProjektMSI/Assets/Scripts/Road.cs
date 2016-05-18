using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {

    private GameObject punkt;
    public bool UpperBlock = false;
    public bool LowerBlock = false;

    //[HideInInspector]
    public Transform[] path = new Transform[18];

	// Use this for initialization
	void Start () {
        for(int i=0; i<16; i++)
        {
            punkt = GameObject.Find("Waypoint" + i);
            path[i] = punkt.GetComponent<Transform>();
        }
        punkt = GameObject.Find("Waypoint3 (1)");
        path[16] = punkt.GetComponent<Transform>();
        punkt = GameObject.Find("Waypoint4 (1)");
        path[17] = punkt.GetComponent<Transform>();
    }
}
