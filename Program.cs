
namespace Phonebook
{
    class Program
    {
        static readonly Dictionary<string, string> contacts = new();

        static bool UserEscaped = false;

        static public void AddContact(string contactName, string contactNumber)
        {
            if (contactName.Length <= 3 || contactName.Length >= 20 || contactNumber.Length != 9)
            {
                Console.WriteLine("Name should be between 3 to 20 characters long and number exact 9 digits long");
                return;
            }
            if (!contacts.ContainsKey(contactName))
            {
                contacts[contactName] = contactNumber;
            }
            else
            {
                Console.WriteLine($"Contact with name {contactName} is already in phonebook");
            }
        }

        static public void ShowContactByNumber(string contactNumber)
        {
            string? contactName = null;

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

        static public void ShowContactByName(string contactName)
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

        static public void ShowAllContacts()
        {
            if (contacts.Count <= 0)
            {
                Console.WriteLine("There is no contacts in phonebook...");
                return;
            }

            foreach (var contactName in contacts.Keys)
            {
                Console.WriteLine($"Name: {contactName}, Number: {contacts[contactName]}");
            }
        }

        static public void PhoneBookInterface()
        {
            Console.WriteLine("\n*** Phonebook ***");

            Console.WriteLine("Type 'add-contact' to add contact to phonebook");
            Console.WriteLine("Type 'show-all-contacts' to show all contacts");
            Console.WriteLine("Type 'show-contact-by-name' to show contact by name");
            Console.WriteLine("Type 'show-contact-by-number' to show contact by number");
            Console.WriteLine("Type 'x' to quit\n");

            var actionType = Console.ReadLine();

            if (actionType == "add-contact")
            {
                Console.WriteLine("Name: ");
                var contactName = Console.ReadLine();
                Console.WriteLine("Number: ");
                var contactNumber = Console.ReadLine();
                if (contactNumber != null && contactName != null) AddContact(contactName, contactNumber);
            }
            else if (actionType == "show-all-contacts") ShowAllContacts();
            else if (actionType == "show-contact-by-name")
            {
                Console.WriteLine("Name: ");
                var contactName = Console.ReadLine();
                if (contactName != null) ShowContactByName(contactName);
            }
            else if (actionType == "show-contact-by-number")
            {
                Console.WriteLine("Number: ");
                var contactNumber = Console.ReadLine();
                if (contactNumber != null) ShowContactByNumber(contactNumber);
            }
            else if (actionType == "x") UserEscaped = true;
            else
            {
                Console.WriteLine("Invalid action...");
            }
        }

        static void Main()
        {
            do { PhoneBookInterface(); } while (!UserEscaped);
        }
    }
}
