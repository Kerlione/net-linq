using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_8_LINQ.Entities
{
    public class Contract
    {
        public string ContractNumber { get; set; }
        public DateTime SigningDate { get; set; }
        public int MonthTerms { get; set; }
        public string ClientId { get; set; }

        public Contract()
        {

        }
        public Contract(DateTime signingDate, int term, string clientId)
        {
            ContractNumber = this.GetHashCode().ToString();
            SigningDate = signingDate;
            MonthTerms = term;
            ClientId = clientId;
        }

        public static Contract CreateContract(string clientId)
        {
            var contract = new Contract();
            Console.Write("Number: ");
            contract.ContractNumber = Console.ReadLine();
            Console.Write("Signing Date (dd/MM/YYYY): ");
            contract.SigningDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Term (months): ");
            contract.MonthTerms = int.Parse(Console.ReadLine());
            contract.ClientId = clientId;
            return contract;
        }

        public override string ToString()
        {
            return String.Format("Contract #{0}, signed on {1} for {2} months by {3}", 
                ContractNumber, SigningDate.ToShortDateString(), MonthTerms, ClientId);
        }
    }
}
