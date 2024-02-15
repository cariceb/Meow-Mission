// using System;
// using System.ComponentModel.DataAnnotations;

// class Game
// {
// 	// Private fields
// 	private Parser parser;
// 	private Room currentRoom;

// 	// Constructor
// 	public Game()
// 	{
// 		parser = new Parser();
// 		CreateRooms();
// 	}

// 	// Initialise the Rooms (and the Items)
// 	private void CreateRooms()
// 	{
// 		// Create the rooms
// 		Room camp = new Room("at the camp");
// 		Room bushes = new Room("in the bushes");
// 		Room river = new Room("by the river");
// 		Room darkForrest = new Room("in a scary dark forrest...");
// 		Room mountain = new Room("at the bottom of the mountain");

// 		// Initialise room exits
// 		camp.AddExit("east", bushes);
// 		camp.AddExit("south", darkForrest);
// 		camp.AddExit("west", river);

// 		bushes.AddExit("west", camp);

// 		river.AddExit("east", camp);

// 		darkForrest.AddExit("north", camp);
// 		darkForrest.AddExit("east", mountain);

// 		mountain.AddExit("west", darkForrest);

// 		// Create your Items here
		
// 		// And add them to the Rooms
// 		// ...

// 		// Start game outside
// 		currentRoom = camp;
// 	}


// 	//  Main play routine. Loops until end of play.
// 	public void Play()
// 	{
// 		PrintWelcome();

// 		// Enter the main command loop. Here we repeatedly read commands and
// 		// execute them until the player wants to quit.
// 		bool finished = false;
// 		while (!finished)
// 		{
// 			Command command = parser.GetCommand();
// 			finished = ProcessCommand(command);
// 		}
// 		Console.WriteLine("Thank you for playing!");
// 		Console.WriteLine("Press [Enter] to continue.");
// 		Console.ReadLine();
// 	}

// 	// Print out the opening message for the player.
// 	private void PrintWelcome()
// 	{
// 		Console.WriteLine();
// 		Console.WriteLine("Welcome to Pussy grabber!");
// 		Console.WriteLine("Pussy grabber is a new, incredibly fun adventure game.");
// 		Console.WriteLine("Type 'help' if you need help.");
// 		Console.WriteLine();
// 		Console.WriteLine(currentRoom.GetLongDescription());
// 	}

// 	// Given a command, process (that is: execute) the command.
// 	// If this command ends the game, it returns true.
// 	// Otherwise false is returned.
// 	private bool ProcessCommand(Command command)
// 	{
// 		bool wantToQuit = false;

// 		if(command.IsUnknown())
// 		{
// 			Console.WriteLine("I don't know what you mean...");
// 			return wantToQuit; // false
// 		}

// 		switch (command.CommandWord)
// 		{
// 			case "help":
// 				PrintHelp();
// 				break;
// 			case "go":
// 				GoRoom(command);
// 				break;
// 			case "quit":
// 				wantToQuit = true;
// 				break;
// 			case "look":
// 				Look();
// 				break;	
// 		}

// 		return wantToQuit;
// 	}

	
// 	// ######################################
// 	// implementations of user commands:
// 	// ######################################
	
// 	public void Look(){
// 		Console.WriteLine("pookie bear uwu");
// 	}

// 	// Print out some help information.
// 	// Here we print the mission and a list of the command words.
// 	private void PrintHelp()
// 	{
// 		Console.WriteLine("You are lost. You are alone.");
// 		Console.WriteLine("You wander around at the university.");
// 		Console.WriteLine();
// 		// let the parser print the commands
// 		parser.PrintValidCommands();
// 	}

// 	// Try to go to one direction. If there is an exit, enter the new
// 	// room, otherwise print an error message.
// 	private void GoRoom(Command command)
// 	{
// 		if(!command.HasSecondWord())
// 		{
// 			// if there is no second word, we don't know where to go...
// 			Console.WriteLine("Go where?");
// 			return;
// 		}

// 		string direction = command.SecondWord;

// 		// Try to go to the next room.
// 		Room nextRoom = currentRoom.GetExit(direction);
// 		if (nextRoom == null)
// 		{
// 			Console.WriteLine("There is no door to "+direction+"!");
// 			return;
// 		}

// 		currentRoom = nextRoom;
// 		Console.WriteLine(currentRoom.GetLongDescription());
// 	}
// }








using System;

class Game
{
    private int playerHealth; // Added: player health variable
    private const int maxHealth = 100; // Added: maximum health constant
    private Parser parser;
    private Room currentRoom;

    public Game()
    {
        parser = new Parser();
        CreateRooms();
        playerHealth = maxHealth; // Added: initialize player health
    }

    private void CreateRooms()
    {
        // Create the rooms
        Room camp = new Room("at the camp");
        Room bushes = new Room("in the bushes");
        Room river = new Room("by the river");
        Room darkForrest = new Room("in a scary dark forrest...");
        Room mountain = new Room("at the bottom of the mountain");

        // Initialise room exits
        camp.AddExit("east", bushes);
        camp.AddExit("south", darkForrest);
        camp.AddExit("west", river);

        bushes.AddExit("west", camp);

        river.AddExit("east", camp);

        darkForrest.AddExit("north", camp);
        darkForrest.AddExit("east", mountain);

        mountain.AddExit("west", darkForrest);

        // Start game outside
        currentRoom = camp;
    }


    public void Play()
    {
        PrintWelcome();

        bool finished = false;
        while (!finished)
        {
            Command command = parser.GetCommand();
            finished = ProcessCommand(command);
        }
        Console.WriteLine("Thank you for playing!");
        Console.WriteLine("Press [Enter] to continue.");
        Console.ReadLine();
    }

    private void PrintWelcome()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to Pussy grabber!");
        Console.WriteLine("There is a sick cat wandering around here... Go find and save the cat!");
        Console.WriteLine("Type 'help' if you need help.");
        Console.WriteLine();
        Console.WriteLine(currentRoom.GetLongDescription());
        Console.WriteLine($"Your health: {playerHealth}/{maxHealth}"); // Added: display player health
    }

    private bool ProcessCommand(Command command)
    {
        bool wantToQuit = false;

        if(command.IsUnknown())
        {
            Console.WriteLine("I don't know what you mean...");
            return wantToQuit;
        }

        switch (command.CommandWord)
        {
            case "help":
                PrintHelp();
                break;
            case "go":
                GoRoom(command);
                break;
            case "quit":
                wantToQuit = true;
                break;
            case "look":
                Look();
                break;  
        }

        return wantToQuit;
    }

    public void Look(){
        Console.WriteLine("pookie bear uwu");
    }

    private void PrintHelp()
    {
        Console.WriteLine("You are lost. You are alone.");
        Console.WriteLine("You wander around at the university.");
        Console.WriteLine();
        parser.PrintValidCommands();
    }

    private void GoRoom(Command command)
    {
        if(!command.HasSecondWord())
        {
            Console.WriteLine("Go where?");
            return;
        }

        string direction = command.SecondWord;

        Room nextRoom = currentRoom.GetExit(direction);
        if (nextRoom == null)
        {
            Console.WriteLine("There is no door to "+direction+"!");
            return;
        }

        currentRoom = nextRoom;
        playerHealth -= 10; // Added: decrease health when entering a new room
        if(playerHealth <= 0)
        {
            Console.WriteLine("You died!");
            Environment.Exit(0); // Exit the game
        }
        
        Console.WriteLine(currentRoom.GetLongDescription());
        Console.WriteLine($"Your health: {playerHealth}/{maxHealth}"); // Added: display player health
    }
}