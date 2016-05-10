using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {

    public MainMenu mainMenu;

    void OnMouseUp()
    {
        mainMenu.goToMenu();
    }
}
