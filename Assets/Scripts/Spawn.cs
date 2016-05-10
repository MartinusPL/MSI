using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject glassTrash;
    public GameObject paperTrash;
    public GameObject plasticTrash;
    public GameObject metalTrash;
    public MapScript map;

    public float interval = 1;
    public int waveSize = 15;
    public float speed = 0.1f;
    public int waveNumber = 0;

    public bool glassEnabled = false;
    public bool paperEnabled = false;
    public bool plasticEnabled = true;
    public bool metalEnabled = false;

    private bool[] elements = new bool[4];
    private int spawnedMonsters;
    public bool spawning = false;

    // Use this for initialization
    void Start()
    {
        spawnedMonsters = 0;
        spawning = false;
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

        if (a == 0)
        {
            GameObject g = Instantiate(glassTrash, transform.position, Quaternion.identity) as GameObject;
            g.GetComponent<GlassEnemy>().speed = speed;
        }
            
        else if (a == 1)
        {
            GameObject g = Instantiate(paperTrash, transform.position, Quaternion.identity) as GameObject;
            g.GetComponent<PaperEnemy>().speed = speed;
        }
            
        else if (a == 2)
        {
            GameObject g = Instantiate(plasticTrash, transform.position, Quaternion.identity) as GameObject;
            g.GetComponent<PlasticEnemy>().speed = speed;
        }
        else if (a == 3)
        {
            GameObject g = Instantiate(metalTrash, transform.position, Quaternion.identity) as GameObject;
            g.GetComponent<MetalEnemy>().speed = speed;
        }

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
