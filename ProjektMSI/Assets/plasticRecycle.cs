using UnityEngine;
using System.Collections;

public class plasticRecycle : MonoBehaviour {

    public MainMenu mainMenu;

    void OnMouseUp()
    {
        mainMenu.goToGame();
    }
}
