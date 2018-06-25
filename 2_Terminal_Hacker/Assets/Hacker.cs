
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    string menuHint = "Type menu at any time to return.";
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

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What system would you like to hack?");
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
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a target, Mr. Bond.");
            Terminal.WriteLine(menuHint);
        }
        else
        {
            Terminal.WriteLine("Please choose a valid target.");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter the password. Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
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
                Terminal.WriteLine(menuHint);
                break;
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
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Incorrect password entered. Try again.");
            Terminal.WriteLine(menuHint);
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowTargetReward();
    }

    void ShowTargetReward()
    {
        switch (target)
        {
            case 1:
                Terminal.WriteLine("Access granted.");
                Terminal.WriteLine("Welcome to the public library system.");
                Terminal.WriteLine(menuHint);
                Terminal.WriteLine(@"
     __________
    /         /
   /         //
  /         //
 / ________//
((________|/
"               
                );
                break;
            case 2:
                Terminal.WriteLine("Access granted.");
                Terminal.WriteLine("Welcome to the county jail security system.");
                Terminal.WriteLine(menuHint);
                Terminal.WriteLine(@"
 ___
/0  \________
\___/-=' = ''
"
                );
                break;
            case 3:
                Terminal.WriteLine("Access Granted. We have lift off...");
                Terminal.WriteLine(menuHint);
                Terminal.WriteLine(@"

 _  ___   ___ _  ____  ____  _
|  '_   \/  _' |/  __)/  __'  |
|  | |  |  (_|  \__  \  (  |  |
|_ | |_ |\__,__|_____)\____,__|

Welcome to NASA's internal system. 
You may type menu at any time.
"
                );
                break;
        }
        
    }
}
