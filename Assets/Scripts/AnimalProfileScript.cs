using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AnimalProfileScript : AppMenu
{
    public GameObject familyTab;
    public GameObject animalEventTab;
    public GameObject notesTab;
    public GameObject changesTab;

    public GameObject animalTile;

    //Base
    public Text animalIDText;
    public Text animalNameText;
    public Text animalLocationText;

    //FamilyTab
    public Text fatherText;
    public Text motherText;
    public GameObject childPanel;

    int menuIDvalue = 3;

    public override int menuID
    {
        get
        {
            return menuIDvalue;
        }
    }

    public override void enterMenu()
    {
        menuContainer.SetActive(true);
        animalIDText.text = CowAppScript.currentFocusAnimal.getID().ToString();
        animalNameText.text = CowAppScript.currentFocusAnimal.getName().ToString();
        Location l = CowAppScript.currentFocusAnimal.getLocation();
        if(l != null)
        {
            animalLocationText.text = l.getName();
        }
        else
        {
            animalLocationText.text = "Oplacerad";
        }
        enterFamilyTab();
    }

    public override void exitMenu()
    {
        menuContainer.SetActive(false);
    }

    public override void refreshMenu()
    {
        menuContainer.SetActive(true);
        animalIDText.text = CowAppScript.currentFocusAnimal.getID().ToString();
        animalNameText.text = CowAppScript.currentFocusAnimal.getName().ToString();
        Location l = CowAppScript.currentFocusAnimal.getLocation();
        if (l != null)
        {
            animalLocationText.text = l.getName();

        }
        else
        {
            animalLocationText.text = "Oplacerad";
        }
    }

    private void enterFamilyTab()
    {
        familyTab.SetActive(true);

        if(CowAppScript.currentFocusAnimal.getMother() != null)
        {
            motherText.text = CowAppScript.currentFocusAnimal.getMother().getName();
        }
        if (CowAppScript.currentFocusAnimal.getFather() != null)
        {
            fatherText.text = CowAppScript.currentFocusAnimal.getFather().getName();
        }

        foreach(Animal a in CowAppScript.currentFocusAnimal.getChildren())
        {
            GameObject g = Instantiate(animalTile) as GameObject;
            g.transform.SetParent(childPanel.transform, false);
            AnimalPanelScript p = g.GetComponent<AnimalPanelScript>();
            p.initializePanel(a);
            g.name = ("Panel - " + a.getID());
        }
    }

    //------------------------ Buttons ------------------------
    public void backButton()
    {
        CowAppScript.changeMenuBack();
    }

    public void familyTabButton()
    {
        
    }

    public void animalEventsTabButton()
    {

    }

    public void notesTabButton()
    {

    }

    public void changesTabButton()
    {

    }
}
