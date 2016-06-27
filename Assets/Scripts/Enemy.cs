using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    
    public Road road;
    public GameObject wreckage;
    public MapScript map;

    protected int nextPoint = 0;
    public float speed = 0.02f;
    public float health = 40;
    public float interval = 0.1f;
    public int damageUniv = 10;
	public int damageSpecialized = 20;

    protected bool permission;  //permission for shooting
    protected Collider2D co; // detected and saved collider


    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();
        map = GameObject.Find("mapa").GetComponent<MapScript>();
        permission = true;
    }

    // funkcja odpowiada za porszanie się wzdłuż trasy i nasłuchiwanie rządania autodestrukcji
    void FixedUpdate()
    {
        if (transform.position.Equals(road.path[nextPoint].position))
        {
            if (!road.UpperBlock && nextPoint == 7)
            {
                nextPoint = 10;
                goto endOfIf;
            }

            else if (road.LowerBlock && nextPoint == 3)
            {
                nextPoint = 16;
                goto endOfIf;
            }

            else if (nextPoint == 16)
            {
                nextPoint = 17;
                goto endOfIf;
            }
            else if (nextPoint == 17)
            {
                nextPoint = 4;
                goto endOfIf;
            }

            else if (nextPoint < (road.path.Length - 3))
                nextPoint++;
        }

        endOfIf:
        transform.position = Vector2.MoveTowards(transform.position, road.path[nextPoint].position, speed);

        if (health <= 0 || map.killYourself) Destroy(gameObject);
    }

    void givePermission() { permission = true; }
}
