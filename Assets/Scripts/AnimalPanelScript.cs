using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimalPanelScript : MonoBehaviour
{
    Animal panelTarget;
    public Text text;

    private bool marked = false;

    public void initializePanel(Animal a)
    {
        panelTarget = a;
        text.text = (a.getID() + " - " +a.getName());
    }

    public Animal getPanelTarget()
    {
        return panelTarget;
    }

    public bool isPressed()
    {
        return marked;
    }

    public void onPress()
    {
        marked = !marked;
    }

    public void panelClick()
    {
        switch(CowAppScript.listMode)
        {
            case 0:
                break;
            case 1:
                CowAppScript.currentFocusAnimal = panelTarget;
                CowAppScript.changeMenu(3);
                CowAppScript.getCurrentMenu().refreshMenu();
                break;
            case 2:
                CowAppScript.listMode = 1;
                CowAppScript.requestedAnimal = panelTarget;
                /*Farm.removeAnimalFromAllLocations(panelTarget);
                CowAppScript.currentAnimalList.Add(panelTarget);
                CowAppScript.targetMenu = CowAppScript.requestingMenu;*/
                break;
            case 3:
                Farm.removeAnimal(panelTarget);
                CowAppScript.listMode = 1;
                CowAppScript.getCurrentMenu().refreshMenu();
                break;
            case 4:
                CowAppScript.currentFocusLocation.removeAnimalFromLocation(panelTarget);
                CowAppScript.listMode = 1;
                break;
        }
    }
}
