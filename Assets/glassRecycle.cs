using UnityEngine;
using System.Collections;

public class glassRecycle : MonoBehaviour {

    public MainMenu mainMenu;

    void OnMouseUp()
    {
        mainMenu.goToGame();
    }
}
