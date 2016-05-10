using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

    public MainMenu mainMenu;
    public MapScript map;

	void OnMouseUp()
    {
        if (mainMenu.gameOn)
        {
            map.killAll();
            Invoke("SetGame", 0.31f);
        }
        else SetGame();
    }

    void SetGame()
    {
        mainMenu.goToMetalEd();
        Time.timeScale = 1;
        mainMenu.gameOn = true;
    }
}
