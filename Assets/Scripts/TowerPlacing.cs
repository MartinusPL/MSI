using UnityEngine;
using System.Collections;

public class TowerPlacing : MonoBehaviour
{
    public PanelScript panel;
    public MapScript map;
    public Range range;
    private SpriteRenderer spriteRenderer;

    public Sprite selectedPaper;
    public Sprite unselectedPaper;
    public Sprite selectedGlass;
    public Sprite unselectedGlass;
    public Sprite selectedPlastic;
    public Sprite unselectedPlastic;
    public Sprite selectedMetal;
    public Sprite unselectedMetal;
    public Sprite selectedUniversal;
    public Sprite unselectedUniversal;
    public Sprite selectedPlace;
    public Sprite emptyPlace;

    public bool paperSet;
    public bool glassSet;
    public bool plasticSet;
    public bool metalSet;
    public bool univSet;
    public bool sth;

    private bool selected;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = emptyPlace;
        selected = false;
        paperSet = false;
        glassSet = false;
        plasticSet = false;
        metalSet = false;
        univSet = false;
        sth = false;
    }

    void FixedUpdate() {
        if (paperSet || glassSet || plasticSet || metalSet || univSet) sth = true;
        if (map.killYourself)
        {
            uncall();
            spriteRenderer.sprite = emptyPlace;
        }
    }

    void OnMouseUp()
    {
        range.emptyTower();
        if (selected) unselect();
        else { select(); }
    }
    
    void select()
    {
        panel.selection(this);
        selected = true;
        selectedSprite();
    }

    public void unselect()
    {
        panel.unselection();
        selected = false;
        unselectedSprite();
    }

    void selectedSprite()
    {
        if (paperSet) spriteRenderer.sprite = selectedPaper;
        else if (plasticSet) spriteRenderer.sprite = selectedPlastic;
        else if (glassSet) spriteRenderer.sprite = selectedGlass;
        else if (metalSet) spriteRenderer.sprite = selectedMetal;
        else if (univSet) spriteRenderer.sprite = selectedUniversal;
        else spriteRenderer.sprite = selectedPlace;
    }

    void unselectedSprite()
    {
        if (paperSet) spriteRenderer.sprite = unselectedPaper;
        else if (plasticSet) spriteRenderer.sprite = unselectedPlastic;
        else if (glassSet) spriteRenderer.sprite = unselectedGlass;
        else if (metalSet) spriteRenderer.sprite = unselectedMetal;
        else if (univSet) spriteRenderer.sprite = unselectedUniversal;
        else spriteRenderer.sprite = emptyPlace;
    }

    public void callPaper()
    {
        if(map.affordPaper())
        {
            paperSet = true;
            spriteRenderer.sprite = selectedPaper;
            range.paperTower = paperSet;
        }
    }

    public void callPlastic()
    {
        if(map.affordPlastic())
        {
            plasticSet = true;
            spriteRenderer.sprite = selectedPlastic;
            range.plasticTower = plasticSet;
        }
    }

    public void callGlass()
    {
        if(map.affordGlass())
        {
            glassSet = true;
            spriteRenderer.sprite = selectedGlass;
            range.glassTower = glassSet;
        }
    }

    public void callMetal()
    {
        if(map.affordMetal())
        {
            metalSet = true;
            spriteRenderer.sprite = selectedMetal;
            range.metalTower = metalSet;
        }
    }

    public void callUniv()
    {
        if (map.affordUniv())
        {
            univSet = true;
            spriteRenderer.sprite = selectedUniversal;
            range.universalTower = univSet;
        }
    }

    public void uncall()
    {
        univSet = false;
        metalSet = false;
        glassSet = false;
        plasticSet = false;
        paperSet = false;
        sth = false;
        spriteRenderer.sprite = selectedPlace;
        selected = false;
        range.uncall();
    }
}