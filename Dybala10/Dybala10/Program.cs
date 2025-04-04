using System;
using System.IO;
using System.Media;
using System.Threading;


class CybersecurityChatbot
{
    static void Main()
    {
        Console.Title = "Cybersecurity Awareness Chatbot";

        // Play Voice Greeting
        PlayVoiceGreeting();


        // Display ASCII Art
        DisplayAsciiArt();

        // Welcome Message
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nWelcome to the Cybersecurity Awareness Chatbot!");
        Console.ResetColor();

        // Get User Name
        Console.Write("\nPlease enter your name: ");
        string userName = Console.ReadLine()?.Trim();

        while (string.IsNullOrEmpty(userName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Name cannot be empty.");
            Console.ResetColor();
            Console.Write("\nPlease enter your name: ");
            userName = Console.ReadLine()?.Trim();
        }

        Console.WriteLine($"\nHello, {userName}! I'm here to help you stay safe online.\n");

        // Chatbot Conversation Loop
        StartChat();
    }

    static void PlayVoiceGreeting()
    {
        string sound = Path.Combine(Directory.GetCurrentDirectory(), "greeting.wav");
        try
        {
            using(SoundPlayer player = new SoundPlayer(sound))
            {
                player.PlaySync(); // Play greeting synchronously
            }
        }

        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error playing voice greeting: " + ex.Message);
            Console.ResetColor();
        }
    }


    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
 _____  ____    ____                        _   
/ ____|| __ )  / ___|  ___  ___ _    _ _ _ (_) |_  _   _  
\___  \|  _ \  \___ \ / _ \/ __| |  | | '_ | | _| |  | | |
 ___)  | |_) |  ___) |  __/ (__| |__| | |  | | |__|  | | | 
|_____/_____/  |____/ \___|\___|\___,_| |  | |\___|\___, | 
                                                   ____| |
                                                   |____/
               
");
        Console.ResetColor();
    }

    static void StartChat()
    {
        while (true)
        {
            Console.Write("\nAsk me a cybersecurity question or type 'exit' to quit: ");
            string userInput = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input cannot be empty. Please ask a question.");
                Console.ResetColor();
                continue;
            }

            if (userInput == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nGoodbye! Stay safe online.");
                Console.ResetColor();
                break;
            }

            // Handle User Queries
            RespondToUser(userInput);
        }
    }

    static void RespondToUser(string userInput)
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        switch (userInput)
        {
            case "how are you?":
                Console.WriteLine("I'm just a bot, but I'm here to help you with cybersecurity!");
                break;

            case "what’s your purpose?":
                Console.WriteLine("I help people stay safe online by providing cybersecurity awareness tips.");
                break;

            case "what can i ask you about?":
                Console.WriteLine("You can ask me about password safety, phishing, and safe browsing.");
                break;

            case "how do i create a strong password?":
                Console.WriteLine("Use a mix of uppercase, lowercase, numbers, and symbols. Avoid common words.");
                break;

            case "how can i spot a phishing email?":
                Console.WriteLine("Look for suspicious sender addresses, grammar errors, and urgent requests for information.");
                break;

            case "how can i browse the internet safely?":
                Console.WriteLine("Keep your software updated, use HTTPS websites, and avoid clicking on unknown links.");
                break;

            default:
                Console.WriteLine("I didn’t quite understand that. Could you rephrase?");
                break;
        }

        Console.ResetColor();
    }
}