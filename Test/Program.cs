using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            c.Nom = "Gates";
            c.Prenom = "Bill";
            c.Ville = "Seatle";

            ClientDAO database = new ClientDAO();

            database.Insert(c);


            foreach (Client cli in database.List())
            {
                Console.WriteLine(cli.Nom);
            }


            Console.WriteLine();

        }
    }
}
