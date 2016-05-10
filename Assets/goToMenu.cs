using UnityEngine;
using System.Collections;

public class goToMenu : MonoBehaviour {

    public MainMenu menu;

    void OnMouseUp()
    {
        Time.timeScale = 0;
        menu.goToMenu();
    }
}
