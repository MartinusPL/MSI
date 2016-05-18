using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {

    private bool paused;
    
	void Start () {
        paused = false;
	}

    void OnMouseUp()
    {
        if (paused) Time.timeScale = 1;
        if (!paused) Time.timeScale = 0;
        paused = !paused;
    }
}
