using dataStorage.Services;

var menu = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("Fastighet AB ärendehanteringssystem");
    Console.WriteLine("1. Skapa en nytt ärende");
    Console.WriteLine("2. Visa alla ärenden");
    Console.WriteLine("3. Visa en specifik ärende");
    Console.WriteLine("4. Uppdatera status på ett ärende");
    Console.WriteLine("5. Kommentera ett specifikt ärende");
    Console.WriteLine("6. Avsluta programmet");
    Console.Write("Välj ett av följande alternativ (1-6: ");

    switch (Console.ReadLine())
    {
        case "1":
            //Skapa nytt ärende
            Console.Clear();
            await menu.CreateNewErrandAsync();
            break;

        case "2":
            //Visa alla ärenden
            Console.Clear();
            await menu.ListAllErrandsAsync();
            break;

        case "3":
            // se ett specifikt ärende.
            Console.Clear();
            await menu.ListSpecificErrandAsync();
            break;

        case "4":
            // Uppdatera/byta status på ett ärende
            Console.Clear();
            await menu.UpdateStatusAsync();
            break;

        case "5":
            // Kommentera ett specifikt ärende
            Console.Clear();
            await menu.CreateNewCommentAsync();
            break;

        case "6":
            // Programmet avslutas
            Console.Clear();
            Console.WriteLine("Programmet avslutas");
            System.Environment.Exit(6);
            break;
    }

    Console.WriteLine("\nTryck på valfri knapp för att fortsätta...");
    Console.ReadKey();
}