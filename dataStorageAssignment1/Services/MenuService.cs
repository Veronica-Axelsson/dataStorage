using dataStorage.Models;

namespace dataStorage.Services
{
    internal class MenuService
    {
        public async Task CreateNewErrandAsync()              //Skapa ny kontakt
        {
            var errands = new Errands();

            Console.WriteLine("Skapa ett nytt ärende. \n");

            Console.Write("Förnamn: ");
            errands.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            errands.LastName = Console.ReadLine() ?? "";

            Console.Write("E-postadress: ");
            errands.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer: ");
            errands.CustomerPhoneNr = Console.ReadLine() ?? "";

            Console.Write("Beskrivning av ärendet: ");
            errands.CustomerDescription = Console.ReadLine() ?? "";

            //Creates automatic --------------------
            //Time errand created
            errands.ErrandTimeCreated = DateTime.Now;

            //The status of the errand
            errands.Status = "Ej påbörjad";

            errands.EmployeeComment = "";

            //Save errand to database
            await CustomerService.SaveAsync(errands);
        }

        public async Task CreateNewCommentAsync()              //Skapa ny kontakt
        {
            var errands = new Errands();

            // // Söka efter ett ärende
            Console.Write("Skriv ärendets id-nummer: ");
            var answer = Console.ReadLine();

            if (answer != null)
            {
                answer = answer.ToLower();

                if (answer == errands.Id.ToString())
                {
                    //Kommentera ärendet
                    Console.Write("Kommentera ärendet: ");
                    errands.EmployeeComment = Console.ReadLine() ?? "";
                }

                else
                {
                    Console.WriteLine("Fel id-nummer");
                } 
            }
           
            //Creates automatic --------------------
            //Time errand created
            errands.TimeEmployeeComment = DateTime.Now;

            //save errand to database
            await CustomerService.SaveAsync(errands);
        }

        public async Task ListAllErrandsAsync()
        {
            ////get all errands from database
            var errands = await CustomerService.GetAllAsync();

            Console.WriteLine("Visar alla ärenden. \n");

            if (errands.Any())
            {

                foreach (Errands _errand in errands)
                {
                    Console.WriteLine($"Kundnummer: {_errand.Id}");
                    Console.WriteLine($"Namn: {_errand.FirstName} {_errand.LastName}");
                    Console.WriteLine($"E-postadress: {_errand.Email}");

                    if (_errand.CustomerPhoneNr == null)
                    {
                        Console.WriteLine("Telefonnummer hittades inte");
                    }
                    else
                        Console.WriteLine($"Telefonnummer: {_errand.CustomerPhoneNr}");

                    Console.WriteLine($"Ärende datum: {_errand.ErrandTimeCreated}");
                    Console.WriteLine($"Beskrivning av ärendet: : {_errand.CustomerDescription}");

                    if (_errand.Status == null)
                    {
                        Console.WriteLine("Ärende status hittades inte");
                    }
                    else
                        Console.WriteLine($"Ärende status: {_errand.Status}");


                    if (!string.IsNullOrEmpty(_errand.EmployeeComment))
                    {
                        Console.WriteLine($"Kommentar datum: {_errand.TimeEmployeeComment}");
                        Console.WriteLine($"Kommentar: {_errand.EmployeeComment}");
                    }

                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga ärenden finns i databasen.");
                Console.WriteLine("");
            }
        }            //Visa alla ärenden

        public async Task ListSpecificErrandAsync()
        {
            Console.Write("Visa en specifik ärende. Ange ärendets id: ");
            var tempId = Console.ReadLine();

            if (!string.IsNullOrEmpty(tempId))
            {
                //get specific customer+address from database
                var _errand = await CustomerService.GetAsync(tempId);

                if (_errand != null)
                {
                    Console.WriteLine($"Kundnummer: {_errand.Id}");
                    Console.WriteLine($"Namn: {_errand.FirstName} {_errand.LastName}");
                    Console.WriteLine($"E-postadress: {_errand.Email}");
                    Console.WriteLine($"Telefonnummer: {_errand.CustomerPhoneNr}");
                    Console.WriteLine($"Ärende datum: {_errand.ErrandTimeCreated}");
                    Console.WriteLine($"Beskrivning av ärendet: : {_errand.CustomerDescription}");
                    Console.WriteLine($"Ärende status: {_errand.Status}");

                    if (!string.IsNullOrEmpty(_errand.EmployeeComment))
                    {
                        Console.WriteLine($"Kommentar datum: {_errand.TimeEmployeeComment}");
                        Console.WriteLine($"Kommentar: {_errand.EmployeeComment}");
                    }

                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ingen ärende med den angivna id {tempId} hittades.");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine($"Ingen ärende id angiven.");
                Console.WriteLine("");
            }

        }        // Visa en specifik kontakt

        public async Task UpdateStatusAsync()
        {
            Console.Write("Uppdatera ett ärende status. Skriv ärendets id: ");
            var _id = Console.ReadLine();

            if (!string.IsNullOrEmpty(_id))
            {
                var _errands = await CustomerService.GetAsync(_id);
                if (_errands != null)
                {
                    Console.WriteLine($"Uppdaterar ärende: {_errands.Id}  \n");

                    Console.WriteLine("Skriv något av följande: Ej påbörjad, Pågående, Avslutad. Annars tryck enter. \n");
                    _errands.Status = Console.ReadLine() ?? null!;

                    //update specific errand to database
                    await CustomerService.UpdateAsync(_errands);
                } else
                {
                    Console.WriteLine($"Hittade inte någon kund med angivna id.");
                    Console.WriteLine("");
                }

            } else
            {
                Console.WriteLine($"Ingen id angiven.");
                Console.WriteLine("");
            }

        }      // Uppdatera ett ärende

    }
}
