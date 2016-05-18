using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    //komunikacja
    public Camera mainCamera;
    public MapScript map;
    public Spawn spawn;

    //lokalizacje poszczególnych scen
    private Vector3 gamePosition = new Vector3(0, 0, -1.5f);
    private Vector3 menuPosition = new Vector3(-25, 0, -3);
    private Vector3 options = new Vector3(-25, 20, -3);
    private Vector3 losePosition = new Vector3(24, 0, -3);
    private Vector3 metalEd = new Vector3(-30, -19, -3);
    private Vector3 plasticEd = new Vector3(-9, -19, -3);
    private Vector3 paperEd = new Vector3(14, -19, -3);
    private Vector3 glassEd = new Vector3(37, -19, -3);
    private Vector3 Win = new Vector3(60, -19, -3);

    public Text levelText;
    public int levelNr = 0;

    //zmienne sterujące falami przeciwników
    public float interval = 1;
    public int waveSize = 15;
    public float speed = 0.1f;
    public int waveLimit = 10;
    public int waveNr = 0;
    public Text waveText;

    //określenie rodzajów tworzonych przeciwników
    public bool glassEnabled;
    public bool paperEnabled;
    public bool plasticEnabled;
    public bool metalEnabled;

    public bool gameOn { get; set; }    //czy aktualnie gra się toczy czy nie?

    // Use this for initialization
    void Start()    {
        goToMenu();
        gameOn = false;
    }
    
    //metody przekierowujące kamerę na odpowiednie pozycje
    public void goToMenu() { mainCamera.transform.position = menuPosition; }
    public void goToGame() { mainCamera.transform.position = gamePosition; }
    public void goToOptions() { mainCamera.transform.position = options; }
    public void goToMetalEd() { mainCamera.transform.position = metalEd; }
    public void goToPlasticEd() { mainCamera.transform.position = plasticEd; }
    public void goToPaperEd() { mainCamera.transform.position = paperEd; }
    public void goToGlassEd() { mainCamera.transform.position = glassEd; }
    public void goToWin() { mainCamera.transform.position = Win; }

    //aktualizacja wyświetlanych na GUI danych
    void Update()
    {
        levelText.text = "Poziom: " + levelNr;
        waveText.text = "Fala: " + waveNr + "/" + waveSize;
    }

    //nasłuch rozkacu autodestrukcji i istnienia wrogów z ostatniej fali
    void FixedUpdate() {
        if (map.killYourself)
        {
            mainCamera.transform.position = losePosition;
            levelNr = 1;
            waveNr = 0;
            gameOn = false;
        }

        if (waveNr == waveLimit && !spawn.spawning)
            if (GameObject.Find("Glass(Clone)") == null
                && GameObject.Find("Metal(Clone)") == null
                && GameObject.Find("Plastic(Clone)") == null
                && GameObject.Find("Paper(Clone)") == null)
                nextLevel();
    }

    public void nextWaveRequirement()
    {
        waveNr++;
        resetEnemies();
        setEnemies();
        spawn.startSpawning(glassEnabled, paperEnabled, plasticEnabled, metalEnabled, waveSize, interval, speed);
    }

    public bool nextLevel()
    {
        levelNr++;
        waveNr = 0;
        if (levelNr > 5)
        {
            goToWin();
            map.killAll();
            levelNr = 1;
            return false;
        }
        else {
            setCam();
            return true;
        }
    }
    
    public int getLvl() { return levelNr; }

    void setCam()
    {
        if (levelNr == 1) goToMetalEd();
        if (levelNr == 2) goToPaperEd();
        if (levelNr == 3) goToPlasticEd();
        if (levelNr == 4) goToGlassEd();
        if (levelNr == 5) goToGame();
    }

    void resetEnemies()
    {
        glassEnabled = false;
        paperEnabled = false;
        plasticEnabled = false;
        metalEnabled = false;
    }

    void setEnemies()
    {
        metalEnabled = true;
        if(levelNr>=2) paperEnabled = true;
        if(levelNr>=3) plasticEnabled = true;
        if(levelNr>=4) glassEnabled = true;
    }
    
}