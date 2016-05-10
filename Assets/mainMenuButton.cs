using UnityEngine;
using System.Collections;

public class mainMenuButton : MonoBehaviour {

    public MainMenu menu;

    void OnMouseUp()
    {
        menu.goToMenu();
    }
}
