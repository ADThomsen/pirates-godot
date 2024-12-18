namespace Demo;

public class Demo
{
    public async Task Run()
    {
        // Dit spil starter her
        Random random = new Random();
        int number = random.Next(1, 101);
        Console.WriteLine("Velkommen til Gæt Et Tal!");
        Console.WriteLine("Jeg tænker på et tal mellem 1 og 100. Kan du gætte det?");
        Console.WriteLine("Indtast dit gæt:");
        int guess = 0;
        while (guess != number)
        {
            string input = Console.ReadLine();
            guess = int.Parse(input);
            if (guess < number)
            {
                Console.WriteLine("For lavt! Prøv igen.");
            }
            else if (guess > number)
            {
                Console.WriteLine("For højt! Prøv igen.");
            }
            else
            {
                Console.WriteLine("Tillykke! Du gættede rigtigt!");
            }
        }
    }
}
