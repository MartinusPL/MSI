using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapScript : MonoBehaviour {

    // GUI i spawn
    public Text glassText;
    public Text plasticText;
    public Text paperText;
    public Text metalText;
    public Spawn spawn;

    //wartości surowców
    public int glass;
    public int plastic;
    public int paper;
    public int metal;

    //flaga autodestrukcji
    public bool killYourself;

    void Start()
    {
        resetResources();
        killYourself = false;
    }

    void Update()
    {
        glassText.text =  glass.ToString();
        plasticText.text = plastic.ToString();
        paperText.text = paper.ToString();
        metalText.text = metal.ToString();
    }

    void resetResources()
    {
        glass = 100;
        plastic = 100;
        paper = 100;
        metal = 100;
    }
    
    //używane przez towerPlacement
    public void addGlass(int add) { glass += add; }
    public void addPlastic(int add) { plastic += add; }
    public void addPaper(int add) { paper += add; }
    public void addMetal(int add) { metal += add; }

    //funkcje sprawdzające czy gracz dysponuje wystarcającymi zasobami
    public bool affordGlass() {
        if (glass >= 80 && metal >= 50)
        {
            glass -= 80; metal -= 50;
            return true;
        }
        else return false;
    }

    public bool affordPlastic() {
        if (plastic >= 80 && metal >= 50) 
        {
            plastic -= 80; metal -= 50;
            return true;
        }
        else return false;
    }

    public bool affordPaper() {
        if (paper >= 80 && metal >= 50)
        {
            paper -= 80; metal -= 50;
            return true;
        }
        else return false;
    }

    public bool affordMetal() {
        if (metal >= 100)
        {
            metal -= 100;
            return true;
        }
        else return false;
    }

    public bool affordUniv()
    {
        if (glass >= 50 && plastic >= 50 && paper >= 50 && metal >= 50)
        {
            glass -= 50; plastic -= 50; paper -= 50; metal -= 50;
            return true;
        }
        else return false;
    }

    public bool affordBlock()
    {
        if (glass >= 100 && plastic >= 100 && paper >= 100 && metal >= 100)
        {
            glass -= 100; plastic -= 100; paper -= 100; metal -= 100;
            return true;
        }
        else return false;
    }

    //funkcja stawiająca flagę na czas zapewniający autodestrukcję nasłuchującym obiekton "Enemy" i "Towerom"
    public void killAll()
    {
        killYourself = true;
        spawn.CancelInvoke();
        Invoke("cancelKilling", 0.3f);
    }

    private void cancelKilling() { killYourself = false; }
}
