using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Castle : MonoBehaviour {

    public Text HP;
    public MapScript map;
    public float health = 100;

    private AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        HP.text = "HP: " + health.ToString();

        if(health <= 0)
        {
            health = 100;
            map.killAll();
        }
    }

    public void decreaceHealth(float hurt)
    {
        health -= hurt;
        audio.PlayDelayed(0);
    }
}
