using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LocationProfileScript : AppMenu
{
    [Header("Required Prefabs")]
    public GameObject animalsAtLocationList;
    public GameObject animalTile;

    public Text LocationProfileNametag;

    int menuIDvalue = 4;

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
        LocationProfileNametag.text = CowAppScript.currentFocusLocation.getName();

        if(CowAppScript.currentFocusLocation.getAnimalsAtLocation() != null)
        {
            foreach (Animal a in CowAppScript.currentFocusLocation.getAnimalsAtLocation())
            {
                GameObject g = Instantiate(animalTile) as GameObject;
                g.transform.SetParent(animalsAtLocationList.transform, false);
                AnimalPanelScript p = g.GetComponent<AnimalPanelScript>();
                p.initializePanel(a);
                g.name = ("Panel - " + a.getName());
            }
        } 
    }

    public override void exitMenu()
    {
        foreach (Transform child in animalsAtLocationList.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        menuContainer.SetActive(false);
    }

    public override void refreshMenu()
    {
        foreach (Transform child in animalsAtLocationList.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        menuContainer.SetActive(false);

        LocationProfileNametag.text = CowAppScript.currentFocusLocation.getName();

        if (CowAppScript.currentFocusLocation.getAnimalsAtLocation() != null)
        {
            foreach (Animal a in CowAppScript.currentFocusLocation.getAnimalsAtLocation())
            {
                GameObject g = Instantiate(animalTile) as GameObject;
                g.transform.SetParent(animalsAtLocationList.transform, false);
                AnimalPanelScript p = g.GetComponent<AnimalPanelScript>();
                p.initializePanel(a);
                g.name = ("Panel - " + a.getName());
            }
        }
    }



    //------------------------ Buttons ------------------------
    public void removeButton()
    {
        CowAppScript.listMode = 4;
    }

    public void backButton()
    {
        CowAppScript.listMode = 1;
        CowAppScript.changeMenuBack();
    }

    public void addAnimalButton()
    {
        CowAppScript.requestingMenu = 4;
        CowAppScript.listMode = 2;
        CowAppScript.currentAnimalList = CowAppScript.currentFocusLocation.getAnimalsAtLocation();
        CowAppScript.changeMenu(1);
    }

}
