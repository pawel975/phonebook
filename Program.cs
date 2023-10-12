
namespace Phonebook
{
    class Program
    {
        static Dictionary<string, string> contacts = new Dictionary<string, string>();

        static public void AddContact(string contactName, string contactNumber)
        {
            if (!contacts.ContainsKey(contactName))
            {
                contacts[contactName] = contactNumber;
            }
            else
            {
                Console.WriteLine($"Contact with name {contactName} is already in phonebook");
            }
        }

        static public void showContactByNumber(string contactNumber)
        {
            string contactName = null;

            foreach (var name in contacts.Keys)
            {
                if (contacts[name] == contactNumber)
                {
                    contactName = name;
                    break;
                }
            }

            if (contactName != null)
            {
                Console.WriteLine($"Name: {contactName}, Number: {contacts[contactName]}");
            }
            else
            {
                Console.WriteLine($"There is no contact with name: {contactName}");
            }
        }

        static public void showContactByName(string contactName)
        {
            if (contacts.ContainsKey(contactName))
            {
                Console.WriteLine($"Name: {contactName}, Number: {contacts[contactName]}");
            }
            else
            {
                Console.WriteLine($"There is no contact with name: {contactName}");
            }
        }

        static public void showAllContacts()
        {
            foreach (var contactName in contacts.Keys)
            {
                Console.WriteLine($"Name: {contactName}, Number: {contacts[contactName]}");
            }
        }

        static void Main()
        {
            Console.WriteLine("*** Phonebook ***");

            Console.WriteLine("Type 'add-contact' to add contact to phonebook");
            Console.WriteLine("Type 'show-all-contacts' to show all contacts");
            Console.WriteLine("Type 'show-contact-by-name' to show contact by name");
            Console.WriteLine("Type 'show-contact-by-number' to show contact by number");

            var actionType = Console.ReadLine();

            if (actionType == "add-contact")
            {
                Console.WriteLine("Name: ");
                var contactName = Console.ReadLine();
                Console.WriteLine("Number: ");
                var contactNumber = Console.ReadLine();
                if (contactNumber != null && contactName != null) AddContact(contactName, contactNumber);
            }
            else if (actionType == "show-all-contacts") showAllContacts();
            else if (actionType == "show-contact-by-name")
            {
                Console.WriteLine("Name: ");
                var contactName = Console.ReadLine();
                if (contactName != null) showContactByName(contactName);
            }
            else if (actionType == "show-contact-by-number")
            {
                Console.WriteLine("Number: ");
                var contactNumber = Console.ReadLine();
                if (contactNumber != null) showContactByNumber(contactNumber);
            }
            else
            {
                Console.WriteLine("Invalid action...");
            }




        }
    }
}
}