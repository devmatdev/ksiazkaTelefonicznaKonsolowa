using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PHONEBOOK
{
     class PhoneBook
    {
       public List<Contact> ContactList { get; set; } = new List<Contact>();
       public void AddContact(Contact contact)
        {
            ContactList.Add(contact);

            
        }

        public void ShowContacts()
        {
            foreach(Contact con in ContactList)
                ShowContactDetails(con);
        }
        public void ShowContactDetails(Contact contact)
        {
            Console.WriteLine($"Contact name: {contact.Name} ; phone number: {contact.Number}");
        }
        public void DeleteContact(string name)
        {
            ContactList.Remove(ContactList.FirstOrDefault(x => x.Name == name));
        }
        public void SortContacts()
        {
            ContactList = ContactList.OrderBy(x => x.Name).ToList();
        }
        public void FindContact(string name)
        {
            ShowContactDetails(ContactList.FirstOrDefault(x => x.Name == name));
        }
    }
}
