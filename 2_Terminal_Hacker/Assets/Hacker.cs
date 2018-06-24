
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    string[] target1Passwords = {"books","aisle","shelf","font","borrow"};
    string[] target2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest"};
    string[] target3Passwords = { "spacestation", "darkmatter", "neilarmstrong", "blackhole", "moonlanding" };

    // Game state
    int target;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start () {

        ShowMainMenu();

	}

    private void Update()
    {

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
        bool isValidTargetNumber = (input == "1" || input == "2" || input == "3");
        if (isValidTargetNumber)
        {
            target = int.Parse(input);
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a target, Mr. Bond.");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid target.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();

        switch (target)
        {

            case 1:
                password = target1Passwords[Random.Range(0, target1Passwords.Length)];
                break;
            case 2:

                password = target2Passwords[Random.Range(0, target2Passwords.Length)];
                break;
            case 3:
                password = target3Passwords[Random.Range(0, target3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid target");
                break;
        }

        Terminal.WriteLine("Enter the password: ");
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



}
