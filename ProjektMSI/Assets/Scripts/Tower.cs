using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{

}

//using UnityEngine;
//using System.Collections;

//public class Tower : MonoBehaviour {

//    public PanelScript panel;
//    public TowerPlacing emptyPlaceScript;
//    public Range range;
//    public GameObject map;

//    public Sprite selectedPaper;
//    public Sprite unselectedPaper;
//    public Sprite selectedGlass;
//    public Sprite unselectedGlass;
//    public Sprite selectedPlastic;
//    public Sprite unselectedPlastic;
//    public Sprite selectedMetal;
//    public Sprite unselectedMetal;
//    public Sprite selectedUniversal;
//    public Sprite unselectedUniversal;

//    private SpriteRenderer spriteRenderer;
//    private bool selected;
//    public int collected;

//    private enum name { Paper, Glass, Plastic, Metal, Universal };
//    name callingName;

//    void Start()
//    {
//        collected = 0;
//        enabled = false;
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        selected = false;
//    }

//    void OnMouseUp()
//    {
//        if(enabled)
//        {
//            if (selected) unselect();
//            else {
//                panel.resetTowers();
//                Invoke("select", 0.06f);
//            }
//        }
//    }

//    void Update()   {  if (selected)    actionSelect(); }
//    void FixedUpdate() { if (panel.killYourself) unselect(); }

//    void select()
//    {
//        if (callingName == name.Plastic) spriteRenderer.sprite = selectedPlastic;
//        if (callingName == name.Metal) spriteRenderer.sprite = selectedMetal;
//        if (callingName == name.Paper) spriteRenderer.sprite = selectedPaper;
//        if (callingName == name.Glass) spriteRenderer.sprite = selectedGlass;
//        if (callingName == name.Universal) spriteRenderer.sprite = selectedUniversal;

//        selected = true;
//        panel.towerSelected = true;
//    }

//    void unselect()
//    {
//        if (callingName == name.Plastic) spriteRenderer.sprite = unselectedPlastic;
//        if (callingName == name.Metal) spriteRenderer.sprite = unselectedMetal;
//        if (callingName == name.Paper) spriteRenderer.sprite = unselectedPaper;
//        if (callingName == name.Glass) spriteRenderer.sprite = unselectedGlass;
//        if (callingName == name.Universal) spriteRenderer.sprite = unselectedUniversal;

//        selected = false;
//        panel.towerSelected = false;
//    }


//    void actionSelect()
//    {
//        if (panel.delete.checkMe()) killTower();
//    }

//    void killTower()
//    {
//        emptyPlaceScript.enabled = true;
//        emptyPlaceScript.spriteRenderer.sprite = emptyPlaceScript.emptyPlace;
//        enabled = false;
//        panel.towerSelected = false;
//        range.destroyTower();
//    }

//    public void enableGlass()
//    {
//        enabled = true;
//        selected = false;
//        spriteRenderer.sprite = unselectedGlass;
//        callingName = (name)1;
//        range.glassTower = true;
//    }

//    public void enablePlastic()
//    {
//        enabled = true;
//        selected = false;
//        spriteRenderer.sprite = unselectedPlastic;
//        callingName = (name)2;
//        range.plasticTower = true;
//    }

//    public void enablePaper()
//    {
//        enabled = true;
//        selected = false;
//        spriteRenderer.sprite = unselectedPaper;
//        callingName = (name)0;
//        range.paperTower = true;
//    }

//    public void enableMetal()
//    {
//        enabled = true;
//        selected = false;
//        spriteRenderer.sprite = unselectedMetal;
//        callingName = (name)3;
//        range.metalTower = true;
//    }

//    public void enableUniversal()
//    {
//        enabled = true;
//        selected = false;
//        spriteRenderer.sprite = unselectedUniversal;
//        callingName = (name)4;
//        range.universalTower = true;
//    }

//}
