using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia
{
    internal class RepositoryAgentiDbADO : IRepositoryAgenti
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool Aggiungi(Agente item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("insert into Agente values(@Nome, @Cognome, @CodiceFiscale, @AreaGeografica, @AnnoDiInizioAttivita)", connection);

                cmd.Parameters.AddWithValue("@Nome", item.Nome);
                cmd.Parameters.AddWithValue("@Cognome", item.Cognome);
                cmd.Parameters.AddWithValue("@CodiceFiscale", item.CodiceFiscale);
                cmd.Parameters.AddWithValue("@AreaGeografica", item.AreaGeografica);
                cmd.Parameters.AddWithValue("@AnnoDiInizioAttivita", item.AnnoDiInizioAttivita);

                int numRighe = cmd.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }

        public List<Agente> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Agente", connection);

                SqlDataReader tabelleRisultato = cmd.ExecuteReader();

                List<Agente> agenti = new List<Agente>();
                while (tabelleRisultato.Read())
                {
                    var nome = (string)tabelleRisultato["Nome"];
                    var cognome = (string)tabelleRisultato["Cognome"];
                    var codiceFiscale = (string)tabelleRisultato["CodiceFiscale"];
                    var areaGeografica = (string)tabelleRisultato["AreaGeografica"];
                    var annoDiInizioAttivita = (int)tabelleRisultato["AnnoDiInizioAttivita"];

                    Agente agente = new Agente(nome, cognome, codiceFiscale, areaGeografica, annoDiInizioAttivita);
                    agenti.Add(agente);
                }
                connection.Close();
                return agenti;

            }
        }        

        public List<Agente> GetByAnniDiServizio(int anniDiServizio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Agente where AnnoDiInizioAttivita <= @Anno", connection);

                int anno = 2022 - anniDiServizio;
                cmd.Parameters.AddWithValue("@Anno", anno);
                SqlDataReader tabelleRisultato = cmd.ExecuteReader();

                List<Agente> agenti = new List<Agente>();
                while (tabelleRisultato.Read())
                {
                    var nome = (string)tabelleRisultato["Nome"];
                    var cognome = (string)tabelleRisultato["Cognome"];
                    var codiceFiscale = (string)tabelleRisultato["CodiceFiscale"];
                    var areaGeografica = (string)tabelleRisultato["AreaGeografica"];
                    var annoDiInizioAttivita = (int)tabelleRisultato["AnnoDiInizioAttivita"];

                    Agente agente = new Agente(nome, cognome, codiceFiscale, areaGeografica, annoDiInizioAttivita);
                    agenti.Add(agente);
                }
                connection.Close();
                return agenti;

            }
        }

        public List<Agente> GetByArea(string area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Agente where AreaGeografica = @AreaGeografica", connection);

                cmd.Parameters.AddWithValue("@AreaGeografica", area);
                SqlDataReader tabelleRisultato = cmd.ExecuteReader();

                List<Agente> agenti = new List<Agente>();
                while (tabelleRisultato.Read())
                {
                    var nome = (string)tabelleRisultato["Nome"];
                    var cognome = (string)tabelleRisultato["Cognome"];
                    var codiceFiscale = (string)tabelleRisultato["CodiceFiscale"];
                    var areaGeografica = (string)tabelleRisultato["AreaGeografica"];
                    var annoDiInizioAttivita = (int)tabelleRisultato["AnnoDiInizioAttivita"];

                    Agente agente = new Agente(nome, cognome, codiceFiscale, areaGeografica, annoDiInizioAttivita);
                    agenti.Add(agente);
                }
                connection.Close();
                return agenti;

            }
        }

        public Agente GetByCodiceFiscale(string codiceFiscale)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("select * from Agente where CodiceFiscale = @CodiceFiscale", connection);

                
                cmd.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);

                SqlDataReader reader = cmd.ExecuteReader();

                Agente agente = null;

                while (reader.Read())
                {
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    var codiceFisc = (string)reader["CodiceFiscale"];
                    var areaGeografica = (string)reader["AreaGeografica"];
                    var annoDiInizioAttivita = (int)reader["AnnoDiInizioAttivita"];

                    agente = new Agente(nome, cognome, codiceFisc, areaGeografica, annoDiInizioAttivita);
                }
                connection.Close();
                return agente;
            }
        }
    }
}
