using UnityEngine;
using System.Collections;

public class blockScript : MonoBehaviour {

    public MapScript map;
    public Sprite gate;
    private SpriteRenderer sr;
    public AudioSource setingGateSound;

    void Start()
    {
        setingGateSound = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        resetGate();
    }

    public void setGate()
    {
        setingGateSound.PlayDelayed(0);
        sr.sprite = gate;
    }

    public void resetGate()
    {
        sr.sprite = null;
    }

    void FixedUpdate()
    {
        if (map.killYourself) resetGate();
    }
}
