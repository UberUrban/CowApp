using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//This represents a single animal on a farm

public class Animal
{
    
    SINumber fullID;
    int id;
    string name;
    int gender; //1 = female 2= male
    DateTime birth;
    int father;
    int mother;
    Location currentLocation;

    List<Animal> children = new List<Animal>();

    public Animal(SINumber newID, string newName)
    {
        fullID = newID;
        id = fullID.getID();
        name = newName;
    }

    

    public void setFather(int newFather)
    {
        father = newFather;
    }

    public void setMother(int newMother)
    {
        mother = newMother;
    }

    public void setLocation(Location newLocation)
    {
        currentLocation = newLocation;
    }

    public void addChild(Animal c)
    {
        children.Add(c);
    }

    public void removeChild(Animal c)
    {
        children.Remove(c);
    }

    public string getName()
    {
        return name;
    }

    public int getID()
    {
        return id;
    }

    public string getFullID()
    {
        return fullID.getSIasString();
    }

    public Location getLocation()
    {
        return currentLocation;
    }

    public void moveAnimalTo(Location l)
    {
        currentLocation = l;
    }

    public List<Animal> getChildren()
    {
        return children;
        /*
        List<Animal> aList = new List<Animal>();
        foreach(int i in children)
        {
            aList.Add(Farm.getAnimalByID(i));
        }
        return aList;
        */
    }

    public Animal getMother()
    {
        return Farm.getAnimalByID(mother);
    }

    public Animal getFather()
    {
        return Farm.getAnimalByID(father);
    }
}
