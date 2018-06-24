using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    string[] level1Passwords = {"books","aisle","shelf","password","font","borrow"};
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest"};

    // Game state
    int target;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start () {

        ShowMainMenu();

	}

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the library.");
        Terminal.WriteLine("Press 2 for the police station.");
        Terminal.WriteLine("Press 3 for Nasa.");
        Terminal.WriteLine("Enter your selection:");
    }

    private void RunMainMenu(string input)
    {
        if (input == "007")
        {
            Terminal.WriteLine("Please select a target, Mr. Bond.");
        }
        else if (input == "1")
        {
            target = 1;
            password = level1Passwords[2];
            StartGame();
        }
        else if (input == "2")
        {
            target = 2;
            password = level2Passwords[4];
            StartGame();
        }
        else if (input == "3")
        {
            target = 3;
            password = "d3r4a1g5o9n6";
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid target.");
        }
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Password attempt successful. Welcome.");
        }
        else
        {
            Terminal.WriteLine("Incorrect password entered. Try again.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen target " + target);
        Terminal.WriteLine("Enter the password: ");
    }

}
