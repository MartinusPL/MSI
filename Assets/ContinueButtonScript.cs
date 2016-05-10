using UnityEngine;
using System.Collections;

public class ContinueButtonScript : MonoBehaviour {

    public MainMenu menu;

	void OnMouseUp()
    {
        if(menu.gameOn)
        {
            menu.goToGame();
            Time.timeScale = 1;
        }
    }
}
