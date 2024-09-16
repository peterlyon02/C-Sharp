using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
	internal class Person
	{
		protected DateOnly birthDate { get; set; } // Private field		

		// Costruttore
		internal Person()
		{

		}
		internal Person(string Name, string LastName, DateOnly BirthDate) 
		{
			this.Name = Name;
			this.LastName = LastName;
			this.birthDate = BirthDate;
		}

		internal string Name { get; set; } // Property
		internal string LastName { get; set; } // Property
		internal string CF { get; set; } // Property
		internal string Email { get; set; } // Property
		internal string Address { get; set; } // Property

		internal int Age
		{
			get
			{
				int age = DateTime.Now.Year - birthDate.Year;
				DateTime birthday = new DateTime(DateTime.Now.Year, birthDate.Month, birthDate.Day);
				if (DateTime.Now < birthday)
					age--;
				return age;
			}
		}

		// Definizione metodo
		internal virtual void DisplayBasicInfo()
		{
			Console.WriteLine($"Nome: {this.Name} - Cognome: {this.LastName} - Data di nascita: {this.birthDate}");
		}
		// Overloading metodo
		/// <summary>
		/// Stampa sulla console Nome, cognome e data di nascita con prefisso
		/// </summary>
		/// <param name="prefix">Prefisso del messaggio mostrato</param>
		internal virtual void DisplayBasicInfo(string prefix)
		{
			Console.WriteLine($"{prefix}Nome: {this.Name} - Cognome: {this.LastName} - Data di nascita: {this.birthDate}");
		}
		// Overloading metodo
		/// <summary>
		/// Stampa sulla console Nome, cognome e data di nascita con prefisso e postfisso
		/// </summary>
		/// <param name="prefix">Prefisso del messaggio mostrato</param>
		/// <param name="postfix">Postfisso del messaggio mostrato</param>
		internal virtual void DisplayBasicInfo(string prefix, string postfix)
		{
			Console.WriteLine($"{prefix}Nome: {this.Name} - Cognome: {this.LastName} - Data di nascita: {this.birthDate}{postfix}");
		}
	}
}
