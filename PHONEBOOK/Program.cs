using System;
using Newtonsoft.Json;
using System.IO;
namespace PHONEBOOK
{
    class Program
    {
        static void Main(string[] args)
        {

            var phonebook = new PhoneBook();
            
            if (!File.Exists("programData.json"))
            {

            }
            else
              phonebook = JsonConvert.DeserializeObject<PhoneBook>(File.ReadAllText("programData.json"));
         
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to PhoneBook App");
                Console.WriteLine("Select option by press number: ");
                Console.WriteLine("1 - Show all contacts");
                Console.WriteLine("2 - Add contact");
                Console.WriteLine("3 - Find contact");
                Console.WriteLine("4 - Delete contact");
                Console.WriteLine("5 - Exit");
                string userInput = Console.ReadLine();
                string name=default;
                switch (userInput)
                {
                    case "1":
                        {
                            phonebook.ShowContacts();
                            Console.WriteLine("To continue press ENTER");
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter the name: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter the number: ");
                            var number = Console.ReadLine();
                            var con = new Contact(name, number);
                            phonebook.AddContact(con);
                            phonebook.SortContacts();
                            var phoneBookSerialized = JsonConvert.SerializeObject(phonebook);
                            File.WriteAllText("programData.json", phoneBookSerialized);
                            break;
                        }
                    case "3":
                        {
                            Console.Write("Enter the name of contact you looking for: ");
                            name = Console.ReadLine();
                            phonebook.FindContact(name);
                            Console.WriteLine("To continue press ENTER");
                            Console.ReadLine();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter the name of the contact to be deleted: ");
                            name = Console.ReadLine();
                            phonebook.DeleteContact(name);
                            var phoneBookSerialized = JsonConvert.SerializeObject(phonebook);
                            File.WriteAllText("programData.json", phoneBookSerialized);
                            Console.WriteLine("Contact deleted");
                            Console.WriteLine("To continue press ENTER");
                            break;
                        }
                    case "5":
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong choice, try again");
                            Console.WriteLine("To continue press ENTER");
                            Console.ReadLine();
                            break;
                        }
                }
            }
        }
    }
}
