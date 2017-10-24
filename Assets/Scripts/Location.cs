using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This class represents a location in wich animals can be kept

public class Location
{
    string name;
    HashSet<Animal> animalsAtLocation = new HashSet<Animal>();

    public Location(string n)
    {
        name = n;
    }

    public HashSet<Animal> getAnimalsAtLocation()
    {
        return animalsAtLocation;
    }

    public void addAnimalToLocation(Animal a)
    {
        Farm.removeAnimalFromAllLocations(a);
        animalsAtLocation.Add(a);
        a.moveAnimalTo(this);
    }

    public void removeAnimalFromLocation(Animal a)
    {
        animalsAtLocation.Remove(a);
    }

    public string getName()
    {
        return name;
    }
   
}
