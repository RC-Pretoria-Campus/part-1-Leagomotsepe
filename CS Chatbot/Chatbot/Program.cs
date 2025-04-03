using System;
using System.Speech.Synthesis;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        synthesizer.SelectVoiceByHints(VoiceGender.Female); 
       
        string greetingMessage = "Hello, my name is Chattie! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.";
        synthesizer.Speak(greetingMessage);

        
        DisplayAsciiArt();

        
        Console.Write("Please enter your name and surname: ");
        string userName = Console.ReadLine();

       
        Console.WriteLine($"\nWelcome, {userName}! Let's talk about cybersecurity.");

      
        StartChat(userName);
    }

    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan; 
        Console.WriteLine(new string('*', 60));
        Console.WriteLine(@"
                    .--.
                   |o_o |
                   |:_/ |
                  //   \ \
                 (|     | )
                /'\_   _/`\
                \___)=(___/
        Chattie the CS Bot - Cybersecurity Awareness
        ");
        Console.WriteLine("               *🚀  Lock & Robot  🚀*                ");
        Console.WriteLine(new string('*', 60));
        Console.ResetColor(); 
    }

    static void StartChat(string userName)
    {
        while (true)
        {
            Console.Write("\nYou can ask me about the following topics phishing, password safety, or safe browsing. What would you like to know? ");
            string userInput = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Could you clarify for me? I'd love to make sure I fully understand.");
                continue;
            }

            if (userInput.Contains("phishing"))
            {
                Respond("Phishing is a method used by cybercriminals to trick individuals into providing sensitive information, often through fake emails or websites that appear legitimate.");
            }
            else if (userInput.Contains("password safety"))
            {
                Respond("To keep your passwords safe, use a mix of letters, numbers, and special characters. Avoid using the same password for multiple accounts.");
            }
            else if (userInput.Contains("safe browsing"))
            {
                Respond("Always check URLs before clicking on links, avoid downloading unknown files, and use secure connections (look for 'https').");
            }
            else if (userInput.Equals("exit"))
            {
                Console.WriteLine("Thank you for using Chattie! Stay safe online!");
                break;
            }
            else
            {
                Respond("I'm sorry, I didn't understand that. Please ask about phishing, password safety, or safe browsing.");
            }
        }
    }

    static void Respond(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green; 
        Console.WriteLine($"\nChattie: {message}");
        Console.ResetColor();

        
        Thread.Sleep(500); 
    }
}