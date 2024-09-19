using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Corso
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int IdCalendarioCorso { get; set; }
        public int IdAula { get; set; }
        public Corso(int Id, string Nome, int IdCalendarioCorso, int IdAula) {
            this.Id = Id;   
            this.Nome = Nome;   
            this.IdCalendarioCorso = IdCalendarioCorso;
            this.IdAula = IdAula;
        }
        // Sovrascrivi il metodo ToString() per stampare i dettagli del corso
        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, IdCalendarioCorso: {IdCalendarioCorso}, IdAula: {IdAula}";
        }
    }
}
