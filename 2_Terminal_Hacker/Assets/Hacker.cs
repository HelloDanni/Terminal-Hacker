using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {

        ShowMainMenu();

	}

    void ShowMainMenu()
    {
        var greeting = "Hello User.";

        Terminal.ClearScreen();
        
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the library.");
        Terminal.WriteLine("Press 2 for the police station.");
        Terminal.WriteLine("Press 3 for Nasa.");
        Terminal.WriteLine("Enter your selection:");
    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
