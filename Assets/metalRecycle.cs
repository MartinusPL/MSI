using UnityEngine;
using System.Collections;

public class metalRecycle : MonoBehaviour {

    public MainMenu mainMenu;

    void OnMouseUp()
    {
        mainMenu.goToGame();
		mainMenu.map.panel.metal.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f, 1.0f, 1.0f);
		mainMenu.map.panel.paper.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f, 1.0f, 0.4f);
		mainMenu.map.panel.plastic.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f, 1.0f, 0.4f);
		mainMenu.map.panel.glass.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f, 1.0f, 0.4f);
    }
}
