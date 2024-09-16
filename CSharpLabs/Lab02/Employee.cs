using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
	internal class Employee : Person
	{
		private string companyName;

		internal Employee()
        {
 
        }

		internal Employee(string Name, string LastName, DateOnly BirthDate, 
			int EmployeeId, string JobTitle, decimal GrossSalary)
			: base(Name, LastName, BirthDate)
		{
			this.EmployeeId = EmployeeId;
			this.JobTitle = JobTitle;
			this.GrossSalary = GrossSalary;
		}

		// Proprietà specifiche della classe Employee
		internal int EmployeeId { get; set; }
		internal string JobTitle { get; set; }
		internal decimal GrossSalary { get; set; }
		internal string CompanyName 
		{
			get { return companyName; }
			set 
			{
				// Validazione dei parametri di input
				if (value == "" || value == null)
					throw new ArgumentException("CompanyName non può essere vuoto");
				companyName = value; 
			}
		}

		// Read-only property
		internal decimal MonthlySalary
		{
			get
			{
				return GrossSalary / 12;
			}
		}

		// Overrides del metodo DisplayBasicInfo della classe Person
		internal override void DisplayBasicInfo()
		{
			Console.WriteLine($"Nome: {this.Name} - Cognome: {this.LastName} - Data di nascita: {this.birthDate} - Posizione: {this.JobTitle}");
		}
		internal override void DisplayBasicInfo(string prefix)
		{
			Console.WriteLine($"{prefix}Nome: {this.Name} - Cognome: {this.LastName} - Data di nascita: {this.birthDate} - Posizione: {this.JobTitle}");
		}
		internal override void DisplayBasicInfo(string prefix, string postfix)
		{
			Console.WriteLine($"{prefix}Nome: {this.Name} - Cognome: {this.LastName} - Data di nascita: {this.birthDate} - Posizione: {this.JobTitle}{postfix}");
		}


	}
}
