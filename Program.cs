
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

            Console.WriteLine("1 - to add contact to phonebook");
            Console.WriteLine("2 - to show all contacts");
            Console.WriteLine("3 - to show contact by name");
            Console.WriteLine("4 - to show contact by number");
            Console.WriteLine("Type 'x' to quit\n");

            var actionType = Console.ReadLine();

            switch (actionType)
            {
                case "1":
                    Console.WriteLine("Name: ");
                    var contactName = Console.ReadLine();
                    Console.WriteLine("Number: ");
                    var contactNumber = Console.ReadLine();
                    if (contactNumber != null && contactName != null) AddContact(contactName, contactNumber);
                    break;
                case "2":
                    ShowAllContacts();
                    break;
                case "3":
                    Console.WriteLine("Name: ");
                    var contactNameToSearch = Console.ReadLine();
                    if (contactNameToSearch != null) ShowContactByName(contactNameToSearch);
                    break;
                case "4":

                    Console.WriteLine("Number: ");
                    var contactNumberToSearch = Console.ReadLine();
                    if (contactNumberToSearch != null) ShowContactByNumber(contactNumberToSearch);
                    break;
                case "x":
                    UserEscaped = true;
                    break;
                default:
                    Console.WriteLine("Invalid action...");
                    break;

            }
        }
        static void Main()
        {
            do { PhoneBookInterface(); } while (!UserEscaped);
        }
    }

}
