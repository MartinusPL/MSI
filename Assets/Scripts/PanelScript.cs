using UnityEngine;
using System.Collections;

public class PanelScript : MonoBehaviour {

    public Button plastic;
    public Button metal;
    public Button glass;
    public Button universal;
    public Button paper;
    public Button delete;

    public TowerPlacing newTowerplacing;

    public void checkButton()
    {
        if (newTowerplacing != null)
            if (!newTowerplacing.sth)
            {
                if (plastic.checkMe()) newTowerplacing.callPlastic();
                else if (paper.checkMe()) newTowerplacing.callPaper();
                else if (glass.checkMe()) newTowerplacing.callGlass();
                else if (metal.checkMe()) newTowerplacing.callMetal();
                else if (universal.checkMe()) newTowerplacing.callUniv();
            }
            else
                if (delete.checkMe()) newTowerplacing.uncall();
    }
    
    public void selection(TowerPlacing newTowerplacing)
    {
        if(this.newTowerplacing != null)
            this.newTowerplacing.unselect();
        this.newTowerplacing = newTowerplacing;
    }

    public void unselection()
    {
        newTowerplacing = null;
    }
}
