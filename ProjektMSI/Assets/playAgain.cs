using UnityEngine;
using System.Collections;

public class playAgain : MonoBehaviour {

    public MainMenu menu;

    void OnMouseUp()
    {
        menu.goToMenu();
    }
}
