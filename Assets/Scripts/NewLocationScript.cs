using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class NewLocationScript : AppMenu
{
    public InputField nameInputField;

    int menuIDvalue = 6;

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
    }

    public override void exitMenu()
    {
        menuContainer.SetActive(false);
    }

    public override void refreshMenu()
    {
        //Nothing right now
    }


    //------------------------ Buttons ------------------------
    public void submitButton()
    {
        bool allowCreation = true;
        foreach (Location loc in Farm.getLocations())
        {
            if (loc.getName() == nameInputField.text)
            {
                allowCreation = false;
            }
        }
        if(allowCreation)
        {
            Location l = new Location(nameInputField.text);
            Farm.addLocation(l);
            CowAppScript.changeMenu(2);
        }     
    }

    public void backButton()
    {
        CowAppScript.changeMenu(2);
    }
}
