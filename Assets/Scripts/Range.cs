using UnityEngine;
using System.Collections;

public class Range : MonoBehaviour {

    public TowerPlacing parent;
    public MapScript map;
    private SpriteRenderer sprite;

    //określenie rodzaju wieży
    public bool glassTower;
    public bool plasticTower;
    public bool paperTower;
    public bool metalTower;
    public bool universalTower;
    public Sprite warning;

    public int paperWreckage;
    public int glassWreckage;
    public int plasticWreckage;
    public int metalWreckage;
    public bool boxFull;  //ustawiane gdy kubeł jest pełen (niezdolny do przyjęcia następnych śmieci)
	public int boxCapacity = 1000;

    private MapScript access;
    private CircleCollider2D triggerCollider;
    private AudioSource emptySound;
    private float radius;

    void Start()
    {
        access = map.GetComponent<MapScript>();
        sprite = GetComponent<SpriteRenderer>();
        emptySound = GetComponentInParent<AudioSource>();
        sprite.sprite = null;
        zeroAll();
        boxFull = false;

        triggerCollider = GetComponent<CircleCollider2D>();
        radius = triggerCollider.radius;
    }

    void FixedUpdate()
    {
		if ( (paperWreckage + glassWreckage + plasticWreckage + metalWreckage >= boxCapacity) && !boxFull)
        {
            boxFull = true;
            sprite.sprite = warning;
            triggerCollider.radius = 0;
        }
    }

    public void emptyTower()
    {
        if (metalWreckage + glassWreckage + plasticWreckage + paperWreckage > 0) emptySound.PlayDelayed(0);
        access.addMetal(metalWreckage);
        access.addGlass(glassWreckage);
        access.addPlastic(plasticWreckage);
        access.addPaper(paperWreckage);
        zeroAll();
        sprite.sprite = null;
        triggerCollider.radius = radius;
    }

    void zeroAll()
    {
        paperWreckage = 0;
        glassWreckage = 0;
        plasticWreckage = 0;
        metalWreckage = 0;
        boxFull = false;
    }

    public void uncall()
    {
        zeroAll();
        glassTower = plasticTower = paperTower = metalTower = universalTower = false;
    }
}
