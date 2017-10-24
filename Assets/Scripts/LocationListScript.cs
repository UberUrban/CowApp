using UnityEngine;
using System.Collections;
using System;

public class LocationListScript : AppMenu
{
    [Header("Required Prefabs")]
    public GameObject locationList;
    public GameObject locationTile;

    int menuIDvalue = 2;

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
        foreach (Location l in Farm.getLocations())
        {
            GameObject g = Instantiate(locationTile) as GameObject;
            g.transform.SetParent(locationList.transform, false);
            LocationPanelScript p = g.GetComponent<LocationPanelScript>();
            p.initializePanel(l);
            g.name = ("Panel - " + l.getName());
        }
    }

    public override void exitMenu()
    {
        foreach (Transform child in locationList.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        menuContainer.SetActive(false);
    }

    public override void refreshMenu()
    {
        foreach (Transform child in locationList.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Location l in Farm.getLocations())
        {
            GameObject g = Instantiate(locationTile) as GameObject;
            g.transform.SetParent(locationList.transform, false);
            LocationPanelScript p = g.GetComponent<LocationPanelScript>();
            p.initializePanel(l);
            g.name = ("Panel - " + l.getName());
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

    public void newLocationButton()
    {
        CowAppScript.changeMenu(6);
    }
}
