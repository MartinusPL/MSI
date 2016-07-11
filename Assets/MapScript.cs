using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml.Linq;
using System.Security.Cryptography;

public class MapScript : MonoBehaviour {

    // GUI i spawn
    public Text glassText;
    public Text plasticText;
    public Text paperText;
    public Text metalText;
    public Spawn spawn;
    public Road road;
	public PanelScript panel;

	// labele pokazujące przybywanie surowców
	public Text glassPlus;
	public Text plasticPlus;
	public Text paperPlus;
	public Text metalPlus;

    //wartości surowców
    public int glass;
    public int plastic;
    public int paper;
    public int metal;

    // ustawienia zwiazane z handicap'em
	private List<DateTime> clicks = new List<DateTime>();
	public bool handicapMode = false;
	public DateTime lastDifficultyLevelChange = DateTime.Now;
    public TimeSpan clickMeasureWindow = TimeSpan.FromSeconds(1);
    public TimeSpan changeInterval = TimeSpan.FromSeconds(5);
    const int clickTreshold = 3;

    //flaga autodestrukcji
    public bool killYourself;

    void Start()
    {
        resetResources();
        killYourself = false;
		hidePluses();
    }

    void Update()
    {
		CheckClicks();

        glassText.text = glass.ToString();
        plasticText.text = plastic.ToString();
        paperText.text = paper.ToString();
        metalText.text = metal.ToString();

        spawn.RemoveDeadMonsters();
    }

    // sprawdzanie ile razy w ciagu sekundy uzytkownik kliknal
    // jezeli wiecej niz clickTreshold, to zmniejszamy poziom trudnosci
	void CheckClicks() {
        DateTime now = DateTime.Now;

		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) {
			List<DateTime> newClicks = new List<DateTime>();

			clicks.Add(now);
			foreach (DateTime click in clicks) {

				if (now - click <= clickMeasureWindow) {
					newClicks.Add (click);
				}
			}
			clicks = newClicks;

		    if ((clicks.Count > clickTreshold) && (now - lastDifficultyLevelChange > changeInterval))
		    {
		        if (spawn.difficultyLevel != DifficultyLevel.VeryEasy)
		        {
                    spawn.SetDifficultyLevel(DifficultyLevel.VeryEasy);
                    lastDifficultyLevelChange = now;
		        }
		    }
		}

        if (now - lastDifficultyLevelChange > changeInterval) {
		    if (spawn.difficultyLevel != DifficultyLevel.Normal) {
			    spawn.SetDifficultyLevel(spawn.difficultyLevel + 1);
		        lastDifficultyLevelChange = now;
		    }
	    }
	}

    void resetResources()
    {
        glass = 500;
        plastic = 500;
        paper = 500;
        metal = 500;
    }

	public void hidePluses() {

		Text[] texts = { glassPlus, plasticPlus, paperPlus, metalPlus };
		foreach (Text text in texts) {
			text.text = "";
		}
	}
    
    //używane przez towerPlacement
    public void addGlass(int add) { 
		glass += add;
		if (add > 0) {
			glassPlus.text = "+" + add.ToString ();
			Invoke ("hidePluses", 1.0f);
		}
	}

    public void addPlastic(int add) { 
		plastic += add; 
		if (add > 0) {
			plasticPlus.text = "+" + add.ToString ();
			Invoke ("hidePluses", 1.0f);
		}
	}

    public void addPaper(int add) { 
		paper += add; 
		if (add > 0) {
			paperPlus.text = "+" + add.ToString ();
			Invoke ("hidePluses", 1.0f);
		}
	}

    public void addMetal(int add) {
		metal += add; 
		if (add > 0) {
			metalPlus.text = "+" + add.ToString ();
			Invoke ("hidePluses", 1.0f);
		}
	}

    //funkcje sprawdzające czy gracz dysponuje wystarcającymi zasobami
    public bool affordGlass() {
        if (glass >= 80 && metal >= 20)
        {
            glass -= 80; metal -= 20;

			glassPlus.text = "-80";
			metalPlus.text = "-20";
			Invoke ("hidePluses", 1.0f);
            return true;
        }
        else return false;
    }

    public bool affordPlastic() {
        if (plastic >= 80 && metal >= 20) 
        {
            plastic -= 80; metal -= 20;

			plasticPlus.text = "-80";
			metalPlus.text = "-20";
			Invoke ("hidePluses", 1.0f);
            return true;
        }
        else return false;
    }

    public bool affordPaper() {
        if (paper >= 80 && metal >= 20)
        {
            paper -= 80; metal -= 20;

			paperPlus.text = "-80";
			metalPlus.text = "-20";
			Invoke ("hidePluses", 1.0f);
            return true;
        }
        else return false;
    }

    public bool affordMetal() {
        if (metal >= 100)
        {
            metal -= 100;

			metalPlus.text = "-100";
			Invoke ("hidePluses", 1.0f);		
            return true;
        }
        else return false;
    }

    public bool affordUniv()
    {
        if (glass >= 50 && plastic >= 50 && paper >= 50 && metal >= 50)
        {
            glass -= 50; plastic -= 50; paper -= 50; metal -= 50;

			glassPlus.text = "-50";
			plasticPlus.text = "-50";
			paperPlus.text = "-50";
			metalPlus.text = "-50";
			Invoke ("hidePluses", 1.0f);
            return true;
        }
        else return false;
    }

    public bool affordBlock()
    {
        if (glass >= 100 && plastic >= 100 && paper >= 100 && metal >= 100)
        {
            glass -= 100; plastic -= 100; paper -= 100; metal -= 100;

			glassPlus.text = "-100";
			plasticPlus.text = "-100";
			paperPlus.text = "-100";
			metalPlus.text = "-100";
			Invoke ("hidePluses", 1.0f);
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
        glass = 500;
        plastic = 500;
        paper = 400;
        metal = 700;
    }

    private void cancelKilling() { killYourself = false; }
}
