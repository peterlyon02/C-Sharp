using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GestioneCorsi
    {
        public string connectionString = "Data Source=PIETRO\\SQLEXPRESS;Initial Catalog=GestioneCorsi;Integrated Security=True";

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
        
    }


 
}
