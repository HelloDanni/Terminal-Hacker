using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game state
    int level;

    // Use this for initialization
    void Start () {

        ShowMainMenu();

	}

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the library.");
        Terminal.WriteLine("Press 2 for the police station.");
        Terminal.WriteLine("Press 3 for Nasa.");
        Terminal.WriteLine("Enter your selection:");
    }


    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMainMenu();
        }
        else if(input == "007")
        {
            Terminal.WriteLine("Please select a target, Mr. Bond.");
        }
        else if(input == "1")
        {
            level = 1;
            StartGame();
        }
        else if(input == "2")
        {
            level = 2;
            StartGame();
        }
        else if(input == "3")
        {
            level = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid target.");
        }
    }

    void StartGame()
    {
        Terminal.WriteLine("You have chosen target " + level);
    }

}
