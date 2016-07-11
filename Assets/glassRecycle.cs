using UnityEngine;
using System.Collections;

public class glassRecycle : MonoBehaviour {

    public MainMenu mainMenu;

    void OnMouseUp()
    {
        mainMenu.goToGame();
		mainMenu.map.panel.metal.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f, 1.0f, 1.0f);
		mainMenu.map.panel.paper.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f, 1.0f, 1.0f);
		mainMenu.map.panel.plastic.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f, 1.0f, 1.0f);
		mainMenu.map.panel.glass.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f, 1.0f, 1.0f);  
	}
}
