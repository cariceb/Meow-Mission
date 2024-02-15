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

        Item kattenvoer = new Item(2, "Een zak kattenvoer.");
        bushes.AddItem(kattenvoer);

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


public class Item
{
    public int Weight { get; }
    public string Kattenvoer { get; }

    public Item(int weight, string description)
    {
        Weight = weight;
        Kattenvoer = description;
    }
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
        Console.WriteLine("Welcome to Meow Mission!");
        Console.WriteLine("There is a sick cat wandering around here... Go find food and medicine to save the cat!");
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