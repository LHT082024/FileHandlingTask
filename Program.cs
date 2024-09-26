namespace filehandling;
using System;
using System.IO;
using System.Text.Json;

class Program
{
    //main method i programmet. 
    static void Main(string[] args)
    {
        try {
            //filstien for person.json
             string filePath = "Person.json";

             List<Person>? people = new List<Person>();
             if(File.Exists(filePath))
             {
                string existingJSON = File.ReadAllText(filePath);
                Console.WriteLine($"Data already exists in person.json {File.ReadAllText(filePath)}");
                if(!string.IsNullOrWhiteSpace(existingJSON))
                {
                     people = JsonSerializer.Deserialize<List<Person>>(existingJSON);
                }
             }

            // console write line skriver koden ut mens linjer som "variabel? navn = Console.Readline();"
            //tar og sier at user input er verdien til variabelen. 
            Console.WriteLine("What is your name?");
            string? name = Console.ReadLine();
            Console.WriteLine("How old are you?");
            string? ageInput = Console.ReadLine();
            int age;

            //hvis int ikke klarer å konvertere stringen ageinput til en int så skriv meldingen "there was error"
            while (!int.TryParse(ageInput, out age))
            {
                Console.WriteLine("there was an error use actual numbers to write your are");
                ageInput = Console.ReadLine();
            }
            Console.WriteLine("what city are you from");
            string? city = Console.ReadLine();

            //lager en variabel utifra klassen "Person"
            var person = new Person
            {
                Name = name,
                Age = age,
                City = city,
            };
            Console.WriteLine($"Your name is {person.Name}\n you are {person.Age} years old\n and you are from {person.City}");

            string json = JsonSerializer.Serialize(person, new JsonSerializerOptions{WriteIndented = true}); 
            File.WriteAllText(filePath, json);

            Console.WriteLine("Data was written on the JSON object");
       }
       catch(IOException exception)
       {
        Console.WriteLine($"an error occoured while attempting to write to file: person.json{exception.Message}");
       }
       catch (Exception exception)
       {
         Console.WriteLine($"{exception.Message}");
       }
    } 
}
