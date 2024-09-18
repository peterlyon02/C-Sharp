using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Utente
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? CF { get; set; }
        public int? IdTipoUtente { get; set; }



        public Utente(int Id, string Nome, string Cognome, string CF, int? IdTipoUtente)
        {
            this.Id = Id;
            this.Nome= Nome;  
            this.Cognome= Cognome;
            this.CF = CF;
            this.IdTipoUtente = IdTipoUtente;
        }

        // Sovrascrivi il metodo ToString() per stampare i dettagli dell'utente
        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Cognome: {Cognome}, CF: {CF}, IdTipoUtente: {IdTipoUtente}";
        }
    }
        
}
