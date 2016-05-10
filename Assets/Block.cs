using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    public MapScript map;
    public blockScript blockingElement;
    public Road road;

    void OnMouseUp()
    {
        if (map.affordBlock())
        {
            blockingElement.setGate();
            if (gameObject.name.Equals("LowerBlockButton")) road.LowerBlock = true;
            else road.UpperBlock = true;

            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
