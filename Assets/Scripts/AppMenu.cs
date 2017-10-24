using UnityEngine;
using System.Collections;

public abstract class AppMenu : MonoBehaviour
{
    public abstract int menuID
    {
        get;
    }
    string menuDescription;

    public GameObject menuContainer;

    public int getMenuID()
    {
        return menuID;
    }

    public abstract void enterMenu();

    public abstract void exitMenu();

    public abstract void refreshMenu();
}
