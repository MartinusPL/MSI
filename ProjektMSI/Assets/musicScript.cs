using UnityEngine;
using System.Collections;

public class musicScript : MonoBehaviour {

    public MainMenu menu;
    private SpriteRenderer spriteRenderer;

    public Sprite play;
    public Sprite dontPlay;

    private bool playing;

    void Start()
    {
        playing = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = play;
    }

    void OnMouseUp()
    {
        playing = !playing;
        if (playing)
        {
            spriteRenderer.sprite = play;
            menu.GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            spriteRenderer.sprite = dontPlay;
            AudioListener.volume = 1;
            menu.GetComponent<AudioSource>().enabled = false;
        }
    }
}
