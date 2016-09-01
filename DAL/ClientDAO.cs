using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClientDAO
    {
        public void Insert(Client cli)
        {
            SqlConnection connect = new SqlConnection("server=.; database=hotel; integrated security=true");
            connect.Open();
            SqlCommand requete = new SqlCommand("insert into client(cli_nom, cli_prenom, cli_ville) values(@nom, @prenom,@ville)", connect);
            requete.Parameters.AddWithValue("@nom", cli.Nom);
            requete.Parameters.AddWithValue("@prenom", cli.Prenom);
            requete.Parameters.AddWithValue("@ville", cli.Ville);
            requete.ExecuteNonQuery();            SqlCommand requete2 = new SqlCommand("select max(cli_id) from client", connect);
            int id = (int)requete2.ExecuteScalar();
            cli.ID = id;            connect.Close();
        }

        public List<Client> List()
        {
            List<Client> resultat = new List<Client>();
            SqlConnection connect = new SqlConnection("server=.; database=hotel; integrated security=true");
            connect.Open();
            SqlCommand requete = new SqlCommand("select * from client", connect);
           
            SqlDataReader lecture = requete.ExecuteReader();
            while (lecture.Read())
            {
                Client c = new Client();
                c.ID = Convert.ToInt32(lecture["cli_id"]);
                c.Nom = Convert.ToString(lecture["cli_nom"]);
                c.Prenom = Convert.ToString(lecture["cli_prenom"]);
                c.Ville = Convert.ToString(lecture["cli_ville"]);
                resultat.Add(c);
            }
            lecture.Close();
            connect.Close();
            return resultat;
        }
    }
}
