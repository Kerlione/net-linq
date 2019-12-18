using LR_8_LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_8_LINQ
{
    public class TestData
    {
        private static Random random = new Random(DateTime.Now.Millisecond);
        public static List<Client> GenerateClients()
        {
            var clients = new List<Client>();

            clients.Add(new Client("Kirils", "Raduncevs", "200297-10339", "kirils.raduncevs@gmail.com", "Riga", "26988939"));
            clients.Add(new Client("Jevgenijs", "Lomashonoks", "121197-10339", "kirils.raduncevs@gmail.com", "Riga", "26988939"));
            clients.Add(new Client("Artems", "Armfelds", "121296-10339", "kirils.raduncevs@gmail.com", "Riga", "26988939"));
            clients.Add(new Client("Artems", "Moskalovs", "031597-10339", "kirils.raduncevs@gmail.com", "Riga", "26988939"));

            return clients;
        }

        public static List<Contract> GenerateContracts(List<Client> clients)
        {
            var contracts = new List<Contract>();
            var contractCount = random.Next(clients.Count*2, clients.Count * 5);
            for (int i = 0; i < contractCount; i++)
            {
                var client = clients[random.Next(0, clients.Count)];
                var contract = new Contract(new DateTime(random.Next(1990, 2015), random.Next(1, 12), random.Next(1, 20)), random.Next(1, 48), client.PersonalIdentifier);
                contracts.Add(contract);
                client.Contracts.Add(contract);
            }
            
            return contracts;
        }
    }
}
