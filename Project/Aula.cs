using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Aula
    {
        internal string Nome { get; set; }
        internal int Id { get; set; }
        internal int IdLearningCenter { get; set; }

        public Aula(string Nome, int Id, int IdLearningCenter)
        {
            this.Nome = Nome;
            this.Id = Id;
            this.IdLearningCenter = IdLearningCenter;
        }

        // Sovrascrivi il metodo ToString() per stampare i dettagli dell'aula
        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome},  IdLearningCenter: {IdLearningCenter}";
        }

    }
}
