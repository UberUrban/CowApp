using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationPanelScript : MonoBehaviour
{
    Location panelTarget;

    public Text text;

    public void initializePanel(Location l)
    {
        panelTarget = l;
        text.text = (l.getName());
    }

    public void panelClick()
    {
        switch (CowAppScript.listMode)
        {
            case 0:
                break;
            case 1:
                CowAppScript.currentFocusLocation = panelTarget;
                CowAppScript.changeMenu(4);
                break;
            case 2:
                CowAppScript.listMode = 1;
                CowAppScript.requestedLocation = panelTarget;
                /*
                CowAppScript.currentLocationList.Add(panelTarget);
                CowAppScript.targetMenu = CowAppScript.requestingMenu;
                */
                break;
            case 3:
                Farm.getLocations().Remove(panelTarget);
                CowAppScript.listMode = 1;
                CowAppScript.getCurrentMenu().refreshMenu();
                break;
        }
    }
}
