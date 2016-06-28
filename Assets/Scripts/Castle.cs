using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Castle : MonoBehaviour {

    public Text HP;
    public MapScript map;
    public float health = 100;

    private AudioSource audio;

    // ustawienia zwiazane z handicap'em
    private List<DateTime> hits = new List<DateTime>();
    readonly TimeSpan hitMeasureWindow = TimeSpan.FromSeconds(5);
    const int hitTreshold = 4;

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
        DateTime now = DateTime.Now;
        hits.Add(now);

        List<DateTime> newHits = new List<DateTime>();
        foreach (DateTime h in hits)
        {
            if (now - h <= hitMeasureWindow)
            {
                newHits.Add(h);
            }
        }
        hits = newHits;

        if (hits.Count >= hitTreshold)
        {
            map.spawn.SetDifficultyLevel(DifficultyLevel.VeryEasy);
            map.lastDifficultyLevelChange = now;
        }
    }


}
