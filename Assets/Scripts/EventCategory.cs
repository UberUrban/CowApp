using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventCategory
{
    private int ID;
    private string categoryName;
    private string description;
    private Image image;

    public int getID()
    {
        return ID;
    }

    public string getName()
    {
        return categoryName;
    }

    public string getDescription()
    {
        return description;
    }
}
