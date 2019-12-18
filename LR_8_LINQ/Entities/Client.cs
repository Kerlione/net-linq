using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_8_LINQ.Entities
{
    public class Client
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PersonalIdentifier { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Contract> Contracts { get; set; }

        public string GetContracts()
        {
            string result = "";
            foreach (var contract in Contracts)
            {
                result += contract.ToString() + "\n";
            }
            return result;
        }
        public Client()
        {
            Contracts = new List<Contract>();
        }
        public Client(string firstName, string lastName, string id, string email, string address, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalIdentifier = id;
            Email = email;
            Address = address;
            PhoneNumber = phone;
            Contracts = new List<Contract>();
        }

        public static Client AddNewClient()
        {
            var client = new Client();
            Console.Write("First Name: ");
            client.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            client.LastName = Console.ReadLine();
            Console.Write("Personal Identifier: ");
            client.PersonalIdentifier = Console.ReadLine();
            Console.Write("Email: ");
            client.Email = Console.ReadLine();
            Console.Write("Address: ");
            client.Address = Console.ReadLine();
            Console.Write("PhoneNumber: ");
            client.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Contract count");
            int contractCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < contractCount; i++)
            {
                Console.WriteLine("Contract #" + i + 1);
                client.Contracts.Add(Contract.CreateContract(client.PersonalIdentifier));
            }
            return client;
        }

        public override string ToString()
        {
            return String.Format("Client:\nFirst Name:{0}\nLast Name:{1}\nID:{2}\nEmail:{3}\nAddress:{4}\nPhone Number:{5}\n" + GetContracts(), 
                FirstName, LastName, PersonalIdentifier, Email, Address, PhoneNumber);
        }
    }
}
