using LR_8_LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_8_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var clients = TestData.GenerateClients();
            var contracts = TestData.GenerateContracts(clients);
            int input = 0;
            do
            {
                Console.WriteLine("Current client count: " + clients.Count + " Contract count: " + contracts.Count);
                PrintMenu();
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            PrintClients(clients);
                            break;
                        }
                    case 2:
                        {
                            var client = Client.AddNewClient();
                            clients.Add(client);
                            contracts.AddRange(client.Contracts);
                            break;
                        }
                    case 3:
                        {
                            OrderClients(clients);
                            break;
                        }
                    case 4:
                        {
                            ShowLongTermContracts(clients, contracts);
                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                }
            } while (input != 0);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static void PrintClients(List<Client> clients)
        {
            Console.WriteLine("############################# Current clients #############################");
            clients.ForEach(client => Console.WriteLine(client.ToString()));
        }

        static void OrderClients(List<Client> clients)
        {
            Console.WriteLine("############################# Ordering clients #############################");
            clients.OrderBy(client => client.LastName).ToList().
                ForEach(client => Console.WriteLine(client.ToString()));
        }

        static void ShowLongTermContracts(List<Client> clients, List<Contract> contracts, int minTerm = 12)
        {
            Console.WriteLine("############################# Long term contracts #############################");
            Console.WriteLine("Printing the data with the term more than {0} months", minTerm);
            var result = clients.Join(contracts, client => client.PersonalIdentifier, contract => contract.ClientId, (client, contract) => new
            {
                LastName = client.LastName,
                ContractNumber = contract.ContractNumber,
                ContractTerm = contract.MonthTerms
            }).Where(entry => entry.ContractTerm > minTerm);

            result.OrderBy(report => report.LastName).ToList().ForEach(entry => Console.WriteLine("Last Name: " + entry.LastName + ", Contract ID: " + entry.ContractNumber + ", For: " + entry.ContractTerm));

        }

        static void PrintMenu()
        {
            Console.WriteLine("1. Print clients");
            Console.WriteLine("2. Add client and contract");
            Console.WriteLine("3. Order by last name");
            Console.WriteLine("4. Print long term clients");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
        }
    }
}
