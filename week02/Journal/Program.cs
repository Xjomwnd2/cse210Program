using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool isRunning = true;
        while (isRunning)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Write a new entry
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    
                    Console.WriteLine("Your response: ");
                    string response = Console.ReadLine();
                    
                    journal.AddEntry(new Entry(prompt, response, DateTime.Now));
                    Console.WriteLine("Entry added successfully!");
                    break;

                case "2": // Display the journal
                    journal.DisplayEntries();
                    break;

                case "3": // Load journal from file
                    Console.WriteLine("Enter filename to load from: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "4": // Save journal to file
                    Console.WriteLine("Enter filename to save to: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "5": // Exit
                    isRunning = false;
                    Console.WriteLine("Thank you for using the Journal Program!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            
            Console.WriteLine();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Journal Program Menu:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Load journal from file");
        Console.WriteLine("4. Save journal to file");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
    }
}

class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What's something new I learned today?",
            "What's a goal I made progress on today?",
            "What am I grateful for today?",
            "What was the most challenging part of my day?",
            "What did I do today to help someone else?"
        };
    }
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];

    }
}