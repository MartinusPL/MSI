using UnityEngine;
using System.Collections;

public class paperRecycle : MonoBehaviour {

    public MainMenu mainMenu;

    void OnMouseUp()
    {
        mainMenu.goToGame();
    }
}
