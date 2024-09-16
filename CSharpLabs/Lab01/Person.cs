using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
	internal class Person
	{
		// Costruttore
		internal Person()
        {
				
        }
        internal Person(string Name, string LastName, DateOnly BirthDate) 
		{
			this.Name = Name;
			this.LastName = LastName;
			this.BirthDate = BirthDate;
		}

		internal string Name { get; set; } // Property
		internal string LastName { get; set; } // Property
		internal string CF { get; set; } // Property
		internal string Email { get; set; } // Property
		internal string Address { get; set; } // Property
		internal DateOnly BirthDate { get; set; } // Private field

		// Definizione metodo
		internal void DisplayBasicInfo()
		{
			Console.WriteLine($"Nome: {this.Name} - Cognome: {this.LastName} - Data di nascita: {this.BirthDate}");
		}
	}
}
