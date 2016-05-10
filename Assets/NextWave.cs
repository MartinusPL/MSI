using UnityEngine;
using System.Collections;

public class NextWave : MonoBehaviour {
    
    public Spawn spawn;
    public MainMenu menu;

    public bool glassEnabled = false;
    public bool paperEnabled = false;
    public bool plasticEnabled = false;
    public bool metalEnabled = false;

    void OnMouseUp()
    {
        if (!spawn.spawning && menu.waveNr<menu.waveLimit)
            menu.nextWaveRequirement();
    }
}
