using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    public PanelScript panel;
    
    public bool selected;

    void Start()
    {
        unselect();
    }
    
    void OnMouseUp()
    {
        selected = true;
        panel.checkButton();
        unselect();
    }

    public void unselect() { selected = false; }
    public bool checkMe() { return selected; }
}