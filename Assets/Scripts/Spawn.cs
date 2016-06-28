using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public enum DifficultyLevel {
	VeryEasy,
	Easy,
	Normal
}

public class Spawn : MonoBehaviour
{
    public GameObject glassTrash;
    public GameObject paperTrash;
    public GameObject plasticTrash;
    public GameObject metalTrash;
    public MapScript map;

    public float interval = 1;
    public int waveSize = 15;
	public float speed;
    public int waveNumber = 0;

    public bool glassEnabled = false;
    public bool paperEnabled = false;
    public bool plasticEnabled = true;
    public bool metalEnabled = false;

    private bool[] elements = new bool[4];
    private int spawnedMonsters;
    public bool spawning = false;
	public DifficultyLevel difficultyLevel;

	public List<GameObject> monsters = new List<GameObject> ();

    // Use this for initialization
    void Start()
    {
        spawnedMonsters = 0;
        spawning = false;
		SetDifficultyLevel (DifficultyLevel.Normal);
    }

	public void SetDifficultyLevel(DifficultyLevel level) {
		switch (level) {
		case DifficultyLevel.VeryEasy:
			speed = 0.025f;
            interval = 4;
			break;
		case DifficultyLevel.Easy:
			speed = 0.05f;
            interval = 2;
			break;
		case DifficultyLevel.Normal:
			speed = 0.1f;
            interval = 1;
			break;
		}
		difficultyLevel = level;

		foreach (GameObject go in monsters) {
            if (go != null)
		        go.GetComponent<Enemy>().speed = speed;
		}

	    if (spawning)
	    {
	        CancelInvoke("SpawnMonster");
	        InvokeRepeating("SpawnMonster", 0, interval);
	    }
	}

	public void RemoveDeadMonsters() {
        if (monsters.Count == 0)
            return;

        // przepisanie listy potworow (zostaja tylko te zywe)
		List<GameObject> newMonsters = new List<GameObject> ();
		foreach (GameObject go in monsters) {
			if (go != null) {
				newMonsters.Add (go);
			}
		}
		monsters = newMonsters;
	}

    void rewrite()
    {
        elements[0] = glassEnabled;
        elements[1] = paperEnabled;
        elements[2] = plasticEnabled;
        elements[3] = metalEnabled;
    }

    void SpawnMonster()
    {
        int a;
        do{   a = (int)(Random.Range(0, 3.99999f));   } while (!elements[a]);

		GameObject g;

        if (a == 0)
        {
            g = Instantiate(glassTrash, transform.position, Quaternion.identity) as GameObject;
        }
            
        else if (a == 1)
        {
            g = Instantiate(paperTrash, transform.position, Quaternion.identity) as GameObject;
        }
            
        else if (a == 2)
        {
            g = Instantiate(plasticTrash, transform.position, Quaternion.identity) as GameObject;
        }
        else 
        {
            g = Instantiate(metalTrash, transform.position, Quaternion.identity) as GameObject;
        }

		g.GetComponent<Enemy>().speed = speed;
		monsters.Add (g);

        spawnedMonsters++;
        if (spawnedMonsters >= waveSize) resetAfterWave();
    }

    public void startSpawning(bool glass, bool paper, bool plastic, bool metal, int numberOfMonsters, float interval, float speed)
    {
        glassEnabled = glass; paperEnabled = paper;
        plasticEnabled = plastic; metalEnabled = metal;
        waveSize = numberOfMonsters;
        this.interval = interval; this.speed = speed;
        rewrite();
        InvokeRepeating("SpawnMonster", 0, interval);
        spawning = true;
    }

    void FixedUpdate()
    {
        if (map.killYourself) resetAfterWave();
    }

    void resetAfterWave()
    {
        CancelInvoke("SpawnMonster");
        spawnedMonsters = 0;
        spawning = false;
    }
}
