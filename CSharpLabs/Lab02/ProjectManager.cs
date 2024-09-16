using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
	internal class ProjectManager : Employee
	{
		internal int TeamSize { get; set; }
		internal ProjectTypes Project { get; set; }

		internal ProjectManager(string Name, string LastName, DateOnly BirthDate,
			int EmployeeId, string JobTitle, decimal GrossSalary)
			: base(Name, LastName, BirthDate, EmployeeId, JobTitle, GrossSalary)
		{

		}

		internal override void DisplayBasicInfo()
		{
			Console.WriteLine($"Nome: {this.Name} - Cognome: {this.LastName} - Data di nascita: {this.birthDate} - Posizione: {this.JobTitle} - Dimensione team: {this.TeamSize}");
		}
	}
}
