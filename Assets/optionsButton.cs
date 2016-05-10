using UnityEngine;
using System.Collections;

public class optionsButton : MonoBehaviour {

    public MainMenu menu;
	
	void OnMouseUp()
    {
        menu.goToOptions();
    }
}
