using UnityEngine;

using System.Collections;



public class SINumber
{
    //se 025199 - 0786 - 3

    string fullNumber;
    string countryCode;
    int farmID;
    int animalID;
    int controlNumber;

    public SINumber(string SI)
    {
        string[] array = SI.Split('-');
        countryCode = array[0];
        farmID = int.Parse(array[1]);
        animalID = int.Parse(array[2]);
        controlNumber = int.Parse(array[3]);
        fullNumber = SI;
    }

    public int getID()
    {
        return animalID;
    }

    public string getSIasString()
    {
        return fullNumber;
    }
}

