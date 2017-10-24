using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This represents a farm or livestock to be tracked and managed by the application

public static class Farm
{
    static string FarmName;
    static int id;
    static HashSet<Animal> animals = new HashSet<Animal>();
    static HashSet<Location> locations = new HashSet<Location>();


    public static void addAnimal(Animal a)
    {
        animals.Add(a);
        CowAppScript.currentAnimalList.Add(a);
    }

    public static void addLocation(Location l)
    {
        locations.Add(l);
    }

    public static Animal getAnimalByID(int animalID)
    {
        foreach(Animal a in animals)
        {
            if(a.getID() == animalID)
            {
                return a;
            }
        }
        return null;
    }

    public static Location getLocationByName(string locationName)
    {
        foreach(Location l in locations)
        {
            if(l.getName() == locationName)
            {
                return l;
            }
        }
        return null;
    }

    public static void removeAnimal(Animal a)
    {
        animals.Remove(a);
        foreach(Location l in locations)
        {
            l.removeAnimalFromLocation(a);
        }
    }

    public static void removeAnimalFromAllLocations(Animal a)
    {
        foreach (Location l in locations)
        {
            l.removeAnimalFromLocation(a);
        }
    }

    public static HashSet<Animal> getAnimals()
    {
        return animals;
    }

    public static HashSet<Location> getLocations()
    {
        return locations;
    }
}


