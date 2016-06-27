﻿using UnityEngine;
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

    //wartości surowców
    public int glass;
    public int plastic;
    public int paper;
    public int metal;

	private List<DateTime> clicks = new List<DateTime>();
	public bool handicapMode = false;
	public DateTime lastDifficultyLevelChange = DateTime.Now;

    //flaga autodestrukcji
    public bool killYourself;

    void Start()
    {
        resetResources();
        killYourself = false;
    }

    void Update()
    {
		CheckClicks();


        glassText.text =  glass.ToString();
        plasticText.text = plastic.ToString();
        paperText.text = paper.ToString();
        metalText.text = metal.ToString();
    }

	void CheckClicks() {

		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) {

			TimeSpan clickMeasureWindow = TimeSpan.FromSeconds (1);
			TimeSpan changeInterval = TimeSpan.FromSeconds (5);
			const int clickTreshold = 5;

			DateTime now = DateTime.Now;
			List<DateTime> newClicks = new List<DateTime>();

			clicks.Add(now);
			foreach (DateTime click in clicks) {

				if (now - click <= clickMeasureWindow) {
					newClicks.Add (click);
				}
			}
			clicks = newClicks;

			if ((clicks.Count > clickTreshold) && (now - lastDifficultyLevelChange > changeInterval)) {
				if (spawn.difficultyLevel != DifficultyLevel.VeryEasy) {
					spawn.SetDifficultyLevel (spawn.difficultyLevel - 1);
				}
			} else if (now - lastDifficultyLevelChange > changeInterval) {
				if (spawn.difficultyLevel != DifficultyLevel.Normal) {
					spawn.SetDifficultyLevel(spawn.difficultyLevel + 1);
				}
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
