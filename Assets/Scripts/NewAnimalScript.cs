using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NewAnimalScript : AppMenu
{
    public InputField IDInputField;
    public InputField NameInputField;

    public Button selectMotherButton;
    public Button selectFatherButton;
    public Button selectLocationButton;

    public Animal selectedMother = null;
    public Animal selectedFather = null;
    public Location selectedLocation = null;

    //Request function flags
    private bool isRequestingMother = false;
    private bool isRequestingFather = false;
    private bool isRequestingLocation = false;

    int menuIDvalue = 5;

    public override int menuID
    {
        get
        {
            return menuIDvalue;
        }
    }

    void Update()
    {
        checkRequests();
    }

    public override void enterMenu()
    {
        menuContainer.SetActive(true);
        if(selectedMother != null)
        {
            selectMotherButton.GetComponentInChildren<Text>().text = selectedMother.getID() + " - " + selectedMother.getName();
        }
        if (selectedFather != null)
        {
            selectFatherButton.GetComponentInChildren<Text>().text = selectedFather.getID() + " - " + selectedFather.getName();
        }
        if (selectedLocation != null)
        {
            selectLocationButton.GetComponentInChildren<Text>().text = selectedLocation.getName();
        }
    }

    public override void exitMenu()
    {
        menuContainer.SetActive(false);
    }

    public override void refreshMenu()
    {
        if (selectedMother != null)
        {
            selectMotherButton.GetComponentInChildren<Text>().text = selectedMother.getID() + " - " + selectedMother.getName();
        }
        if (selectedFather != null)
        {
            selectFatherButton.GetComponentInChildren<Text>().text = selectedFather.getID() + " - " + selectedFather.getName();
        }
        if (selectedLocation != null)
        {
            selectLocationButton.GetComponentInChildren<Text>().text = selectedLocation.getName();
        }
    }

    //------------------------ Object Requests ----------------

    private void checkRequests()
    {
        if(CowAppScript.requestedAnimal != null && isRequestingMother)
        {
            resolveRequestMother();       
        }
        if(CowAppScript.requestedAnimal != null && isRequestingFather)
        {
            resolveRequestFather();
        }
        if(CowAppScript.requestedLocation != null && isRequestingLocation)
        {
            resolveRequestLocation();
        }
    }

    private void startRequestMother()
    {
        isRequestingMother = true;
        CowAppScript.startRequestAnimal(menuIDvalue);
    }

    private void resolveRequestMother()
    {
        isRequestingMother = false;
        CowAppScript.changeMenu(menuIDvalue);
        Animal a = CowAppScript.getRequestedAnimal();
        selectedMother = a;
        CowAppScript.requestedAnimal = null;
        refreshMenu();
    }

    private void startRequestFather()
    {
        isRequestingFather = true;
        CowAppScript.startRequestAnimal(menuIDvalue);
    }

    private void resolveRequestFather()
    {
        isRequestingFather = false;
        CowAppScript.changeMenu(menuIDvalue);
        Animal a = CowAppScript.getRequestedAnimal();
        selectedFather = a;
        CowAppScript.requestedAnimal = null;
        refreshMenu();
    }

    private void startRequestLocation()
    {
        isRequestingLocation = true;
        CowAppScript.startRequestLocation(menuIDvalue);
    }

    private void resolveRequestLocation()
    {
        isRequestingLocation = false;
        CowAppScript.changeMenu(menuIDvalue);
        Location l = CowAppScript.getRequestedLocation();
        selectedLocation = l;
        CowAppScript.requestedLocation = null;
        refreshMenu();
    }


    //------------------------ Buttons ------------------------
    public void submit()
    {
        bool allowCreation = true;
        foreach(Animal animal in Farm.getAnimals())
        {
            if(animal.getFullID() == IDInputField.text)
            {
                allowCreation = false;
            }
        }
        if(allowCreation)
        {
            Animal a = new Animal(new SINumber(IDInputField.text), NameInputField.text);
            if (selectedMother != null)
            {
                a.setMother(selectedMother.getID());
                selectedMother.addChild(a);
            }
            if(selectedFather != null)
            {
                a.setFather(selectedFather.getID());
                selectedFather.addChild(a);
            }
            if(selectedLocation != null)
            {
                a.setLocation(selectedLocation);
            }
            Farm.addAnimal(a);
            CowAppScript.changeMenu(1);
        }     
    }

    public void onMotherButton()
    {
        startRequestMother();
    }

    public void onFatherButton()
    {
        startRequestFather();
    }

    public void onLocationButton()
    {
        startRequestLocation();
    }

    public void backButton()
    {
        CowAppScript.changeMenu(1);
    }

    //------------ Input checking ----

    public void onSIinputField()
    {
        if(!CowAppScript.confirmSIFormat(IDInputField.text))
        {
            CowAppScript.activateTextPrompt("Var god mata in SI-Nummret på formatet: SE-123456-1234-1");
            IDInputField.text = "";
        }
    }
}
