using Project;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class GestioneCorsi
    {
        public string connectionString = "Data Source=PCNIEVO104;Initial Catalog=GestioneCorsi;Integrated Security=True";
        //Metodo per cercare un utente per il nome
        public Utente GetUtenteByNome(string Nome)
        {
            Utente utente = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, Nome, Cognome, CF, IdTipoUtente FROM T_Utente WHERE Nome = @Nome";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", Nome);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Controlla se ciascun valore è DBNull prima di convertirlo
                                int Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : Convert.ToInt32(reader["Id"]);
                                string nome = reader.IsDBNull(reader.GetOrdinal("Nome")) ? string.Empty : reader["Nome"].ToString();
                                string cognome = reader.IsDBNull(reader.GetOrdinal("Cognome")) ? string.Empty : reader["Cognome"].ToString();
                                string cf = reader.IsDBNull(reader.GetOrdinal("CF")) ? string.Empty : reader["CF"].ToString();
                                int idTipoUtente = reader.IsDBNull(reader.GetOrdinal("IdTipoUtente")) ? 0 : Convert.ToInt32(reader["IdTipoUtente"]);

                                //Creiamo l'oggetto utente
                                utente = new Utente(Id, nome, cognome, cf, idTipoUtente);
                            }

                        }

                    }
                }
            }
            return utente;
        }

        public List<Utente> GetUtentiByTipoUtente(string tipoUtente)
        {
            List<Utente> utenti = new List<Utente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Query che unisce T_Utente e T_TipoUtente per ottenere utenti in base al tipo
                string sql = @"
                SELECT U.Id, U.Nome, U.Cognome, U.CF, U.IdTipoUtente
                FROM T_Utente U
                JOIN T_TipoUtente T ON U.IdTipoUtente = T.Id
                WHERE T.Titolo = @TipoUtente";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Aggiunge il parametro per il tipo di utente
                    cmd.Parameters.AddWithValue("@TipoUtente", tipoUtente);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Creiamo e aggiungiamo ogni Utente alla lista
                                Utente utente = new Utente
                                (
                                    Convert.ToInt32(reader["Id"]),
                                    reader["Nome"].ToString(),
                                    reader["Cognome"].ToString(),
                                    reader["CF"].ToString(),
                                    Convert.ToInt32(reader["IdTipoUtente"])
                               );

                                utenti.Add(utente);
                            }
                        }
                    }
                }
            }

            return utenti;
        }

        public Corso GetCorsoByName(string name)
        {

            Corso corso = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, Nome, IdCalendarioCorso, IdAula FROM T_Corso WHERE Nome = @Nome";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", name);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Controlla se ciascun valore è DBNull prima di convertirloù
                                int Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : Convert.ToInt32(reader["Id"]);
                                string Nome = reader.IsDBNull(reader.GetOrdinal("Nome")) ? string.Empty : reader["Nome"].ToString();
                                int IdCalendarioCorso = reader.IsDBNull(reader.GetOrdinal("IdCalendarioCorso")) ? 0 : Convert.ToInt32(reader["IdCalendarioCorso"]);
                                int IdAula = reader.IsDBNull(reader.GetOrdinal("IdAula")) ? 0 : Convert.ToInt32(reader["IdAula"]);

                                //Creiamo l'oggetto corso
                                corso = new Corso(
                                   Id, Nome, IdCalendarioCorso, IdAula
                                    );
                            }

                        }

                    }
                }
            }
            return corso;


        }

        public Corso GetCorsoByTecnologia(string tecnologia)
        {

            Corso corso = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                             SELECT C.Id, C.Nome, C.IdCalendarioCorso, C.IdAula 
                             FROM T_Corso C 
                             JOIN  T_Tecnologia T ON C.Id  = T.IdCorso
                             WHERE T.Tipo =@tecnologia";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tecnologia", tecnologia);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Controlla se ciascun valore è DBNull prima di convertirloù
                                int Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : Convert.ToInt32(reader["Id"]);
                                string Nome = reader.IsDBNull(reader.GetOrdinal("Nome")) ? string.Empty : reader["Nome"].ToString();
                                int IdCalendarioCorso = reader.IsDBNull(reader.GetOrdinal("IdCalendarioCorso")) ? 0 : Convert.ToInt32(reader["IdCalendarioCorso"]);
                                int IdAula = reader.IsDBNull(reader.GetOrdinal("IdAula")) ? 0 : Convert.ToInt32(reader["IdAula"]);

                                //Creiamo l'oggetto corso
                                corso = new Corso(
                                   Id, Nome, IdCalendarioCorso, IdAula
                                    );
                            }

                        }

                    }
                }
            }
            return corso;


        }

        public Corso GetCorsoByProvider(string provider)
        {

            Corso corso = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                             SELECT C.Id, C.Nome, C.IdCalendarioCorso, C.IdAula, P.Nome AS NomeProvider
                             FROM T_Corso AS C JOIN T_Tecnologia AS T ON C.Id= T.IdCorso
                             JOIN T_Provider AS P ON T.Id=P.IdTecnologia
                             WHERE T.Tipo =@provider";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@provider", provider);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Controlla se ciascun valore è DBNull prima di convertirloù
                                int Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : Convert.ToInt32(reader["Id"]);
                                string Nome = reader.IsDBNull(reader.GetOrdinal("Nome")) ? string.Empty : reader["Nome"].ToString();
                                int IdCalendarioCorso = reader.IsDBNull(reader.GetOrdinal("IdCalendarioCorso")) ? 0 : Convert.ToInt32(reader["IdCalendarioCorso"]);
                                int IdAula = reader.IsDBNull(reader.GetOrdinal("IdAula")) ? 0 : Convert.ToInt32(reader["IdAula"]);

                                //Creiamo l'oggetto corso
                                corso = new Corso(
                                   Id, Nome, IdCalendarioCorso, IdAula
                                    );
                            }

                        }

                    }
                }
            }
            return corso;


        }





    }
}