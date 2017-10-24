using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using UnityEngine.UI;

//This script is a bridge between the farm and the application

/*
Menu Listing:
0 = Main Menu
1 = Animal List
2 = Location List
3 = Animal Profile
4 = Location Profile
5 = New Animal Window
6 = New Location Window

List Modes:
0 = Do Nothing
1 = Open Profile
2 = Select and Return
3 = Remove Object
4 = Remove From Subgroup
*/

public class CowAppScript : MonoBehaviour
{
    private static List<AppMenu> menues = new List<AppMenu>();

    public GameObject mainMenu;
    public GameObject animalList;
    public GameObject locationList;
    public GameObject animalProfile;
    public GameObject locationProfile;
    public GameObject newAnimalWindow;
    public GameObject newLocationWindow;

    public GameObject textPrompt;
    public Text textPromptText;

    //Menu Management
    public static int currentMenu = 0;
    public static int targetMenu = 0;
    public static int previousMenu = 0;
    public static Animal currentFocusAnimal = null;
    public static Location currentFocusLocation = null;
    public static HashSet<Animal> currentAnimalList = new HashSet<Animal>();
    public static HashSet<Location> currentLocationList = new HashSet<Location>();

    public static int requestingMenu = 0;

    public static int listMode = 1;

    //Request Variables
    public static Animal requestedAnimal;
    public static List<Animal> requestedAnimals;
    public static Location requestedLocation;
    public static List<Location> requestedLocations;

    //Save and load
    string animalFileName;
    string locationFileName;

    //SINumber Management

    static string SIPattern = @"([A-Z]{2})[-](\d{6})[-](\d{4})[-]\d";
    static Regex r = new Regex(SIPattern);

    void Start ()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        menues.Add(mainMenu.GetComponent<Menu_MainMenu>());
        menues.Add(animalList.GetComponent<AnimalListScript>());
        menues.Add(locationList.GetComponent<LocationListScript>());
        menues.Add(animalProfile.GetComponent<AnimalProfileScript>());
        menues.Add(locationProfile.GetComponent<LocationProfileScript>());
        menues.Add(newAnimalWindow.GetComponent<NewAnimalScript>());
        menues.Add(newLocationWindow.GetComponent<NewLocationScript>());


        /*
        Farm.addAnimal(new Animal(123, "Beda"));
        Farm.addAnimal(new Animal(456, "Orsa"));
        Farm.addAnimal(new Animal(789, "Marina"));

        Farm.addLocation(new Location("Knutssons"));

        Farm.getLocationByName("Knutssons").addAnimalToLocation(Farm.getAnimalByID(123));
        */


        animalFileName = Application.persistentDataPath + "/animalData.txt";
        locationFileName = Application.persistentDataPath + "/locationData.txt";

        //animalFileName = "animalData.txt";
        //locationFileName = "locationData.txt";

        loadFarm();

        Debug.Log("SITEST: " + confirmSIFormat("SE-444444-4444-4"));
    }

	void Update ()
    {
        menuManagement();
	}

    void menuManagement()
    {
        if(currentMenu != targetMenu)
        {
            saveFarm();
            menues[currentMenu].exitMenu();
            menues[targetMenu].enterMenu();
            currentMenu = targetMenu;
        }
    }

    void loadFarm()
    {
        if(File.Exists(animalFileName))
        {
            string loadStr = "";
            loadStr = File.ReadAllText(animalFileName);
            if(loadStr != "")
            {
                string[] substring = loadStr.Split('#');
                foreach (string s in substring)
                {
                    if (s != "")
                    {
                        string[] subsubstring = s.Split(';');
                        print(subsubstring[0]);
                        print(subsubstring[1]);
                        Farm.addAnimal(new Animal(new SINumber(substring[0]), subsubstring[1]));
                    }
                }
            }     
        }

        if (File.Exists(locationFileName))
        {
            string loadStr = "";
            loadStr = File.ReadAllText(locationFileName);
            string[] substring = loadStr.Split('#');
            if(loadStr != "")
            {
                foreach (string s in substring)
                {
                    if(s != "")
                    {
                        string[] subsubstring = s.Split(';');

                        Location l = new Location(subsubstring[0]);
                        for (int i = 1; i < subsubstring.Length-1; i++)
                        {
                            l.addAnimalToLocation(Farm.getAnimalByID(int.Parse(subsubstring[i])));
                        }
                        Farm.addLocation(l);
                    }                
                }
            }  
        }
    }

    void saveFarm()
    {
        if(!File.Exists(animalFileName))
        {
            File.Create(animalFileName);
        }

        if (!File.Exists(locationFileName))
        {
            File.Create(locationFileName);
        }

        string saveStr = "";
        foreach(Animal a in Farm.getAnimals())
        {
            saveStr += (a.getID() + ";" + a.getName() + "#");
        }
        File.WriteAllText(animalFileName, saveStr);
        saveStr = "";
        foreach(Location l in Farm.getLocations())
        {
            saveStr += (l.getName() + ";");
            foreach(Animal a in l.getAnimalsAtLocation())
            {
                saveStr += (a.getID() + ";");
            }
            saveStr += "#";
        }
        File.WriteAllText(locationFileName, saveStr);
    }

    //------------------ Public Functions ----------------

    public static void changeMenu(int newMenu)
    {
        previousMenu = currentMenu;
        targetMenu = newMenu;
    }

    public static void changeMenuBack()
    {
        targetMenu = previousMenu;
    }

    public static AppMenu getCurrentMenu()
    {
        return menues[currentMenu];
    }

    public static bool confirmSIFormat(string SIToTest)
    {
        Match m = r.Match(SIToTest);
        bool b = m.Success;
        return b;
    }

    //------------------- Text Prompt Window --------------


    public static void activateTextPrompt(string promptText)
    {
        textPromptText.text = promptText;
        textPrompt.SetActive(true);

    }

    public static void onTextPromptButton()
    {
        textPrompt.SetActive(false);
    }

    //------------------- Request Functions ---------------

    public static void startRequestAnimal(int rM)
    {
        requestingMenu = rM;
        requestedAnimal = null;
        changeMenu(1);
        listMode = 2;
    }

    public static Animal getRequestedAnimal()
    {
        return requestedAnimal;
    }

    public static void startRequestAnimals()
    {

    }

    public static List<Animal> getRequestedAnimals()
    {
        return requestedAnimals;
    }

    public static void startRequestLocation(int rM)
    {
        requestingMenu = rM;
        requestedLocation = null;
        changeMenu(2);
        listMode = 2;
    }

    public static Location getRequestedLocation()
    {
        return requestedLocation;
    }

    public void startRequestLocations()
    {

    }

    public List<Location> getRequestedLocations()
    {
        return requestedLocations;
    }
}