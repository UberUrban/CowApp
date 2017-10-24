using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalListScript : AppMenu
{
    [Header("Required Prefabs")]
    public GameObject animalList;
    public GameObject animalTile;

    private List<AnimalPanelScript> animalPanels = new List<AnimalPanelScript>();

    int menuIDvalue = 1;

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
        foreach (Animal a in Farm.getAnimals())
        {
            GameObject g = Instantiate(animalTile) as GameObject;
            g.transform.SetParent(animalList.transform, false);
            AnimalPanelScript p = g.GetComponent<AnimalPanelScript>();
            p.initializePanel(a);
            g.name = ("Panel - " + a.getID());
            animalPanels.Add(p);
        }
    }

    public override void exitMenu()
    {
        foreach(Transform child in animalList.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        menuContainer.SetActive(false);
    }

    public override void refreshMenu()
    {
        foreach (Transform child in animalList.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Animal a in Farm.getAnimals())
        {
            GameObject g = Instantiate(animalTile) as GameObject;
            g.transform.SetParent(animalList.transform, false);
            AnimalPanelScript p = g.GetComponent<AnimalPanelScript>();
            p.initializePanel(a);
            g.name = ("Panel - " + a.getID());
        }
    }


    //------------------------ Buttons ------------------------
    public void removeButton()
    {
        CowAppScript.listMode = 3;
    }

    public void backButton()
    {
        CowAppScript.listMode = 1;
        CowAppScript.changeMenu(0);
    }

    public void newAnimalButton()
    {
        CowAppScript.targetMenu = 5;
    }
 
}
