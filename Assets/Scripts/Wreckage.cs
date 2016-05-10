using UnityEngine;
using System.Collections;

public class Wreckage : MonoBehaviour {

    public Transform target;
    public Sprite glass;
    public Sprite plactic;
    public Sprite metal;
    public Sprite paper;

    public AudioClip glassSound;
    public AudioClip plasticSound;
    public AudioClip metalSound;
    public AudioClip paperSound;
    public AudioSource wreckageSound;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer picture;
    
    public int load;
    private bool hit;
    public float speed = 0.1f;

    void Start()
    {
        hit = false;
        wreckageSound = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate () {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);

        if (transform.position.Equals(target.position) && !hit)
        {
            spriteRenderer.enabled = false;
            hit = true;
            picture = GetComponent<SpriteRenderer>();

            if (picture.sprite.Equals(glass))
            {
                wreckageSound.clip = glassSound;
                target.GetComponent<Range>().glassWreckage += load;
            }
            else if (picture.sprite.Equals(plactic))
            {
                wreckageSound.clip = plasticSound;
                target.GetComponent<Range>().plasticWreckage += load;
            }
            else if (picture.sprite.Equals(metal))
            {
                wreckageSound.clip = metalSound;
                target.GetComponent<Range>().metalWreckage += load;
            }
            else if (picture.sprite.Equals(paper))
            {
                wreckageSound.clip = paperSound;
                target.GetComponent<Range>().paperWreckage += load;
            }

            wreckageSound.PlayDelayed(0);
            Invoke("suicide", 0.4f);
        }
    }

    private void suicide()
    {
        Destroy(gameObject);
    }
}
