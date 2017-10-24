using UnityEngine;
using System.Collections;
using System;

public class AnimalEvent
{
    private int eventID;
    private EventCategory category;
    private DateTime date;
    private string description;

    public int getID()
    {
        return eventID;
    }

    public string getDateAsString()
    {
        return date.ToString();
    }

    public DateTime getDate()
    {
        return date;
    }

    public string getDescription()
    {
        return description;
    }
}
