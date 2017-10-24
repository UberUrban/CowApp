using UnityEngine;
using System.Collections;
using System;

public class Menu_MainMenu : AppMenu
{
    int menuIDvalue = 0;

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
    public void mmAnimalButton()
    {
        CowAppScript.targetMenu = 1;
        CowAppScript.listMode = 1;
    }

    public void mmLocationButton()
    {
        CowAppScript.targetMenu = 2;
        CowAppScript.listMode = 1;
    }

}
