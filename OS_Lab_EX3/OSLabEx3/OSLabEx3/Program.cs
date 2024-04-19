using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace OSLabEx3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Console.WriteLine("1. Set information");
            Console.WriteLine("2. Get information");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Please Enter number of persons you want to add");
                    int count = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        Person person = new Person();
                        Console.WriteLine("Enter First Name :");
                        person.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name :");
                        person.LastName = Console.ReadLine();
                        Console.WriteLine("Enter Phone number :");
                        person.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Enter Date of birth (yyyy-MM-dd):");
                        DateTime.TryParse(Console.ReadLine(), out person.DateOfBirth);
                        Console.WriteLine("Enter Age :");
                        person.Age =Convert.ToInt32(Console.ReadLine());
                        persons.Add(person);
                    }
                    string json = JsonConvert.SerializeObject(persons, Formatting.Indented);
                    File.WriteAllText("persons.json", json);
                    Console.WriteLine("Person information stored in persons.json");
                    break;

                case 2:
                    try
                    {
                        string jsonText = File.ReadAllText("persons.json");
                        persons = JsonConvert.DeserializeObject<List<Person>>(jsonText);
                        if (persons != null)
                        {
                            persons.AddRange(persons);
                            Console.WriteLine("Person information loaded from persons.json");
                            for (int i = 0; i < persons.Count; i++)
                            {
                                Console.WriteLine(persons[i].FirstName + "   "  + persons[i].LastName + "   " + persons[i].PhoneNumber + "   " + persons[i].DateOfBirth + "   " + persons[i].Age + "   " );
                            }
                        }
                        else
                        {
                            Console.WriteLine("No person information found in persons.json");
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File persons.json not found");
                    }
                    break;

            }
        }
    }
}
