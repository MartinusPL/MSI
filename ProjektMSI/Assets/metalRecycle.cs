using UnityEngine;
using System.Collections;

public class metalRecycle : MonoBehaviour {

    public MainMenu mainMenu;

    void OnMouseUp()
    {
        mainMenu.goToGame();
    }
}
