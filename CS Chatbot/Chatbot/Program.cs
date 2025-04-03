using System;
using System.Speech.Synthesis;

class Program
{
    static void Main(string[] args)
    {
        
        using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
        {
            synthesizer.SelectVoiceByHints(VoiceGender.Female); 

            
            string greetingMessage = "Hello, my name is Chattie! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.";
            synthesizer.Speak(greetingMessage);
        }

       
        DisplayAsciiArt();

        
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine()?.Trim();

        Console.Write("Please enter your surname: ");
        string userSurname = Console.ReadLine()?.Trim();

       
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userSurname))
        {
            Console.WriteLine("Invalid input. Please restart and enter valid name and surname.");
            return;
        }

        
        DisplayWelcomeMessage(userName, userSurname);

     
        StartChat(userName, userSurname);
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

    static void DisplayWelcomeMessage(string userName, string userSurname)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('*', 60));
        Console.WriteLine($"\nWelcome, {userName} {userSurname}! Let's talk about cybersecurity.");
        Console.WriteLine(new string('*', 60));
        Console.ResetColor();
    }

    static void StartChat(string userName, string userSurname)
    {
        while (true)
        {
            Console.Write("\nYou can ask me about phishing, password safety, safe browsing, or general inquiries. What would you like to know? ");
            string userInput = Console.ReadLine()?.ToLower()?.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Could you clarify for me? I'd love to make sure I fully understand.");
                continue;
            }

            
            if (userInput.Contains("how are you"))
            {
                Respond("I'm just a program, but I'm here to help you stay safe online! How are you?");
            }
            else if (userInput.Contains("how can you assist"))  
            {
                Respond("You can ask me about cybersecurity topics such as password safety, phishing, pharming, and safe browsing.");
            }
            else if (userInput.Contains("what can I ask about"))
            {
                Respond("You can ask me anything related to password safety, phishing, pharming, cybersecurity, and safe browsing practices.");
            }
            
            else if (userInput.Contains("phishing"))
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
            else if (userInput.Contains("pharming"))
            {
                Respond("Pharming is a type of cyber attack that redirects users from legitimate websites to fraudulent ones, even if the correct web address is entered.");
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
        Console.WriteLine($"\n{message}"); 
        Console.ResetColor();
    }
}
