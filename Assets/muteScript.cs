using UnityEngine;
using System.Collections;

public class muteScript : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    public Sprite muted;
    public Sprite unmuted;

    private bool mutedGame;

    void Start()
    {
        mutedGame = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unmuted;
        RefreshState();
    }

    void OnMouseUp()
    {
        mutedGame = !mutedGame;
        RefreshState();
    }

    private void RefreshState()
    {
        if (mutedGame)
        {
            spriteRenderer.sprite = muted;
            AudioListener.volume = 0;
        }
        else
        {
            spriteRenderer.sprite = unmuted;
            AudioListener.volume = 1;
        }
    }
}
